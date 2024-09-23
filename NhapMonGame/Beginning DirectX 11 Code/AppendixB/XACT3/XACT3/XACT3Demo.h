/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    XACT3Demo - Demo used to play audio using XACT3.
*/


#ifndef _XACT3_DEMO_H_
#define _XACT3_DEMO_H_

#include"Dx11DemoBase.h"
#include"GameSprite.h"
#include"Xact3Audio.h"


class XACT3Demo : public Dx11DemoBase
{
    public:
        XACT3Demo( );
        virtual ~XACT3Demo( );

        bool LoadContent( );
        void UnloadContent( );

        void Update( float dt );
        void Render( );

    private:
        ID3D11VertexShader* solidColorVS_;
        ID3D11PixelShader* solidColorPS_;

        ID3D11InputLayout* inputLayout_;
        ID3D11Buffer* vertexBuffer_;

        ID3D11ShaderResourceView* colorMap_;
        ID3D11SamplerState* colorMapSampler_;
        ID3D11BlendState* alphaBlendState_;

        GameSprite textSprite_;
        ID3D11Buffer* mvpCB_;
        XMMATRIX vpMatrix_;

        stXACTAudio audioBanks_;
        IXACT3Engine* soundEngine_;
};

#endif