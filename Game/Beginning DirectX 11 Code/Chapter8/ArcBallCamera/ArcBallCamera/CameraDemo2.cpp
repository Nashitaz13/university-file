/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    Arc Camera Demo - Demonstrates a arc camera.
*/


#include"CameraDemo2.h"
#include<xnamath.h>


struct VertexPos
{
    XMFLOAT3 pos;
    XMFLOAT2 tex0;
};


CameraDemo2::CameraDemo2( ) : textureMapVS_( 0 ), textureMapPS_( 0 ), inputLayout_( 0 ),
                              vertexBuffer_( 0 ), indexBuffer_( 0 ), colorMap_( 0 ), colorMapSampler_( 0 ),
                              viewCB_( 0 ), projCB_( 0 ), worldCB_( 0 )
{
    ZeroMemory( &controller1State_, sizeof( XINPUT_STATE ) );
    ZeroMemory( &prevController1State_, sizeof( XINPUT_STATE ) );
}


CameraDemo2::~CameraDemo2( )
{

}


bool CameraDemo2::LoadContent( )
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
        vsBuffer->GetBufferSize( ), 0, &textureMapVS_ );

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
        psBuffer->GetBufferSize( ), 0, &textureMapPS_ );

    psBuffer->Release( );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Error creating pixel shader!" );
        return false;
    }

    VertexPos vertices[] =
    {
        { XMFLOAT3( -1.0f,  1.0f, -1.0f ), XMFLOAT2( 0.0f, 0.0f ) },
        { XMFLOAT3(  1.0f,  1.0f, -1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
        { XMFLOAT3(  1.0f,  1.0f,  1.0f ), XMFLOAT2( 1.0f, 1.0f ) },
        { XMFLOAT3( -1.0f,  1.0f,  1.0f ), XMFLOAT2( 0.0f, 1.0f ) },

        { XMFLOAT3( -1.0f, -1.0f, -1.0f ), XMFLOAT2( 0.0f, 0.0f ) },
        { XMFLOAT3(  1.0f, -1.0f, -1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
        { XMFLOAT3(  1.0f, -1.0f,  1.0f ), XMFLOAT2( 1.0f, 1.0f ) },
        { XMFLOAT3( -1.0f, -1.0f,  1.0f ), XMFLOAT2( 0.0f, 1.0f ) },

        { XMFLOAT3( -1.0f, -1.0f,  1.0f ), XMFLOAT2( 0.0f, 0.0f ) },
        { XMFLOAT3( -1.0f, -1.0f, -1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
        { XMFLOAT3( -1.0f,  1.0f, -1.0f ), XMFLOAT2( 1.0f, 1.0f ) },
        { XMFLOAT3( -1.0f,  1.0f,  1.0f ), XMFLOAT2( 0.0f, 1.0f ) },

        { XMFLOAT3(  1.0f, -1.0f,  1.0f ), XMFLOAT2( 0.0f, 0.0f ) },
        { XMFLOAT3(  1.0f, -1.0f, -1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
        { XMFLOAT3(  1.0f,  1.0f, -1.0f ), XMFLOAT2( 1.0f, 1.0f ) },
        { XMFLOAT3(  1.0f,  1.0f,  1.0f ), XMFLOAT2( 0.0f, 1.0f ) },

        { XMFLOAT3( -1.0f, -1.0f, -1.0f ), XMFLOAT2( 0.0f, 0.0f ) },
        { XMFLOAT3(  1.0f, -1.0f, -1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
        { XMFLOAT3(  1.0f,  1.0f, -1.0f ), XMFLOAT2( 1.0f, 1.0f ) },
        { XMFLOAT3( -1.0f,  1.0f, -1.0f ), XMFLOAT2( 0.0f, 1.0f ) },

        { XMFLOAT3( -1.0f, -1.0f,  1.0f ), XMFLOAT2( 0.0f, 0.0f ) },
        { XMFLOAT3(  1.0f, -1.0f,  1.0f ), XMFLOAT2( 1.0f, 0.0f ) },
        { XMFLOAT3(  1.0f,  1.0f,  1.0f ), XMFLOAT2( 1.0f, 1.0f ) },
        { XMFLOAT3( -1.0f,  1.0f,  1.0f ), XMFLOAT2( 0.0f, 1.0f ) },
    };

    D3D11_BUFFER_DESC vertexDesc;
    ZeroMemory( &vertexDesc, sizeof( vertexDesc ) );
    vertexDesc.Usage = D3D11_USAGE_DEFAULT;
    vertexDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
    vertexDesc.ByteWidth = sizeof( VertexPos ) * 24;

    D3D11_SUBRESOURCE_DATA resourceData;
    ZeroMemory( &resourceData, sizeof( resourceData ) );
    resourceData.pSysMem = vertices;

    d3dResult = d3dDevice_->CreateBuffer( &vertexDesc, &resourceData, &vertexBuffer_ );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Failed to create vertex buffer!" );
        return false;
    }

    WORD indices[] =
    {
        3,   1,  0,  2,  1,  3,
        6,   4,  5,  7,  4,  6,
        11,  9,  8, 10,  9, 11,
        14, 12, 13, 15, 12, 14,
        19, 17, 16, 18, 17, 19,
        22, 20, 21, 23, 20, 22
    };

    D3D11_BUFFER_DESC indexDesc;
    ZeroMemory( &indexDesc, sizeof( indexDesc ) );
    indexDesc.Usage = D3D11_USAGE_DEFAULT;
    indexDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
    indexDesc.ByteWidth = sizeof( WORD ) * 36;
    indexDesc.CPUAccessFlags = 0;
    resourceData.pSysMem = indices;

    d3dResult = d3dDevice_->CreateBuffer( &indexDesc, &resourceData, &indexBuffer_ );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Failed to create index buffer!" );
        return false;
    }

    d3dResult = D3DX11CreateShaderResourceViewFromFile( d3dDevice_,
        "decal.dds", 0, 0, &colorMap_, 0 );

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


    D3D11_BUFFER_DESC constDesc;
	ZeroMemory( &constDesc, sizeof( constDesc ) );
	constDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
	constDesc.ByteWidth = sizeof( XMMATRIX );
	constDesc.Usage = D3D11_USAGE_DEFAULT;

	d3dResult = d3dDevice_->CreateBuffer( &constDesc, 0, &viewCB_ );

	if( FAILED( d3dResult ) )
    {
        return false;
    }

    d3dResult = d3dDevice_->CreateBuffer( &constDesc, 0, &projCB_ );

	if( FAILED( d3dResult ) )
    {
        return false;
    }

    d3dResult = d3dDevice_->CreateBuffer( &constDesc, 0, &worldCB_ );

	if( FAILED( d3dResult ) )
    {
        return false;
    }

    XMMATRIX projection = XMMatrixPerspectiveFovLH( XM_PIDIV4, 800.0f / 600.0f, 0.01f, 100.0f );
    projection = XMMatrixTranspose( projection );
    XMStoreFloat4x4( &projMatrix_, projection );

    camera_.SetDistance( 6.0f, 4.0f, 20.0f );

    return true;
}


void CameraDemo2::UnloadContent( )
{
    if( colorMapSampler_ ) colorMapSampler_->Release( );
    if( colorMap_ ) colorMap_->Release( );
    if( textureMapVS_ ) textureMapVS_->Release( );
    if( textureMapPS_ ) textureMapPS_->Release( );
    if( inputLayout_ ) inputLayout_->Release( );
    if( vertexBuffer_ ) vertexBuffer_->Release( );
    if( indexBuffer_ ) indexBuffer_->Release( );
    if( viewCB_ ) viewCB_->Release( );
    if( projCB_ ) projCB_->Release( );
    if( worldCB_ ) worldCB_->Release( );

    colorMapSampler_ = 0;
    colorMap_ = 0;
    textureMapVS_ = 0;
    textureMapPS_ = 0;
    inputLayout_ = 0;
    vertexBuffer_ = 0;
    indexBuffer_ = 0;
    viewCB_ = 0;
    projCB_ = 0;
    worldCB_ = 0;
}


void CameraDemo2::Update( float dt )
{
    unsigned long result = XInputGetState( 0, &controller1State_ );

    if( result != ERROR_SUCCESS )
    {
        return;
    }

    // Button press event.
    if( controller1State_.Gamepad.wButtons & XINPUT_GAMEPAD_BACK )
	{ 
		PostQuitMessage( 0 );
	}

    // Button up event.
    if( ( prevController1State_.Gamepad.wButtons & XINPUT_GAMEPAD_B ) &&
        !( controller1State_.Gamepad.wButtons & XINPUT_GAMEPAD_B ) )

	{ 
		camera_.ApplyZoom( -1.0f );
	}

    // Button up event.
    if( ( prevController1State_.Gamepad.wButtons & XINPUT_GAMEPAD_A ) &&
        !( controller1State_.Gamepad.wButtons & XINPUT_GAMEPAD_A ) )

	{ 
		camera_.ApplyZoom( 1.0f );
	}

    float yawDelta = 0.0f;
    float pitchDelta = 0.0f;

    if( controller1State_.Gamepad.sThumbRY < -1000 ) yawDelta = -0.001f;
    else if( controller1State_.Gamepad.sThumbRY > 1000 ) yawDelta = 0.001f;

    if( controller1State_.Gamepad.sThumbRX < -1000 ) pitchDelta = -0.001f;
    else if( controller1State_.Gamepad.sThumbRX > 1000 ) pitchDelta = 0.001f;

    camera_.ApplyRotation( yawDelta, pitchDelta );

    memcpy( &prevController1State_, &controller1State_, sizeof( XINPUT_STATE ) );
}


void CameraDemo2::Render( )
{
    if( d3dContext_ == 0 )
        return;

    float clearColor[4] = { 0.0f, 0.0f, 0.25f, 1.0f };
    d3dContext_->ClearRenderTargetView( backBufferTarget_, clearColor );
    d3dContext_->ClearDepthStencilView( depthStencilView_, D3D11_CLEAR_DEPTH, 1.0f, 0 );

    unsigned int stride = sizeof( VertexPos );
    unsigned int offset = 0;

    d3dContext_->IASetInputLayout( inputLayout_ );
    d3dContext_->IASetVertexBuffers( 0, 1, &vertexBuffer_, &stride, &offset );
    d3dContext_->IASetIndexBuffer( indexBuffer_, DXGI_FORMAT_R16_UINT, 0 );
    d3dContext_->IASetPrimitiveTopology( D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST );

    d3dContext_->VSSetShader( textureMapVS_, 0, 0 );
    d3dContext_->PSSetShader( textureMapPS_, 0, 0 );
    d3dContext_->PSSetShaderResources( 0, 1, &colorMap_ );
    d3dContext_->PSSetSamplers( 0, 1, &colorMapSampler_ );

    XMMATRIX worldMat = XMMatrixIdentity( );
    worldMat = XMMatrixTranspose( worldMat );

    XMMATRIX viewMat = camera_.GetViewMatrix( );
    viewMat = XMMatrixTranspose( viewMat );

    XMMATRIX projMat = XMLoadFloat4x4( &projMatrix_ );

    d3dContext_->UpdateSubresource( worldCB_, 0, 0, &worldMat, 0, 0 );
    d3dContext_->UpdateSubresource( viewCB_, 0, 0, &viewMat, 0, 0 );
    d3dContext_->UpdateSubresource( projCB_, 0, 0, &projMat, 0, 0 );

    d3dContext_->VSSetConstantBuffers( 0, 1, &worldCB_ );
    d3dContext_->VSSetConstantBuffers( 1, 1, &viewCB_ );
    d3dContext_->VSSetConstantBuffers( 2, 1, &projCB_ );

    d3dContext_->DrawIndexed( 36, 0, 0 );

    swapChain_->Present( 0, 0 );
}