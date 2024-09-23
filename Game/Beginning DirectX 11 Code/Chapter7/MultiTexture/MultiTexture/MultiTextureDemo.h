/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    MultiTextureDemo - Demonstrates mutiple textures on one object.
*/


#ifndef _MULTI_TEXTURE_DEMO_H_
#define _MULTI_TEXTURE_DEMO_H_

#include"Dx11DemoBase.h"
#include<xnamath.h>
#include<d3dx11effect.h>


class MultiTextureDemo : public Dx11DemoBase
{
    public:
        MultiTextureDemo( );
        virtual ~MultiTextureDemo( );

        bool LoadContent( );
        void UnloadContent( );

        void Update( float dt );
        void Render( );

    private:
        ID3DX11Effect* effect_;
        ID3D11InputLayout* inputLayout_;

        ID3D11Buffer* vertexBuffer_;
        ID3D11Buffer* indexBuffer_;

        ID3D11ShaderResourceView* colorMap_;
        ID3D11ShaderResourceView* secondMap_;
        ID3D11SamplerState* colorMapSampler_;

        XMMATRIX viewMatrix_;
        XMMATRIX projMatrix_;
};

#endif