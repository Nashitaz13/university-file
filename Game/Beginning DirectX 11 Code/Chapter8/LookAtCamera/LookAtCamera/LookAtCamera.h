/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    LookAtCamera - Demonstrates a simple target camera.
*/


#ifndef _LOOK_AT_CAM_H_
#define _LOOK_AT_CAM_H_

#include<xnamath.h>


class LookAtCamera
{
    public:
        LookAtCamera( );
        LookAtCamera( XMFLOAT3 pos, XMFLOAT3 target );

        void SetPositions( XMFLOAT3 pos, XMFLOAT3 target );
        XMMATRIX GetViewMatrix( );

    private:
        XMFLOAT3 position_;
        XMFLOAT3 target_;
        XMFLOAT3 up_;
};


#endif