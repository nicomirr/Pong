using UnityEngine;

using Pong.Paddle;

namespace Pong.Mobility
{
    public class MovementInstaller : MonoBehaviour
    {        
        [SerializeField] private ViewportLimits _playerViewportLimits;

        [SerializeField] private Transform _paddle;
        [SerializeField] private Movement _movement;

        private void Awake()
        {
            _movement.Init(GetCheckLimitsStrategy());
        }

        private ICheckLimits GetCheckLimitsStrategy()
        {            
            return new ViewportCheckLimits(_paddle, Camera.main, _playerViewportLimits);
        }

    }
}

