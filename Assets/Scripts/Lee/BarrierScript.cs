using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    private Transform childTransform;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float radius = 3.0f;

    private void Awake()
    {
        childTransform = transform.GetChild(0).GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        RotateAround();
    }

    private void RotateAround()
    {
        if(!childTransform)
        {
            Debug.Log("Child TransformÇ™ñ≥Ç¢Ç≈Ç∑ÅB");
            return;
        }

        Vector3 currentPos = childTransform.localPosition;

        float angle = Mathf.Atan2(currentPos.y, currentPos.x);
        angle -= Mathf.Deg2Rad * speed;

        Vector3 newPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        childTransform.localPosition = newPosition;
    }
}
