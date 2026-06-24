using System.Collections;
using UnityEngine;

namespace _Debug
{

    public class UseSkill : MonoBehaviour
    {
        [SerializeField] private UserInterfaces.SkillChargeDisplay skillChargeDisplay;
        [SerializeField] private float waitTime;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            StartCoroutine(InternalRoutine());
            IEnumerator InternalRoutine()
            {
                while(true)
                {
                    skillChargeDisplay.ReadyToUse();
                    yield return new WaitForSeconds(1.0f);
                    skillChargeDisplay.StartCooldown(waitTime);
                    yield return new WaitForSeconds(waitTime);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
