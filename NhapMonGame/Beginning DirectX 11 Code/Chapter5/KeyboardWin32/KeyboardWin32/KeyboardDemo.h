/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    Keyboard Demo - Demo used to perform keyboard input.
*/


#ifndef _KEYBOARD_DEMO_H_
#define _KEYBOARD_DEMO_H_

#include"Dx11DemoBase.h"


class KeyboardDemo : public Dx11DemoBase
{
    public:
        KeyboardDemo( );
        virtual ~KeyboardDemo( );

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
};

#endif