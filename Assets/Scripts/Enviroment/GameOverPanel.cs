using UnityEngine;
using UnityEngine.Events;

namespace Enviroment
{
	public class GameOverPanel : MonoBehaviour
	{
		public UnityEvent OnGameOver;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				OnGameOver?.Invoke();
			}
		}
	}
}
