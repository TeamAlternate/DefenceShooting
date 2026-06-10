using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
