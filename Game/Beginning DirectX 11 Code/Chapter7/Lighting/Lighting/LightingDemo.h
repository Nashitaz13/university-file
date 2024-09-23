/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    3D Lighting Demo - Demonstrates lighting (per-pixel).
*/


#ifndef _LIGHTING_DEMO_H_
#define _LIGHTING_DEMO_H_

#include"Dx11DemoBase.h"
#include"ArcCamera.h"
#include<XInput.h>


class LightingDemo : public Dx11DemoBase
{
    public:
        LightingDemo( );
        virtual ~LightingDemo( );

        bool LoadContent( );
        void UnloadContent( );

        void Update( float dt );
        void Render( );

    private:
        ID3D11VertexShader* lightVS_;
        ID3D11PixelShader* lightPS_;

        ID3D11InputLayout* inputLayout_;
        ID3D11Buffer* vertexBuffer_;
        int totalVerts_;

        ID3D11Buffer* viewCB_;
        ID3D11Buffer* projCB_;
        ID3D11Buffer* worldCB_;
        ID3D11Buffer* camPosCB_;
        XMMATRIX projMatrix_;

        ArcCamera camera_;

        XINPUT_STATE controller1State_;
        XINPUT_STATE prevController1State_;
};

#endif