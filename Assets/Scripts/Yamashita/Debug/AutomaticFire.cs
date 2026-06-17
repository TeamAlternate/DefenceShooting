using UnityEngine;

namespace Debug
{

    public class AutomaticFire : MonoBehaviour
    {
        [SerializeField] private UserInterfaces.AmmoRemainingsDisplay ammoDisplay;
        [SerializeField] private float fireChance;
        [SerializeField] private int initialAmmoCount;

        private int currentAmmoCount;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            currentAmmoCount = initialAmmoCount;
            ammoDisplay.UpdateCount(initialAmmoCount);
        }

        // Update is called once per frame
        void Update()
        {
            if(Random.value < fireChance)
            {
                currentAmmoCount--;                
                if(currentAmmoCount == 0)
                {
                    currentAmmoCount = initialAmmoCount;
                }
                ammoDisplay.UpdateCount(currentAmmoCount);
            }
        }
    }
}
