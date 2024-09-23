/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    Mouse Demo - Demo used to perform mouse input.
*/


#ifndef _MOUSE_DEMO_H_
#define _MOUSE_DEMO_H_

#include"Dx11DemoBase.h"


class MouseDemo : public Dx11DemoBase
{
    public:
        MouseDemo( );
        virtual ~MouseDemo( );

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