using UnityEngine;

using Pong.Tags;

namespace Pong.Ball
{
    public class BallCollision : MonoBehaviour
    {
        [SerializeField] private float _ballMaxAngle;
        [SerializeField] private BounceModifier _bounceModifier;
        [SerializeField] private BallMovement _ballMovement;       

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 newVelocity;

            if (collision.gameObject.TryGetComponent<PaddleTag>(out _))
            {
                float paddleCenter = collision.transform.position.y;
                float paddleHalfHeight = collision.collider.bounds.size.y * 0.5f;
                ContactPoint2D contact = collision.GetContact(0);

                newVelocity = BallBounce.PaddleBounce(contact.point, paddleCenter, paddleHalfHeight, _ballMaxAngle, _ballMovement.PreviousVelocity);

                _ballMovement.IncreaseHitCounter();

                _ballMovement.MoveBall(newVelocity);
            }
            else if (collision.gameObject.TryGetComponent<WallTag>(out _))
            {
                ContactPoint2D contact = collision.GetContact(0);

                newVelocity = BallBounce.WallBounce(_ballMovement.PreviousVelocity, contact.normal);
                _ballMovement.MoveBall(newVelocity);
            }
        }
    }
}


