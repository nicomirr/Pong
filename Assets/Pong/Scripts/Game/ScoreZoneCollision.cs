using Pong.Tags;
using Pong.Audio;
using UnityEngine;

namespace Pong.Game
{    
    public class ScoreZoneCollision : MonoBehaviour
    {        
        [SerializeField] private ScoreZoneSide _side;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<BallTag>(out _))
            {
                AudioEvents.RaisePlaySFX(SFXType.Goal);

                GameEvents.RaisePointScored(_side);
                GameEvents.RaiseResetBall();

            }
        }
    }
}

