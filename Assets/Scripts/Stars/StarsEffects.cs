using System.Collections;
using UnityEngine;

namespace Stars
{
	public class StarsEffects : MonoBehaviour
	{
		[SerializeField] private GameObject effect;
		[SerializeField] private Transform container;
		private ObjectPool<GameObject> effectPool;

		private void Start()
		{		
			effectPool = new ObjectPool<GameObject>(
			  prewarmCount: 2,
			  constructor: () => Instantiate(effect, container),
			  postPush: effectInstance => effectInstance.SetActive(false),
			  prePop: effectInstance => effectInstance.SetActive(true)
			);
		}
		
		private void OnEnable()
		{
			StarsCollect.starCollected += OnStarCollected;
		}
		
		private void OnDisable() 
		{
			StarsCollect.starCollected -= OnStarCollected;
		}
		
		public void OnStarCollected(GameObject star, bool collected)
		{
			if (collected)
			{
				var effectInstance = effectPool.Pop();
				effectInstance.transform.position = star.transform.position;
				effectInstance.SetActive(true);

				StartCoroutine(ReturnEffectToPool(effectInstance, 2f));
			}
		}

		private IEnumerator ReturnEffectToPool(GameObject effectInstance, float delay)
		{
			yield return new WaitForSeconds(delay);
			effectPool.Push(effectInstance);
		}
	}
}