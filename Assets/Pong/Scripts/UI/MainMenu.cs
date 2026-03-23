using Pong.Game;
using Pong.Input;
using Pong.Difficulty;
using Pong.Scene;
using Pong.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.UI
{
    public class MainMenu : MonoBehaviour
    {        
        [SerializeField] private GameObject _initialButtons;
        [SerializeField] private GameObject _optionsButton;
        [SerializeField] private GameObject _gameSelectionButtons;
        [SerializeField] private GameObject _difficultySelectionButtonsPlayers;
        [SerializeField] private GameObject _difficultySelectionButtonsAI;
                
        private void Start()
        {
            InitialConfig();
        }

        private void InitialConfig()
        {
            _initialButtons.SetActive(true);
            _optionsButton.SetActive(false);
            _gameSelectionButtons.SetActive(false);
            _difficultySelectionButtonsPlayers.SetActive(false);
            _difficultySelectionButtonsAI.SetActive(false);
        }   
        
        public void PlayPressed()
        {
            SwitchMenu(_initialButtons, _gameSelectionButtons);
        }

        public void OptionsPressed()
        {
            SwitchMenu(_initialButtons, _optionsButton);
        }

        public void SelectAIPressed()
        {
            SelectGameType(RightPaddleMode.AI);
            SwitchMenu(_gameSelectionButtons, _difficultySelectionButtonsAI);
        }

        public void SelectPlayersPressed()
        {
            SelectGameType(RightPaddleMode.Arrows);
            SwitchMenu(_gameSelectionButtons, _difficultySelectionButtonsPlayers);
        }

        public void BackFromOptionsPressed()
        {
            SwitchMenu(_optionsButton, _initialButtons);    
        }

        public void BackFromGameSelectionPressed()
        {
            SwitchMenu(_gameSelectionButtons, _initialButtons);
        }

        public void BackFromAIDifficultyPressed()
        {
            SwitchMenu(_difficultySelectionButtonsAI, _gameSelectionButtons);           
        }

        public void BackFromPlayersDifficultyPressed()
        {
            SwitchMenu(_difficultySelectionButtonsPlayers, _gameSelectionButtons);
        }

        private void SwitchMenu(GameObject oldButtons, GameObject newButtons)
        {
            AudioEvents.RaisePlaySFX(SFXType.UI_Click);

            oldButtons.SetActive(false);
            newButtons.SetActive(true);
        }

        private void SelectGameType(RightPaddleMode mode)
        {
            GameSession.SetRightPaddleMode(mode);
        }

        public void SelectEasy()
        {
            SelectDifficulty(DifficultyLevel.Easy);
        }

        public void SelectNormal()
        {
            SelectDifficulty(DifficultyLevel.Normal);
        }

        public void SelectHard()
        {
            SelectDifficulty(DifficultyLevel.Hard);
        }        

        private void SelectDifficulty(DifficultyLevel difficultyLevel)
        {
            GameSession.SetDifficultyLevel(difficultyLevel);
            StartGame();
        }      
    
        private void StartGame()
        {
            SceneManager.LoadScene((int)SceneName.Game);
        }        
    }
}



