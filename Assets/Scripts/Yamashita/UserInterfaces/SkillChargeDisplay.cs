using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterfaces
{

    public class SkillChargeDisplay : MonoBehaviour
    {
        [SerializeField] private Image cooldownGauge;

        private float cooldownTime;
        private float currentCooldown;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            currentCooldown -= Time.deltaTime;
            cooldownGauge.fillAmount = currentCooldown / cooldownTime;
        }

        public void StartCooldown(float cooldownTime)
        {
            this.cooldownTime = cooldownTime;
            currentCooldown = cooldownTime;
        }

        public void ReadyToUse()
        {

        }
    }
}
