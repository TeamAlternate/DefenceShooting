using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UserInterfaces
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private float increaseRate;
        [SerializeField] private string textFormat = "N0";

        private int currentScore;
        private int targetScore;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            currentScore = 0;
            targetScore = 0;
            UpdateText();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (currentScore == targetScore)
            {
                return;
            }
            currentScore += Mathf.Min((targetScore - currentScore), +10);
            UpdateText();
        }

        public void UpdateScore(int newScore)
        {
            targetScore = newScore;
        }

        private void UpdateText()
        {
            scoreText.text = currentScore.ToString(textFormat);
        }
    }
}
