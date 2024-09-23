/*
    Beginning DirectX 11 Game Programming
    By Allen Sherrod and Wendy Jones

    LookAtCamera - Demonstrates a simple target camera.
*/


#include<d3d11.h>
#include"LookAtCamera.h"


LookAtCamera::LookAtCamera( ) : position_( XMFLOAT3( 0.0f, 0.0f, 0.0f ) ),
    target_( XMFLOAT3( 0.0f, 0.0f, 0.0f ) ), up_( XMFLOAT3( 0.0f, 1.0f, 0.0f ) )
{

}


LookAtCamera::LookAtCamera( XMFLOAT3 pos, XMFLOAT3 target ) :
    position_( pos ), target_( target ), up_( XMFLOAT3( 0.0f, 1.0f, 0.0f ) )
{

}


void LookAtCamera::SetPositions( XMFLOAT3 pos, XMFLOAT3 target )
{
    position_ = pos;
    target_ = target;
}


XMMATRIX LookAtCamera::GetViewMatrix( )
{
    XMMATRIX viewMat = XMMatrixLookAtLH( XMLoadFloat3( &position_ ),
        XMLoadFloat3( &target_ ), XMLoadFloat3( &up_ ) );

    return viewMat;
}