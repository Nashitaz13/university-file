/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    XACT3Demo - Demo used to play audio using XACT3.
*/


#include"XACT3Demo.h"
#include"GameSprite.h"


struct VertexPos
{
    XMFLOAT3 pos;
    XMFLOAT2 tex0;
};


XACT3Demo::XACT3Demo( ) : solidColorVS_( 0 ), solidColorPS_( 0 ), inputLayout_( 0 ),
                          vertexBuffer_( 0 ), colorMap_( 0 ), colorMapSampler_( 0 ),
                          mvpCB_( 0 ), alphaBlendState_( 0 ), soundEngine_( 0 )
{

}


XACT3Demo::~XACT3Demo( )
{

}


bool XACT3Demo::LoadContent( )
{
    ID3DBlob* vsBuffer = 0;

    bool compileResult = CompileD3DShader( "TextureMap.fx", "VS_Main", "vs_4_0", &vsBuffer );

    if( compileResult == false )
    {
        DXTRACE_MSG( "Error compiling the vertex shader!" );
        return false;
    }

    HRESULT d3dResult;

    d3dResult = d3dDevice_->CreateVertexShader( vsBuffer->GetBufferPointer( ),
        vsBuffer->GetBufferSize( ), 0, &solidColorVS_ );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Error creating the vertex shader!" );

        if( vsBuffer )
            vsBuffer->Release( );

        return false;
    }

    D3D11_INPUT_ELEMENT_DESC solidColorLayout[] =
    {
        { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
        { "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 }
    };

    unsigned int totalLayoutElements = ARRAYSIZE( solidColorLayout );

    d3dResult = d3dDevice_->CreateInputLayout( solidColorLayout, totalLayoutElements,
        vsBuffer->GetBufferPointer( ), vsBuffer->GetBufferSize( ), &inputLayout_ );

    vsBuffer->Release( );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Error creating the input layout!" );
        return false;
    }

    ID3DBlob* psBuffer = 0;

    compileResult = CompileD3DShader( "TextureMap.fx", "PS_Main", "ps_4_0", &psBuffer );

    if( compileResult == false )
    {
        DXTRACE_MSG( "Error compiling pixel shader!" );
        return false;
    }

    d3dResult = d3dDevice_->CreatePixelShader( psBuffer->GetBufferPointer( ),
        psBuffer->GetBufferSize( ), 0, &solidColorPS_ );

    psBuffer->Release( );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Error creating pixel shader!" );
        return false;
    }


    d3dResult = D3DX11CreateShaderResourceViewFromFile( d3dDevice_,
        "xactAudio.dds", 0, 0, &colorMap_, 0 );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Failed to load the texture image!" );
        return false;
    }

    D3D11_SAMPLER_DESC colorMapDesc;
    ZeroMemory( &colorMapDesc, sizeof( colorMapDesc ) );
    colorMapDesc.AddressU = D3D11_TEXTURE_ADDRESS_WRAP;
    colorMapDesc.AddressV = D3D11_TEXTURE_ADDRESS_WRAP;
    colorMapDesc.AddressW = D3D11_TEXTURE_ADDRESS_WRAP;
    colorMapDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
    colorMapDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;
    colorMapDesc.MaxLOD = D3D11_FLOAT32_MAX;

    d3dResult = d3dDevice_->CreateSamplerState( &colorMapDesc, &colorMapSampler_ );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Failed to create color map sampler state!" );
        return false;
    }

    ID3D11Resource* colorTex;
    colorMap_->GetResource( &colorTex );

    D3D11_TEXTURE2D_DESC colorTexDesc;
    ( ( ID3D11Texture2D* )colorTex )->GetDesc( &colorTexDesc );
    colorTex->Release( );

    float halfWidth = ( float )colorTexDesc.Width / 2.0f;
    float halfHeight = ( float )colorTexDesc.Height / 2.0f;


    VertexPos vertices[] =
    {
        { XMFLOAT3(  halfWidth,  halfHeight, 1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
        { XMFLOAT3(  halfWidth, -halfHeight, 1.0f ), XMFLOAT2( 1.0f, 1.0f ) },
        { XMFLOAT3( -halfWidth, -halfHeight, 1.0f ), XMFLOAT2( 0.0f, 1.0f ) },

        { XMFLOAT3( -halfWidth, -halfHeight, 1.0f ), XMFLOAT2( 0.0f, 1.0f ) },
        { XMFLOAT3( -halfWidth,  halfHeight, 1.0f ), XMFLOAT2( 0.0f, 0.0f ) },
        { XMFLOAT3(  halfWidth,  halfHeight, 1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
    };

    D3D11_BUFFER_DESC vertexDesc;
    ZeroMemory( &vertexDesc, sizeof( vertexDesc ) );
    vertexDesc.Usage = D3D11_USAGE_DEFAULT;
    vertexDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
    vertexDesc.ByteWidth = sizeof( VertexPos ) * 6;

    D3D11_SUBRESOURCE_DATA resourceData;
    ZeroMemory( &resourceData, sizeof( resourceData ) );
    resourceData.pSysMem = vertices;

    d3dResult = d3dDevice_->CreateBuffer( &vertexDesc, &resourceData, &vertexBuffer_ );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Failed to create vertex buffer!" );
        return false;
    }


    D3D11_BUFFER_DESC constDesc;
	ZeroMemory( &constDesc, sizeof( constDesc ) );
	constDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
	constDesc.ByteWidth = sizeof( XMMATRIX );
	constDesc.Usage = D3D11_USAGE_DEFAULT;

	d3dResult = d3dDevice_->CreateBuffer( &constDesc, 0, &mvpCB_ );

	if( FAILED( d3dResult ) )
    {
        return false;
    }

    
    XMFLOAT2 sprite1Pos( 400.0f, 300.0f );
    textSprite_.SetPosition( sprite1Pos );

    XMMATRIX view = XMMatrixIdentity( );
    XMMATRIX projection = XMMatrixOrthographicOffCenterLH( 0.0f, 800.0f, 0.0f, 600.0f, 0.1f, 100.0f );
    vpMatrix_ = XMMatrixMultiply( view, projection );

    ZeroMemory( &audioBanks_, sizeof( stXACTAudio ) );

    if( SetupXACT( &soundEngine_ ) == false )
        return false;

    if( LoadXACTAudio( soundEngine_, audioBanks_, "Win/Wave Bank.xwb", "Win/Sound Bank.xsb" ) == false )
        return false;

    XACTINDEX clipCue = audioBanks_.soundBank->GetCueIndex( "clip" );
    audioBanks_.soundBank->Play( clipCue, 0, 0, 0 );

    return true;
}


void XACT3Demo::UnloadContent( )
{
    if( colorMapSampler_ ) colorMapSampler_->Release( );
    if( colorMap_ ) colorMap_->Release( );
    if( solidColorVS_ ) solidColorVS_->Release( );
    if( solidColorPS_ ) solidColorPS_->Release( );
    if( inputLayout_ ) inputLayout_->Release( );
    if( vertexBuffer_ ) vertexBuffer_->Release( );
    if( mvpCB_ ) mvpCB_->Release( );
    if( alphaBlendState_ ) alphaBlendState_->Release( );

    colorMapSampler_ = 0;
    colorMap_ = 0;
    solidColorVS_ = 0;
    solidColorPS_ = 0;
    inputLayout_ = 0;
    vertexBuffer_ = 0;
    mvpCB_ = 0;
    alphaBlendState_ = 0;

    if( audioBanks_.soundBank ) audioBanks_.soundBank->Destroy( );
    if( audioBanks_.waveBank ) audioBanks_.waveBank->Destroy( );

    if( soundEngine_ )
    {
        soundEngine_->ShutDown( );
        soundEngine_->Release( );
    }

    if( audioBanks_.soundBankData )
    {
        UnmapViewOfFile( audioBanks_.soundBankData );
        audioBanks_.soundBankData = 0;
    }

    if( audioBanks_.waveBankData )
    {
        UnmapViewOfFile( audioBanks_.waveBankData );
        audioBanks_.waveBankData = 0;
    }

    CoUninitialize( );
}


void XACT3Demo::Update( float dt )
{
    unsigned long state = 0;

    if( soundEngine_ != 0 && audioBanks_.soundBank != 0 )
    {
        audioBanks_.soundBank->GetState( &state );

        if( state && XACT_CUESTATE_PLAYING )
            soundEngine_->DoWork( );
    }
}


void XACT3Demo::Render( )
{
    if( d3dContext_ == 0 )
        return;

    float clearColor[4] = { 0.525f, 0.48f, 0.439f, 1.0f };
    d3dContext_->ClearRenderTargetView( backBufferTarget_, clearColor );

    unsigned int stride = sizeof( VertexPos );
    unsigned int offset = 0;

    d3dContext_->IASetInputLayout( inputLayout_ );
    d3dContext_->IASetVertexBuffers( 0, 1, &vertexBuffer_, &stride, &offset );
    d3dContext_->IASetPrimitiveTopology( D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST );

    d3dContext_->VSSetShader( solidColorVS_, 0, 0 );
    d3dContext_->PSSetShader( solidColorPS_, 0, 0 );
    d3dContext_->PSSetShaderResources( 0, 1, &colorMap_ );
    d3dContext_->PSSetSamplers( 0, 1, &colorMapSampler_ );

    XMMATRIX world = textSprite_.GetWorldMatrix( );
    XMMATRIX mvp = XMMatrixMultiply( world, vpMatrix_ );
    mvp = XMMatrixTranspose( mvp );

    d3dContext_->UpdateSubresource( mvpCB_, 0, 0, &mvp, 0, 0 );
    d3dContext_->VSSetConstantBuffers( 0, 1, &mvpCB_ );

    d3dContext_->Draw( 6, 0 );

    swapChain_->Present( 0, 0 );
}