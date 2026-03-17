using UnityEngine;

namespace Pong.Ball
{
    public static class BallBounce
    {
        public static Vector2 WallBounce(Vector2 previousVelocity, Vector2 normal)
        {
            Vector2 reflectedVelocity = Vector2.Reflect(previousVelocity, normal);

            if (Mathf.Abs(reflectedVelocity.y) < 0.2f)
                reflectedVelocity.y = Mathf.Sign(reflectedVelocity.y) * 0.2f;

            return reflectedVelocity;
        }

        public static Vector2 PaddleBounce(Vector2 ballPosition, Vector2 paddlePosition, float paddleHalfHeight, float _bounceFactor)
        {
            float speedX = ballPosition.x < paddlePosition.x ? -1 : 1; 
            float speedY = (ballPosition.y - paddlePosition.y) / paddleHalfHeight; 
            speedY *= _bounceFactor; 

            speedY = Mathf.Clamp(speedY, -_bounceFactor, _bounceFactor); 

            if (Mathf.Abs(speedY) < 0.1f) 
                speedY = speedY < 0 ? -0.2f : 0.2f; 
            
            return new Vector2(speedX, speedY);
        }
    }
}


