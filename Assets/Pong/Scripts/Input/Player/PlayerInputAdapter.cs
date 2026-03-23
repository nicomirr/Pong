using System;
using UnityEngine.InputSystem;

using Pong.Paddle.Mobility;

namespace Pong.Input.Player
{
    public class PlayerInputAdapter : IInput, IDisposable
    {
        private readonly IDirectionChanger _directionChanger;
        private readonly InputAction _movement;

        private float _direction;
    
        public PlayerInputAdapter(IDirectionChanger directionChanger, InputAction movement)
        {
            _directionChanger = directionChanger;
            _movement = movement;
        
            _movement.Enable(); 
        
            _movement.performed += OnMovementPerformed;
            _movement.canceled += OnMovementCanceled;
        
        }

        public void Dispose()
        {
            _movement.performed -= OnMovementPerformed;
            _movement.canceled -= OnMovementCanceled;

            _movement.Disable();                        
        }
    
        private void OnMovementPerformed(InputAction.CallbackContext ctx)
        {
            _direction = ctx.ReadValue<float>();
        }

        private void OnMovementCanceled(InputAction.CallbackContext ctx)
        {
            _direction = 0;
        }
    
        public void ChangeDirection()
        {
            _directionChanger.ChangeDirection(_direction);
        }
    }
}
