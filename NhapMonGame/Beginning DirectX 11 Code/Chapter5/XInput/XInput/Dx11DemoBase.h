/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    DirectX 11 Base Class - Used as base class for all DirectX 11 demos in this book.
*/


#ifndef _DEMO_BASE_H_
#define _DEMO_BASE_H_

#include<d3d11.h>
#include<d3dx11.h>
#include<DxErr.h>
#include<dinput.h>


#define KEYDOWN(name, key)( name[key] & 0x80 )
#define BUTTONDOWN(device, key)( device.rgbButtons[key] & 0x80 )


class Dx11DemoBase
{
    public:
        Dx11DemoBase( );
        virtual ~Dx11DemoBase( );

        bool Initialize( HINSTANCE hInstance, HWND hwnd );
        void Shutdown( );

        bool CompileD3DShader( char* filePath, char* entry,
                               char* shaderModel, ID3DBlob** buffer );

        virtual bool LoadContent( );
        virtual void UnloadContent( );

        virtual void Update( float dt ) = 0;
        virtual void Render( ) = 0;

    protected:
        HINSTANCE hInstance_;
        HWND hwnd_;

        D3D_DRIVER_TYPE driverType_;
        D3D_FEATURE_LEVEL featureLevel_;

        ID3D11Device* d3dDevice_;
        ID3D11DeviceContext* d3dContext_;
        IDXGISwapChain* swapChain_;
        ID3D11RenderTargetView* backBufferTarget_;

        LPDIRECTINPUT8 directInput_;
        
        LPDIRECTINPUTDEVICE8 keyboardDevice_;
		char keyboardKeys_[256];
        char prevKeyboardKeys_[256];

        LPDIRECTINPUTDEVICE8 mouseDevice_;
        DIMOUSESTATE mouseState_;
        DIMOUSESTATE prevMouseState_;
        long mousePosX_;
        long mousePosY_;
        long mouseWheel_;
};

#endif