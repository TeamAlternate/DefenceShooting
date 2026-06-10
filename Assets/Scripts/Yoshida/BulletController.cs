using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Vector3 moveVector = Vector3.zero;

    public void Initialize(Vector3 move)
    {
        moveVector = move;
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        Vector3 newPosition = this.transform.position;
        newPosition += moveVector;
    }
}
