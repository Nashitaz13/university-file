/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    3D Models Demo - Demonstrates loading a model from an .OBJ file.
*/


#ifndef _MODELS_DEMO_H_
#define _MODELS_DEMO_H_

#include"Dx11DemoBase.h"
#include"ArcCamera.h"
#include<XInput.h>


class ModelsDemo : public Dx11DemoBase
{
    public:
        ModelsDemo( );
        virtual ~ModelsDemo( );

        bool LoadContent( );
        void UnloadContent( );

        void Update( float dt );
        void Render( );

    private:
        ID3D11VertexShader* textureMapVS_;
        ID3D11PixelShader* textureMapPS_;

        ID3D11InputLayout* inputLayout_;
        ID3D11Buffer* vertexBuffer_;
        int totalVerts_;

        ID3D11ShaderResourceView* colorMap_;
        ID3D11SamplerState* colorMapSampler_;

        ID3D11Buffer* viewCB_;
        ID3D11Buffer* projCB_;
        ID3D11Buffer* worldCB_;
        XMMATRIX projMatrix_;

        ArcCamera camera_;

        XINPUT_STATE controller1State_;
        XINPUT_STATE prevController1State_;
};

#endif