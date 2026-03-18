using UnityEngine;

using Pong.Paddle;

namespace Pong.Mobility
{
    public class PaddleMovementInstaller : MonoBehaviour
    {        
        [SerializeField] private ViewportLimits _playerViewportLimits;

        [SerializeField] private Rigidbody2D _paddleRb;
        [SerializeField] private PaddleMovement _movement;

        private void Awake()
        {
            _movement.Init(_paddleRb, GetCheckLimitsStrategy());
        }

        private ICheckLimits GetCheckLimitsStrategy()
        {            
            return new ViewportCheckLimits(Camera.main, _playerViewportLimits);
        }
    }
}

