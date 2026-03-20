using UnityEngine;

namespace Pong.Paddle.Spatial
{
    public class PaddleBoundsProvider : MonoBehaviour, IPaddleBoundsProvider
    {
        [SerializeField] private Collider2D _collider;

        public float HalfHeight => _collider.bounds.size.y * 0.5f;

    }
}
