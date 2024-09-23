/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    XInput Demo - Demo used to perform Xbox 360 game controller input.
*/


#ifndef _KEYBOARD_DEMO_H_
#define _KEYBOARD_DEMO_H_

#include"Dx11DemoBase.h"
#include<XInput.h>


class XInputDemo : public Dx11DemoBase
{
    public:
        XInputDemo( );
        virtual ~XInputDemo( );

        bool LoadContent( );
        void UnloadContent( );

        void Update( float dt );
        void Render( );

    private:
        ID3D11VertexShader* customColorVS_;
        ID3D11PixelShader* customColorPS_;

        ID3D11InputLayout* inputLayout_;
        ID3D11Buffer* vertexBuffer_;

		ID3D11Buffer* colorCB_;
		int selectedColor_;

        XINPUT_STATE controller1State_;
        XINPUT_STATE prevController1State_;
};

#endif