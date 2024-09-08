using System;
using UnityEngine;

namespace Stars
{
	public class StarsCollect : MonoBehaviour
	{
		[HideInInspector]
		public static Action<GameObject, bool> starCollected;
		private GameObject star;
		private StarsRotating starsRotating;

		public void Init(GameObject star, StarsRotating starsRotating)
		{
			this.starsRotating = starsRotating;
			this.star = star;	
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				StarCollect();
			}
		}

		public void StarCollect()
		{
			starCollected?.Invoke(gameObject, true);
			gameObject.SetActive(false);
			starsRotating.StopRotation();
		}
	}
}