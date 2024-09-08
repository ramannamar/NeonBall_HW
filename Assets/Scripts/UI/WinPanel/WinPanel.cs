using UnityEngine;
using UnityEngine.UI;
using Stars;
using System.Collections;
using Enviroment;

namespace UI.WinPanel
{
	public class WinPanel : MonoBehaviour
	{
		[SerializeField] private Button restartButton;
		[SerializeField] private Button quitButton;
		[SerializeField] private RectTransform winPanelRectTransform;
		[SerializeField] private GameOverPanel gameOverPanel;
		[SerializeField] private float animationDuration = 1.0f;
		[SerializeField] private WinPanelStarsAnimation winPanelStarsAnimation;

		private int collectedStars = 0;

		private void OnEnable()
		{
			StarsCollect.starCollected += OnStarCollected;
		}
		
		void Start()
		{
			InitializeButtons();
	
			gameOverPanel.OnGameOver.AddListener(OnGameOver);  
			winPanelRectTransform.anchoredPosition = new Vector2(0, Screen.height);
		}

		private void OnDisable()
		{
			StarsCollect.starCollected -= OnStarCollected;
		}

		private void InitializeButtons()
		{
			restartButton.onClick.AddListener(RestartButton.LevelRestart);
			quitButton.onClick.AddListener(QuitButton.QuitGame);
		}

		private void OnStarCollected(GameObject star, bool collected)
		{
			if (collected)
				collectedStars++;
		}

		private void OnGameOver()
		{
			StartCoroutine(ShowWinPanel());
		}

		private IEnumerator ShowWinPanel()
		{
			float elapsedTime = 0;

			Vector2 startPosition = winPanelRectTransform.anchoredPosition;
			Vector2 endPosition = Vector2.zero;

			while (elapsedTime < animationDuration)
			{
				winPanelRectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, (elapsedTime / animationDuration));
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			winPanelRectTransform.anchoredPosition = endPosition;

			StartCoroutine(ActivateStars());
		}

		private IEnumerator ActivateStars()
		{
			int starsToActivate = 0;
			if (collectedStars >= 10)
			{
				starsToActivate = 3;
			}
			else if (collectedStars >= 4)
			{
				starsToActivate = 2;
			}
			else if (collectedStars >= 3)
			{
				starsToActivate = 1;
			}

			yield return winPanelStarsAnimation.ActivateStarsWithAnimation(starsToActivate);
		}
	}
}