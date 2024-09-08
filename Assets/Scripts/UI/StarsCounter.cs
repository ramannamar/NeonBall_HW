using Stars;
using TMPro;
using UnityEngine;

namespace UI
{
	public class StarsCounter : MonoBehaviour
	{
		[SerializeField] private TMP_Text starCounterText;
        private int starCount = 0;

        private void OnEnable()
        {
            StarsCollect.starCollected += OnStarCollected;
        }

        private void OnDisable()
        {
            StarsCollect.starCollected -= OnStarCollected;
        }

        private void OnStarCollected(GameObject star, bool collected)
        {
            if (collected)
            {
                starCount++;
                UpdateStarCounterText();
            }
        }

        private void UpdateStarCounterText()
        {
			starCounterText.text = starCount.ToString();
        }
    }
}

