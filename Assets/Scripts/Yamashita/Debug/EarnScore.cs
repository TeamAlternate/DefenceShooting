using UnityEngine;

namespace Debug
{


    public class EarnScore : MonoBehaviour
    {
        [SerializeField] private KeyCode earnKey;
        [SerializeField] private int addScore;
        // [SerializeField] private GameManager manager;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(earnKey))
            {

            }
        }
    }

}