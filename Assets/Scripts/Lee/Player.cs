using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform childTransform;
    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private float angle;
    [SerializeField] private float range;

    private void Awake()
    {
        // 初期化
        childTransform = transform.GetChild(0).GetComponent<Transform>();
        angle = 0.0f;
        range = 3.0f;
    }

    private void Update()
    {
        CalculateAngle();
        Attack();
    }

    // barrierとPlayerの角度を計算します。
    private void CalculateAngle()
    {
        Vector2 v2 = transform.localPosition - childTransform.localPosition;
        angle = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
    }

    private void Attack()
    {
        if (!shotPrefab)
        {
            Debug.Log("Shot Prefabが無いです");
            return;
        }

        // キーを押したらShot生成
        if(Input.GetKeyDown(KeyCode.Space))
        {

           Instantiate(shotPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, angle));
        }
    }

}
