using UnityEngine;

namespace Enviroment
{
	public class PanelMove : MonoBehaviour
	{
		[SerializeField] private float moveDistance = 2.0f;
		[SerializeField] private float moveDuration = 1.0f;

		private Vector3 initialPosition;
		private float targetY;
		private float elapsedTime;
		private bool movingUp = true;

		void Start()
		{
			initialPosition = transform.position;
			targetY = initialPosition.y + moveDistance;
		}

		void FixedUpdate()
		{
			elapsedTime += Time.fixedDeltaTime;
			float t = elapsedTime / moveDuration;

			float newY = movingUp ? Mathf.Lerp(initialPosition.y, targetY, t) : Mathf.Lerp(targetY, initialPosition.y, t);
			transform.position = new Vector3(transform.position.x, newY, transform.position.z);

			if (t >= 1.0f)
			{
				movingUp = !movingUp;
				elapsedTime = 0f;
			}
		}
	}
}
