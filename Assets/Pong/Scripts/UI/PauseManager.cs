using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseLayer;

    private GameInput _gameInput;
    private bool _isGamePaused;

    private void Awake()
    {
        _gameInput = new GameInput();
    }

    private void Start()
    {
        _isGamePaused = false;
    }

    private void OnEnable()
    {
        _gameInput.UI.Enable();

        _gameInput.UI.Pause.performed += OnPauseButtonPressed;
    }

    private void OnDisable()
    {
        _gameInput.UI.Pause.performed -= OnPauseButtonPressed;

        _gameInput.UI.Disable();
    }

    private void OnPauseButtonPressed(InputAction.CallbackContext ctx)
    {
        if(_isGamePaused)
        {
            ResumeGame();
            return;
        }

        PauseGame();
    }

    private void PauseGame()
    {
        _pauseLayer.SetActive(true);
        _isGamePaused = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        _pauseLayer.SetActive(false);
        _isGamePaused = false;
        Time.timeScale = 1;
    }

}
