using Enviroment;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		
		[SerializeField] GameObject joystick;

		private PlayerInput playerInput;
		private PlayerMovements playerMovements;
		private Rigidbody _rigidbody;
		[SerializeField] private GameOverPanel gameOverPanel;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			playerInput = new PlayerInput();
			playerMovements = new PlayerMovements(_rigidbody, moveSpeed);
		}
		
		private void Start()
		{
			gameOverPanel.OnGameOver.AddListener(OnGameOver); 
		}

		private void FixedUpdate()
		{
			Vector2 moveInput = playerInput.moveInput;
			playerMovements.Move(moveInput);
		}
		
		private void OnGameOver()
        {
            DisableJoystick();
        }
		
		private void DisableJoystick()
		{  
			joystick.SetActive(false);
		}
	}
}