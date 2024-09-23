/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    3D Lighting Demo - Demonstrates lighting (per-pixel).
*/


#include"LightingDemo.h"
#include<xnamath.h>
#include"objLoader.h"


struct VertexPos
{
    XMFLOAT3 pos;
    XMFLOAT2 tex0;
    XMFLOAT3 norm;
};


LightingDemo::LightingDemo( ) : lightVS_( 0 ), lightPS_( 0 ), inputLayout_( 0 ),
                            vertexBuffer_( 0 ), viewCB_( 0 ), projCB_( 0 ),
                            worldCB_( 0 ), camPosCB_( 0 ), totalVerts_( 0 )
{
    ZeroMemory( &controller1State_, sizeof( XINPUT_STATE ) );
    ZeroMemory( &prevController1State_, sizeof( XINPUT_STATE ) );
}


LightingDemo::~LightingDemo( )
{

}


bool LightingDemo::LoadContent( )
{
    ID3DBlob* vsBuffer = 0;

    bool compileResult = CompileD3DShader( "Lighting.fx", "VS_Main", "vs_4_0", &vsBuffer );

    if( compileResult == false )
    {
        DXTRACE_MSG( "Error compiling the vertex shader!" );
        return false;
    }

    HRESULT d3dResult;

    d3dResult = d3dDevice_->CreateVertexShader( vsBuffer->GetBufferPointer( ),
        vsBuffer->GetBufferSize( ), 0, &lightVS_ );

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
        { "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
        { "NORMAL",   0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 20, D3D11_INPUT_PER_VERTEX_DATA, 0 }
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

    compileResult = CompileD3DShader( "Lighting.fx", "PS_Main", "ps_4_0", &psBuffer );

    if( compileResult == false )
    {
        DXTRACE_MSG( "Error compiling pixel shader!" );
        return false;
    }

    d3dResult = d3dDevice_->CreatePixelShader( psBuffer->GetBufferPointer( ),
        psBuffer->GetBufferSize( ), 0, &lightPS_ );

    psBuffer->Release( );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Error creating pixel shader!" );
        return false;
    }


    // Load the models from the file.
    ObjModel objModel;

    if( objModel.LoadOBJ( "BasicShapes.obj" ) == false )
    {
        DXTRACE_MSG( "Error loading 3D model!" );
        return false;
    }

    totalVerts_ = objModel.GetTotalVerts( );

    VertexPos* vertices = new VertexPos[totalVerts_];
    float* vertsPtr = objModel.GetVertices( );
    float* texCPtr = objModel.GetTexCoords( );
    float* normalPtr = objModel.GetNormals( );

    for( int i = 0; i < totalVerts_; i++ )
    {
        vertices[i].pos = XMFLOAT3( *(vertsPtr + 0), *(vertsPtr + 1), *(vertsPtr + 2) );
        vertsPtr += 3;

        vertices[i].tex0 = XMFLOAT2( *(texCPtr + 0), *(texCPtr + 1) );
        texCPtr += 2;

        vertices[i].norm = XMFLOAT3( *(normalPtr + 0), *(normalPtr + 1), *(normalPtr + 2) );
        normalPtr += 3;
    }

    D3D11_BUFFER_DESC vertexDesc;
    ZeroMemory( &vertexDesc, sizeof( vertexDesc ) );
    vertexDesc.Usage = D3D11_USAGE_DEFAULT;
    vertexDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
    vertexDesc.ByteWidth = sizeof( VertexPos ) * totalVerts_;

    D3D11_SUBRESOURCE_DATA resourceData;
    ZeroMemory( &resourceData, sizeof( resourceData ) );
    resourceData.pSysMem = vertices;

    d3dResult = d3dDevice_->CreateBuffer( &vertexDesc, &resourceData, &vertexBuffer_ );

    if( FAILED( d3dResult ) )
    {
        DXTRACE_MSG( "Failed to create vertex buffer!" );
        return false;
    }

    delete[] vertices;
    objModel.Release( );


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

    constDesc.ByteWidth = sizeof( XMFLOAT4 );

    d3dResult = d3dDevice_->CreateBuffer( &constDesc, 0, &camPosCB_ );

	if( FAILED( d3dResult ) )
    {
        return false;
    }

    projMatrix_ = XMMatrixPerspectiveFovLH( XM_PIDIV4, 800.0f / 600.0f, 0.01f, 100.0f );
    projMatrix_ = XMMatrixTranspose( projMatrix_ );

    camera_.SetDistance( 50.0f, 10.0f, 100.0f );

    return true;
}


void LightingDemo::UnloadContent( )
{
    if( lightVS_ ) lightVS_->Release( );
    if( lightPS_ ) lightPS_->Release( );
    if( inputLayout_ ) inputLayout_->Release( );
    if( vertexBuffer_ ) vertexBuffer_->Release( );
    if( viewCB_ ) viewCB_->Release( );
    if( projCB_ ) projCB_->Release( );
    if( worldCB_ ) worldCB_->Release( );
    if( camPosCB_ ) camPosCB_->Release( );

    lightVS_ = 0;
    lightPS_ = 0;
    inputLayout_ = 0;
    vertexBuffer_ = 0;
    viewCB_ = 0;
    projCB_ = 0;
    worldCB_ = 0;
}


void LightingDemo::Update( float dt )
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
		camera_.ApplyZoom( -5.0f );
	}

    // Button up event.
    if( ( prevController1State_.Gamepad.wButtons & XINPUT_GAMEPAD_A ) &&
        !( controller1State_.Gamepad.wButtons & XINPUT_GAMEPAD_A ) )

	{ 
		camera_.ApplyZoom( 5.0f );
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


void LightingDemo::Render( )
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
    d3dContext_->IASetPrimitiveTopology( D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST );

    d3dContext_->VSSetShader( lightVS_, 0, 0 );
    d3dContext_->PSSetShader( lightPS_, 0, 0 );

    XMMATRIX worldMat = XMMatrixIdentity( );
    worldMat = XMMatrixTranspose( worldMat );

    XMMATRIX viewMat = camera_.GetViewMatrix( );
    viewMat = XMMatrixTranspose( viewMat );

    XMFLOAT3 cameraPos = camera_.GetPosition( );

    d3dContext_->UpdateSubresource( worldCB_, 0, 0, &worldMat, 0, 0 );
    d3dContext_->UpdateSubresource( viewCB_, 0, 0, &viewMat, 0, 0 );
    d3dContext_->UpdateSubresource( projCB_, 0, 0, &projMatrix_, 0, 0 );
    d3dContext_->UpdateSubresource( camPosCB_, 0, 0, &cameraPos, 0, 0 );

    d3dContext_->VSSetConstantBuffers( 0, 1, &worldCB_ );
    d3dContext_->VSSetConstantBuffers( 1, 1, &viewCB_ );
    d3dContext_->VSSetConstantBuffers( 2, 1, &projCB_ );
    d3dContext_->VSSetConstantBuffers( 3, 1, &camPosCB_ );

    d3dContext_->Draw( totalVerts_, 0 );

    swapChain_->Present( 0, 0 );
}