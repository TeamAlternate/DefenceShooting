using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 25.0f;
    [SerializeField] private int damage = 100;
    private float speed = 0.0f;
    private Vector3 moveVector = Vector3.zero;

    public void Initialize(Vector3 pos, Vector3 move, float speed)
    {
        transform.position = pos;
        moveVector = move;
        this.speed = speed;
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

        RoRateSprite();
    }

    private void RoRateSprite()
    {
        Vector3 add = Vector3.zero;
        add.z += rotateSpeed;

        this.transform.Rotate(add);
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
        Destroy(this.gameObject);
    }
}
