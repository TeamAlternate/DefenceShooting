using UnityEngine;

// 指定秒数でプレイヤーの周りを回る
public class BarrierScript : MonoBehaviour
{
    private const float LAP_ANGLE = 360.0f;
    private const float SPRITE_ANGLE = -90.0f;

    private Transform childTransform;
    [SerializeField] private float radius = 3.0f;
    [SerializeField] private float lapTime = 2.0f;

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
        if (!childTransform)
        {
            Debug.Log("Child Transformが無いです。");
            return;
        }

        Vector3 currentPos = childTransform.localPosition;

        float angle = Mathf.Atan2(currentPos.y, currentPos.x);
        angle -= Mathf.Deg2Rad * ((LAP_ANGLE * Time.deltaTime) / lapTime);

        RotateTransform(angle * Mathf.Rad2Deg);

        Vector3 newPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        childTransform.localPosition = newPosition;
    }

    private void RotateTransform(float degree)
    {
        Quaternion rotation = childTransform.localRotation;

        Vector3 newRotation = Vector3.zero;
        newRotation.z = degree + SPRITE_ANGLE;

        childTransform.localRotation = Quaternion.Euler(newRotation);
    }
}
