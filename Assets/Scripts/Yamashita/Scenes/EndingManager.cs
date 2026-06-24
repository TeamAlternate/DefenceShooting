using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{

    public class EndingManager : MonoBehaviour
    {
        private static int recentScore;

        [SerializeField] private string nextSceneName;
        [SerializeField] private UserInterfaces.ScoreDisplay scoreDisplay;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            scoreDisplay.UpdateScore(recentScore);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                LoadNextScene();
            }
        }

        public void LoadNextScene()
        {
                SceneManager.LoadScene(nextSceneName);
        }

        public static void SendScore(int newScore)
        {
            recentScore = newScore;
        }
    }
}
