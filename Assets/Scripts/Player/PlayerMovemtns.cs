using UnityEngine;

namespace Player
{
    public class PlayerMovements
    {
        private Rigidbody rigidbody;
        private float moveSpeed;

        public PlayerMovements(Rigidbody rigidbody, float moveSpeed)
        {
            this.rigidbody = rigidbody;
            this.moveSpeed = moveSpeed;
        }

        public void Move(Vector2 moveInput)
        {
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
            rigidbody.AddForce(move * moveSpeed);

            if (moveInput != Vector2.zero)
            {
                Vector3 torque = new Vector3(moveInput.y, 0, -moveInput.x) * moveSpeed;
                rigidbody.AddTorque(torque);
            }
        }
    }
}