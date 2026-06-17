using UnityEngine;

namespace _Debug
{

    public class RandomHealth : MonoBehaviour
    {
        [SerializeField] private UserInterfaces.HealthBar healthBar;
        [SerializeField] private int maxHealth;
        [SerializeField] private float changeChance;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            healthBar.Initialize(maxHealth, maxHealth);
        }

        // Update is called once per frame
        void Update()
        {
            if (Random.value < changeChance)
            {
                healthBar.UpdateHealth(Random.Range(0, maxHealth + 1));
            }
        }
    }
}
