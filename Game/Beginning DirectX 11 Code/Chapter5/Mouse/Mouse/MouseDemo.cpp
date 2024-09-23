/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    Mouse Demo - Demo used to perform mouse input.
*/


#include"MouseDemo.h"
#include<xnamath.h>


struct VertexPos
{
    XMFLOAT3 pos;
};


MouseDemo::MouseDemo( ) : customColorVS_( 0 ), customColorPS_( 0 ),
                          inputLayout_( 0 ), vertexBuffer_( 0 ),
                          colorCB_( 0 ), selectedColor_( 0 )
{

}


MouseDemo::~MouseDemo( )
{

}


bool MouseDemo::LoadContent( )
{
    ID3DBlob* vsBuffer = 0;

    bool compileResult = CompileD3DShader( "CustomColor.hlsl", "VS_Main", "vs_4_0", &vsBuffer );

    if( compileResult == false )
    {
        MessageBox( 0, "Error loading vertex shader!", "Compile Error", MB_OK );
        return false;
    }

    HRESULT d3dResult;

    d3dResult = d3dDevice_->CreateVertexShader( vsBuffer->GetBufferPointer( ),
        vsBuffer->GetBufferSize( ), 0, &customColorVS_ );

    if( FAILED( d3dResult ) )
    {
        if( vsBuffer )
            vsBuffer->Release( );

        return false;
    }

    D3D11_INPUT_ELEMENT_DESC solidColorLayout[] =
    {
        { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 }
    };

    unsigned int totalLayoutElements = ARRAYSIZE( solidColorLayout );

    d3dResult = d3dDevice_->CreateInputLayout( solidColorLayout, totalLayoutElements,
        vsBuffer->GetBufferPointer( ), vsBuffer->GetBufferSize( ), &inputLayout_ );

    vsBuffer->Release( );

    if( FAILED( d3dResult ) )
    {
        return false;
    }

    ID3DBlob* psBuffer = 0;

    compileResult = CompileD3DShader( "CustomColor.hlsl", "PS_Main", "ps_4_0", &psBuffer );

    if( compileResult == false )
    {
        MessageBox( 0, "Error loading pixel shader!", "Compile Error", MB_OK );
        return false;
    }

    d3dResult = d3dDevice_->CreatePixelShader( psBuffer->GetBufferPointer( ),
        psBuffer->GetBufferSize( ), 0, &customColorPS_ );

    psBuffer->Release( );

    if( FAILED( d3dResult ) )
    {
        return false;
    }

    VertexPos vertices[] =
    {
        XMFLOAT3(  0.5f,  0.5f, 0.5f ),
        XMFLOAT3(  0.5f, -0.5f, 0.5f ),
        XMFLOAT3( -0.5f, -0.5f, 0.5f )
    };

    D3D11_BUFFER_DESC vertexDesc;
    ZeroMemory( &vertexDesc, sizeof( vertexDesc ) );
    vertexDesc.Usage = D3D11_USAGE_DEFAULT;
    vertexDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
    vertexDesc.ByteWidth = sizeof( VertexPos ) * 3;

    D3D11_SUBRESOURCE_DATA resourceData;
    ZeroMemory( &resourceData, sizeof( resourceData ) );
    resourceData.pSysMem = vertices;

    d3dResult = d3dDevice_->CreateBuffer( &vertexDesc, &resourceData, &vertexBuffer_ );

    if( FAILED( d3dResult ) )
    {
        return false;
    }


	D3D11_BUFFER_DESC constDesc;
	ZeroMemory( &constDesc, sizeof( constDesc ) );
	constDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
	constDesc.ByteWidth = sizeof( XMFLOAT4 );
	constDesc.Usage = D3D11_USAGE_DEFAULT;

	d3dResult = d3dDevice_->CreateBuffer( &constDesc, 0, &colorCB_ );

	if( FAILED( d3dResult ) )
    {
        return false;
    }

    return true;
}


