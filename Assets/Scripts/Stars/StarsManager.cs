using UnityEngine;

namespace Stars
{
	public class StarsManager : MonoBehaviour
	{
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private GameObject[] stars;

		private StarsRotating[] starsRotatings;

		private void Start()
		{
			starsRotatings = new StarsRotating[stars.Length];

			for (int i = 0; i < stars.Length; i++)
			{
				starsRotatings[i] = new StarsRotating(stars[i], _rotationSpeed);
				starsRotatings[i].StartRotation();

				var starsCollect = stars[i].AddComponent<StarsCollect>();
				starsCollect.Init(stars[i], starsRotatings[i]);
			}
		}

		void OnDisable()
		{
			foreach (var starsRotating in starsRotatings)
				starsRotating.Destroy();
		}
	}
}