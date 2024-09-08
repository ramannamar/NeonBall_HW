using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI.WinPanel
{
	public class WinPanelStarsAnimation : MonoBehaviour
	{
		public Sprite starSprite;
		public Transform starContainer;
		public float animationDelay = 0.3f;

		[SerializeField] private GridLayoutGroup gridLayoutGroup;

		public IEnumerator ActivateStarsWithAnimation(int starsToActivate)
		{
			yield return new WaitForSeconds(1f);

			for (int i = 0; i < starsToActivate; i++)
			{
				GameObject starObject = new GameObject("Star", typeof(Image));
				starObject.transform.SetParent(starContainer, false);

				Image starImage = starObject.GetComponent<Image>();
				starImage.sprite = starSprite;

				starObject.transform.localScale = Vector3.zero;
				starObject.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

				yield return new WaitForSeconds(animationDelay);
			}
		}

		private void OnDestroy()
		{
			DOTween.KillAll();
		}
	}
}