using Pong.Game;
using Pong.Input.AI;
using Pong.Input.Player;
using Pong.Paddle;
using Pong.Paddle.Mobility;
using Pong.Paddle.Spatial;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pong.Input
{
    public class InputInstaller : MonoBehaviour
    {

        [Header("General")]
        [SerializeField] private PaddleSide _paddleSide;
        [SerializeField] private MonoBehaviour _movementMonobehaviour;
        [SerializeField] private InputHandler _inputHandler;

        [Header("IA")]
        [SerializeField] private MonoBehaviour _ballMovementMonobehaviour;
        [SerializeField] private MonoBehaviour _paddleBoundsProviderMonobehaviour;
      
        private GameInput _gameInput;

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
            var rightPaddleMode = GameSession.PaddleMode;

            switch (_paddleSide)
            {
                case PaddleSide.Left:
                    {
                        _gameInput = new GameInput();
                        _gameInput.Enable();
                    
                        InputAction movement = _gameInput.PaddleLeft.Movement;
                        return new PlayerInputAdapter(directionChanger, movement);
                    }
                case PaddleSide.Right:
                    {
                        _gameInput = new GameInput();
                        _gameInput.Enable();
                    
                        if(rightPaddleMode == RightPaddleMode.Arrows)
                        {
                            InputAction movement = _gameInput.PaddleRight.Movement;
                            return new PlayerInputAdapter(directionChanger, movement);
                        }

                        return new AIInputAdapter(directionChanger, ballYPosProvider, paddleYPosProvider, paddleBoundsProvider);
                    }
                default:                    
                        throw new System.ArgumentOutOfRangeException(nameof(_paddleSide), _paddleSide, null);
                    

            }
        }

        private void OnDisable()
        {
            _gameInput.Disable();
        }
    }
}
