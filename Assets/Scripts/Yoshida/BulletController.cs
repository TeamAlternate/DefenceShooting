using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 25.0f;
    [SerializeField] private int damage = 100;
    [SerializeField] private GameObject spriteGameObject;

    private float destroyLifeTime = 1.5f;
    private float speed = 0.0f;
    private Vector3 moveVector = Vector3.zero;

    public void Initialize(Vector3 pos, Vector3 move, float speed)
    {
        transform.position = pos;
        moveVector = move;
        this.speed = speed;

        InitalizeRotate();
    }

    private void FixedUpdate()
    {
        MoveAmmo();
    }

    private void MoveAmmo()
    {
        Vector3 newPosition = this.transform.position;
        newPosition += moveVector * speed * Time.deltaTime;
        
        this.transform.position = newPosition;

        RotateSprite();
    }

    private void RotateSprite()
    {
        Vector3 add = Vector3.zero;
        add.z += rotateSpeed;

        spriteGameObject.transform.Rotate(add);
    }

    private void InitalizeRotate()
    {
        float angle = Vector2.SignedAngle(Vector2.right, moveVector);

        Quaternion rotation = Quaternion.Euler(angle * Vector3.forward);

        this.transform.rotation = rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();
        if(enemy)
        {
            enemy.OnDamaged(damage);
        }
    }

    private void OnBecameInvisible()
    {
        Invoke("BulletDestroy", destroyLifeTime);
    }

    private void BulletDestroy()
    {
        Destroy(this.gameObject);
    }
}
