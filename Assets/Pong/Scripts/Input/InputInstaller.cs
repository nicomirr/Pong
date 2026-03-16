using Pong.Input.AI;
using Pong.Input.Player;
using Pong.Mobility;
using Pong.Spatial;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pong.Input
{
    public class InputInstaller : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private InputType _inputType;
        [SerializeField] private MonoBehaviour _movementMonobehaviour;
        [SerializeField] private InputHandler _inputHandler;


        [Header("IA")]
        [SerializeField] private MonoBehaviour _ballMovementMonobehaviour;
        [SerializeField] private MonoBehaviour _paddleBoundsProviderMonobehaviour;
      
        private PlayerInput _playerInput;

        private void Awake()
        {
            _inputHandler.Init(CreateInput());
        }

        private IInput CreateInput()
        {
            var directionChanger = _movementMonobehaviour as IDirectionChanger;
            var paddleYPosProvider = _movementMonobehaviour as IYPositionProvider;
            var ballYPosProvider = _ballMovementMonobehaviour as IYPositionProvider;
            var paddleBoundsProvider = _paddleBoundsProviderMonobehaviour as IPaddleBoundsProvider;

            switch (_inputType)
            {
                case InputType.Arrows:
                    {
                        _playerInput = new PlayerInput();
                        _playerInput.Enable();
                    
                        InputAction movement = _playerInput.PlayerA.Movement;
                        return new PlayerInputAdapter(directionChanger, movement);
                    }
                case InputType.WASD:
                    {
                        _playerInput = new PlayerInput();
                        _playerInput.Enable();
                    
                        InputAction movement = _playerInput.PlayerB.Movement;
                        return new PlayerInputAdapter(directionChanger, movement);
                    }
                case InputType.AI:
                default:
                    {                                      
                        return new AIInputAdapter(directionChanger, ballYPosProvider, paddleYPosProvider, paddleBoundsProvider);
                    }

            }
        }
    }
}
