using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        public Controls controls;
        public Vector2 moveInput { get; private set; }

        public PlayerInput()
        {
            controls = new Controls();

            controls.Movements.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            controls.Movements.Move.canceled += ctx => moveInput = Vector2.zero;

            controls.Enable();
        }
    }
}