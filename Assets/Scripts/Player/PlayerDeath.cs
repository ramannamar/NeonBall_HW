using UnityEngine;

namespace Player
{
	public class PlayerDeath : MonoBehaviour
	{
		[SerializeField] private Transform spawnPoint;
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private TrailRenderer trailRenderer;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("DeadZone"))
			{
				Restart();
			}
		}

		private void Restart()
		{
			transform.position = spawnPoint.position;
			transform.rotation = spawnPoint.rotation;

			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = Vector3.zero;

			trailRenderer.Clear();
		}
	}
}