void MouseDemo::UnloadContent( )
{
    if( customColorVS_ ) customColorVS_->Release( );
    if( customColorPS_ ) customColorPS_->Release( );
    if( inputLayout_ ) inputLayout_->Release( );
    if( vertexBuffer_ ) vertexBuffer_->Release( );
	if( colorCB_ ) colorCB_->Release( );

    customColorVS_ = 0;
    customColorPS_ = 0;
    inputLayout_ = 0;
    vertexBuffer_ = 0;
	colorCB_ = 0;
}


void MouseDemo::Update( float dt )
{
	keyboardDevice_->GetDeviceState( sizeof( keyboardKeys_ ), ( LPVOID )&keyboardKeys_ );
    mouseDevice_->GetDeviceState( sizeof ( mouseState_ ), ( LPVOID ) &mouseState_ );

    // Button press event.
	//if( KEYDOWN( keyboardKeys_, DIK_ESCAPE ) )
    if( GetAsyncKeyState( VK_ESCAPE ) )
	{ 
		PostQuitMessage( 0 );
	}

    // Button up event.
	if( KEYDOWN( prevKeyboardKeys_, DIK_DOWN ) && !KEYDOWN( keyboardKeys_, DIK_DOWN ) )
	{ 
		selectedColor_--;
	}

    // Button up event.
	if( KEYDOWN( prevKeyboardKeys_, DIK_UP ) && !KEYDOWN( keyboardKeys_, DIK_UP ) )
	{ 
		selectedColor_++;
	}

    if( BUTTONDOWN( mouseState_, 0 ) && !BUTTONDOWN( prevMouseState_, 0 ) ) 
    {
        selectedColor_++;
    }

    if( BUTTONDOWN( mouseState_, 1 ) && !BUTTONDOWN( prevMouseState_, 1 ) )
    { 
        selectedColor_--;
    } 

    mousePosX_ += mouseState_.lX;
    mousePosY_ += mouseState_.lY;
    mouseWheel_ += mouseState_.lZ;


    memcpy( prevKeyboardKeys_, keyboardKeys_, sizeof( keyboardKeys_ ) );
    memcpy( &prevMouseState_, &mouseState_, sizeof( mouseState_ ) );

    if( selectedColor_ < 0 ) selectedColor_ = 2;
    if( selectedColor_ > 2 ) selectedColor_ = 0;
}


void MouseDemo::Render( )
{
    if( d3dContext_ == 0 )
        return;

    float clearColor[4] = { 0.0f, 0.0f, 0.25f, 1.0f };
    d3dContext_->ClearRenderTargetView( backBufferTarget_, clearColor );

    unsigned int stride = sizeof( VertexPos );
    unsigned int offset = 0;

    d3dContext_->IASetInputLayout( inputLayout_ );
    d3dContext_->IASetVertexBuffers( 0, 1, &vertexBuffer_, &stride, &offset );
    d3dContext_->IASetPrimitiveTopology( D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST );

	XMFLOAT4 redColor( 1.0f, 0.0f, 0.0f, 1.0f );
	XMFLOAT4 greenColor( 0.0f, 1.0f, 0.0f, 1.0f );
	XMFLOAT4 blueColor( 0.0f, 0.0f, 1.0f, 1.0f );

	if( selectedColor_ == 0 )
	{
		d3dContext_->UpdateSubresource( colorCB_, 0, 0, &redColor, 0, 0 );
	}
	else if( selectedColor_ == 1 )
	{
		d3dContext_->UpdateSubresource( colorCB_, 0, 0, &greenColor, 0, 0 );
	}
	else
	{
		d3dContext_->UpdateSubresource( colorCB_, 0, 0, &blueColor, 0, 0 );
	}

    d3dContext_->VSSetShader( customColorVS_, 0, 0 );
    d3dContext_->PSSetShader( customColorPS_, 0, 0 );
	d3dContext_->PSSetConstantBuffers( 0, 1, &colorCB_ );
    d3dContext_->Draw( 3, 0 );

    swapChain_->Present( 0, 0 );
}