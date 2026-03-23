using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Pong.Game;

namespace Pong.UI
{
    public class PauseManager : MonoBehaviour, IGameplayController
    {
        

        [SerializeField] private GameObject _pauseLayer;
               
        private GameInput _gameInput;
        private bool _isGamePaused;

        private bool _canPause;

        private void Awake()
        {
            _gameInput = new GameInput();
        }

        public void EnableGameplay()
        {
            _canPause = true;
        }

        public void DisableGameplay()
        {
            ResumeGame();
            _canPause = false;
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

        private void Start()
        {
            _isGamePaused = false;
        }
               
        private void OnPauseButtonPressed(InputAction.CallbackContext ctx)
        {
            if (!_canPause) return;

            if (_isGamePaused)
            {
                ResumeGame();
                return;
            }

            PauseGame();
        }

        private void PauseGame()
        {
            _gameInput.UI.ToMainMenu.performed += OnToMainMenuButtonPressed;

            _pauseLayer.SetActive(true);
            _isGamePaused = true;
            Time.timeScale = 0;
        }

        private void ResumeGame()
        {
            _gameInput.UI.ToMainMenu.performed -= OnToMainMenuButtonPressed;

            _pauseLayer.SetActive(false);
            _isGamePaused = false;
            Time.timeScale = 1;
        }

        private void OnToMainMenuButtonPressed(InputAction.CallbackContext ctx)
        {
            Time.timeScale = 1;
            _gameInput.UI.ToMainMenu.performed -= OnToMainMenuButtonPressed;
            SceneManager.LoadScene(0);
        }
        
    }
}


