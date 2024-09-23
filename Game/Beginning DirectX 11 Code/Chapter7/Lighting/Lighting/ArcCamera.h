/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    ArcCamera - Demonstrates a camera with arc rotation.
*/


#ifndef _ARC_CAM_H_
#define _ARC_CAM_H_

#include<xnamath.h>


class ArcCamera
{
    public:
        ArcCamera( );

        void SetDistance( float distance, float minDistance, float maxDistance );
        void SetRotation( float x, float y, float minY, float maxY );
        void SetTarget( XMFLOAT3& target );

        void ApplyZoom( float zoomDelta );
        void ApplyRotation( float yawDelta, float pitchDelta );

        XMMATRIX GetViewMatrix( );
        XMFLOAT3 GetPosition( );

    private:
        XMFLOAT3 position_;
        XMFLOAT3 target_;

        float distance_, minDistance_, maxDistance_;
        float xRotation_, yRotation_, yMin_, yMax_;
};


#endif