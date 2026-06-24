using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class MainGameManager : MonoBehaviour
    {
        private static MainGameManager current;
        private static int score;

        [SerializeField] private string nextSceneName;
        [SerializeField] private UserInterfaces.ScoreDisplay scoreDisplay;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            current = this;
            score = 0;
            scoreDisplay.UpdateScore(score);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                LoadNextScene();
            }
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(nextSceneName);
        }

        public static void EarnScore(int addScore)
        {
            score += addScore;
            current.scoreDisplay.UpdateScore(score);
        }
    }
}
