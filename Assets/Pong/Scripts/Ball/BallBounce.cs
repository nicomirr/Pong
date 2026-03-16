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

        public static Vector2 PaddleBounce(Vector2 hitPoint, float paddleCenterY, float paddleHalfHeight,
            float maxBounceAngle, Vector2 previousVelocity)
        {
            float relative = (hitPoint.y - paddleCenterY) / paddleHalfHeight;
            relative = Mathf.Clamp(relative, -1f, 1f);

            float angle = relative * maxBounceAngle * Mathf.Deg2Rad;

            float dirX = GetHorizontalDirection(previousVelocity.x);

            float x = dirX * Mathf.Cos(angle);
            float y = Mathf.Sin(angle);

            y = ApplyMinimumVertical(y, relative, 0.2f);

            return new Vector2(x, y).normalized;
        }

        private static float GetHorizontalDirection(float previousVelocityX)
        {
            if (Mathf.Approximately(previousVelocityX, 0f))
                return 1f;

            return -Mathf.Sign(previousVelocityX);
        }

        private static float ApplyMinimumVertical(float y, float relative, float minY)
        {
            if (Mathf.Abs(y) >= minY)
                return y;

            float sign = relative == 0f ? 1f : Mathf.Sign(relative);
            return minY * sign;
        }

        

    }
}


