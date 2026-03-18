using Pong.Game;
using Pong.Score;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _leftPaddleScore;
    private int _rightPaddleScore;

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
        UpdateScoreText();
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

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _leftPaddleScore + " - " + _rightPaddleScore;
    }
        
}
