using Pong.Difficulty;
using UnityEngine;

namespace Pong.Paddle.Mobility
{
    public class PaddleMovementInstaller : MonoBehaviour
    {             
        [SerializeField] private ViewportLimits _playerViewportLimits;

        [SerializeField] private Rigidbody2D _paddleRb;
        [SerializeField] private PaddleMovement _paddleMovement;
        

        private void Awake()
        {
            _paddleMovement.Init(_paddleRb, GetCheckLimitsStrategy());
        }

        private ICheckLimits GetCheckLimitsStrategy()
        {            
            return new ViewportCheckLimits(Camera.main, _playerViewportLimits);
        }

    }
}

