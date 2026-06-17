using UnityEngine;
using UnityEngine.UI;

namespace UserInterfaces
{

    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image gaugeImage;
        [SerializeField] private Image differenceGaugeImage;
        [SerializeField] private float differenceSpeed;

        private float currentDifference;
        private int maxHealth;
        private int currentHealth;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            currentDifference = Mathf.Lerp(currentHealth, currentDifference, Mathf.Exp(-differenceSpeed * Time.deltaTime));
            if(Mathf.Abs(currentDifference - currentHealth) < 1.0f)
            {
                currentDifference = currentHealth;
            }
            UpdateGauge();
        }

        public void Initialize(int newHealth, int newMaxHealth)
        {
            currentHealth = newHealth;
            maxHealth = newMaxHealth;
            currentDifference = newHealth;
        }

        public void UpdateHealth(int newHealth)
        {
            currentHealth = newHealth;
            gaugeImage.fillAmount = (float)newHealth / maxHealth;
        }

        private void UpdateGauge()
        {
            differenceGaugeImage.fillAmount = (float)currentDifference / maxHealth;
        }
    }
}
