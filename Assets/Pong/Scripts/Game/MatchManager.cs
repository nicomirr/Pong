using Pong.Input;
using Pong.Audio;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Pong.Game
{
    public class MatchManager : MonoBehaviour
    {
        [Header("Gameplay Objects")]
        [SerializeField] private MonoBehaviour[] _gameplayObjects;

        [Header("Score")]
        [SerializeField] private int _winScore;
        [SerializeField] private TextMeshProUGUI _leftScoreText;
        [SerializeField] private TextMeshProUGUI _rightScoreText;

        [Header("Win Text")]
        [SerializeField] private float _winTextDisplayTime;
        [SerializeField] private string _leftPaddleWinText;
        [SerializeField] private string _rightPaddleWinText;
        [SerializeField] private string _aiWinText;
        [SerializeField] private TextMeshProUGUI _winText;

        private int _leftPaddleScore;
        private int _rightPaddleScore;

        private void Awake()
        {
            EnableGameplayObjects();
        }

        private void OnEnable()
        {
            GameEvents.PointScored += AddPoint;
        }

        private void OnDisable()
        {
            GameEvents.PointScored -= AddPoint;
        }

        private void Start()
        {
            UpdateScoreTexts();
        }

        private void AddPoint(ScoreZoneSide _side)
        {
            switch (_side)
            {
                case ScoreZoneSide.Left:
                    {
                        _rightPaddleScore++;
                        break;
                    }
                case ScoreZoneSide.Right:
                    {
                        _leftPaddleScore++;
                        break;
                    }
            }

            UpdateScoreTexts();
            CheckForWinner();
        }

        private void UpdateScoreTexts()
        {
            _leftScoreText.text = _leftPaddleScore < 10 ? "0" + _leftPaddleScore : _leftPaddleScore.ToString();
            _rightScoreText.text = _rightPaddleScore < 10 ? "0" + _rightPaddleScore : _rightPaddleScore.ToString();
        }

        private void CheckForWinner()
        {
            if (_leftPaddleScore == _winScore)
            {
                StartCoroutine(DisplayWinner(_leftPaddleWinText));
            }
            else if (_rightPaddleScore == _winScore)
            {
                bool rightPlayerAI = GameSession.PaddleMode == RightPaddleMode.AI;

                if (rightPlayerAI)
                {
                    StartCoroutine(DisplayWinner(_aiWinText));
                }
                else
                {
                    StartCoroutine(DisplayWinner(_rightPaddleWinText));
                }
            }
        }

        private IEnumerator DisplayWinner(string winText)
        {
            DisableGameplayObjects();

            yield return new WaitForSeconds(1.5f);

            AudioEvents.RaisePlaySFX(SFXType.GameFinished);

            _winText.gameObject.SetActive(true);
            _winText.text = winText;

            yield return new WaitForSeconds(_winTextDisplayTime);

            SceneManager.LoadScene(0);
        }

        private void EnableGameplayObjects()
        {
            foreach (var mono in _gameplayObjects)
            {
                if (mono is IGameplayController obj)
                {
                    obj.EnableGameplay();
                }
            }
        }

        private void DisableGameplayObjects()
        {
            foreach (var mono in _gameplayObjects)
            {
                if (mono is IGameplayController obj)
                {
                    obj.DisableGameplay();
                }
            }
        }

    }
}

