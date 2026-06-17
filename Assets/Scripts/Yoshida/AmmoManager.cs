using JetBrains.Annotations;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private BulletController bulletControllerPrefab;

    private int remainingAmmo = 20;

    public bool GenerateBullet(Vector3 pos, Vector3 move)
    {
        bool canGenerate = remainingAmmo > 0;
        if (canGenerate)
        {
            BulletController newBullet = Instantiate(bulletControllerPrefab, this.transform);
            newBullet.Initialize(pos, move, speed);
            remainingAmmo--;
        }

        return canGenerate;
    }

    public void ReloadAmmo(int ammo)
    {
        remainingAmmo += ammo;
    }
}
