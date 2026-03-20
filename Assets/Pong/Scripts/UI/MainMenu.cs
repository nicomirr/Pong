using Pong.Game;
using Pong.Input;
using Pong.Difficulty;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _initialButtons;
        [SerializeField] private GameObject _gameSelectionButtons;
        [SerializeField] private GameObject _speedSelectionButtons;
        [SerializeField] private GameObject _difficultySelectionButtons;

        private void Start()
        {
            _initialButtons.SetActive(true);
        }

        public void PlayButtonPressed()
        {
            _initialButtons.SetActive(false);
            _gameSelectionButtons.SetActive(true);
        }

        public void Player1Vs2ButtonPressed()
        {
            GameSession.SetRightPaddleMode(RightPaddleMode.WASD);

            _gameSelectionButtons.SetActive(false);
            _speedSelectionButtons.SetActive(true);
        }

        public void PlayerVsAIButtonPressed()
        {
            GameSession.SetRightPaddleMode(RightPaddleMode.AI);

            _gameSelectionButtons.SetActive(false);
            _difficultySelectionButtons.SetActive(true);
        }

        public void EasyButtonPressed()
        {
            GameSession.SetDifficultyLevel(DifficultyLevel.Easy);
            SceneManager.LoadScene(1);
        }

        public void NormalButtonPressed()
        {
            GameSession.SetDifficultyLevel(DifficultyLevel.Normal);
            SceneManager.LoadScene(1);
        }

        public void HardButtonPressed()
        {
            GameSession.SetDifficultyLevel(DifficultyLevel.Hard);
            SceneManager.LoadScene(1);
        }

        public void BackToGameSelectionPressed()
        {
            _speedSelectionButtons.SetActive(false);
            _difficultySelectionButtons.SetActive(false);
            _gameSelectionButtons.SetActive(true);
        }

        public void BackToInitialPressed()
        {
            _gameSelectionButtons.SetActive(false);
            _initialButtons.SetActive(true);
        }

        
    }
}


//QUEDA RESOLVER LA DIFICULTAD. A PARTIR DE DIFICULTAD SELECCIONADA SE SETEA EN GAMESESSION
//DESDE GAMESESSION VA A PARAR A UN INSTALLER DE DIFICULTAD. VAMOS A INYECTAR LA VELOCIDAD A LAS PALETAS Y A LA PELOTA
//HAY QUE HACER UNA ESTRUCTURA QUE CONTENGA LAS VELOCIDADES, O QUIZAS UN SCRIPTABLE OBJECT POR CADA DIFICULTAD.
