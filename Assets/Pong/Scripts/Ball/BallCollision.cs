using Pong.Audio;
using Pong.Tags;
using UnityEngine;

namespace Pong.Ball
{
    public class BallCollision : MonoBehaviour
    {      
        [SerializeField] private BounceModifier _bounceModifier;
        [SerializeField] private BallMovement _ballMovement;

        private void OnCollisionEnter2D(Collision2D collision)
        {           
            if (collision.gameObject.TryGetComponent<PaddleTag>(out _))
            {
                AudioEvents.RaisePlaySFX(SFXType.BallBounce);

                Vector2 paddlePosition = collision.transform.position;
                float paddleHalfHeight = collision.collider.bounds.size.y * 0.5f;

                Vector2 newVelocity = BallBounce.PaddleBounce(this.transform.position, paddlePosition, paddleHalfHeight, _bounceModifier.BounceFactor);

                _ballMovement.IncreaseHitCounter();

                _ballMovement.MoveBall(newVelocity);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Vector2 newVelocity = new Vector2(0, 0);

            if (collision.gameObject.TryGetComponent<TopWallTag>(out _))
            {
                AudioEvents.RaisePlaySFX(SFXType.BallBounce);
                newVelocity = BallBounce.WallBounce(_ballMovement.PreviousVelocity, Vector2.up);
            }
            else if (collision.gameObject.TryGetComponent<BottomWallTag>(out _))
            {
                AudioEvents.RaisePlaySFX(SFXType.BallBounce);
                newVelocity = BallBounce.WallBounce(_ballMovement.PreviousVelocity, Vector2.down);
            }

            _ballMovement.MoveBall(newVelocity);           
        }
               

    }
}


