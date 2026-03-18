using UnityEngine;

namespace Pong.Mobility
{
    public interface ICheckLimits
    {
        public Vector2 ClampFinalPosition(Vector2 position);
    }
}
