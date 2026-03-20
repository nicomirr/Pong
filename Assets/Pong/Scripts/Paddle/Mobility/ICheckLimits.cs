using UnityEngine;

namespace Pong.Paddle.Mobility
{
    public interface ICheckLimits
    {
        public Vector2 ClampFinalPosition(Vector2 position);
    }
}
