using UnityEngine;
using UnityEngine.InputSystem;

public class InputInstaller : MonoBehaviour
{
    [SerializeField] private InputType _inputType;
    [SerializeField] private MonoBehaviour _directionChangerBehaviour;

    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Movement _movement;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _inputHandler.Init(GetInput());
    }

    private IInput GetInput()
    {
        switch (_inputType)
        {
            case InputType.Arrows:
            {
                _playerInput = new PlayerInput();
                _playerInput.Enable();
                
                InputAction movement = _playerInput.PlayerA.Movement;
                return new PlayerInputAdapter(_directionChangerBehaviour as IDirectionChanger, movement);
            }
            default:
            {
                _playerInput = new PlayerInput();
                _playerInput.Enable();
                
                InputAction movement = _playerInput.PlayerB.Movement;
                return new PlayerInputAdapter(_directionChangerBehaviour as IDirectionChanger, movement);
            }
        }
    }
}
