/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    Arc Camera Demo - Demonstrates a arc camera.
*/


#ifndef _CAMERA_DEMO_H_
#define _CAMERA_DEMO_H_

#include"Dx11DemoBase.h"
#include"ArcCamera.h"
#include<XInput.h>


class CameraDemo2 : public Dx11DemoBase
{
    public:
        CameraDemo2( );
        virtual ~CameraDemo2( );

        bool LoadContent( );
        void UnloadContent( );

        void Update( float dt );
        void Render( );

    private:
        ID3D11VertexShader* textureMapVS_;
        ID3D11PixelShader* textureMapPS_;

        ID3D11InputLayout* inputLayout_;
        ID3D11Buffer* vertexBuffer_;
        ID3D11Buffer* indexBuffer_;

        ID3D11ShaderResourceView* colorMap_;
        ID3D11SamplerState* colorMapSampler_;

        ID3D11Buffer* viewCB_;
        ID3D11Buffer* projCB_;
        ID3D11Buffer* worldCB_;
        XMFLOAT4X4 projMatrix_;

        ArcCamera camera_;

        XINPUT_STATE controller1State_;
        XINPUT_STATE prevController1State_;
};

#endif