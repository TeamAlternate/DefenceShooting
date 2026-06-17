using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] BulletController bulletControllerPrefab;

    public void GenerateBullet(Vector3 pos, Vector3 move)
    {
        BulletController newBullet = Instantiate(bulletControllerPrefab, this.transform);
        newBullet.Initialize(pos, move, speed);
    }
}
