using Pong.Ball;
using Pong.Game;
using System.Collections;
using UnityEngine;

public class BallResetController : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private BallLauncher _ballLauncher;
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        GameEvents.ResetBall += HandlePointScored;
    }

    private void OnDisable()
    {
        GameEvents.ResetBall -= HandlePointScored;
    }

    private void HandlePointScored()
    {
        StartCoroutine(ResetRoutine());
    }

    private IEnumerator ResetRoutine()
    {
        _ballMovement.StopBall();

        yield return new WaitForSeconds(_delay);

        _ballLauncher.Launch();
    }
}
