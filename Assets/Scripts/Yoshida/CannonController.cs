using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private BulletManager bulletManagerPrefab;
    [SerializeField] private KeyCode attackKey;

    private Transform childTransform;
    private BulletManager bulletManagerGameObject;
    
    private void Awake()
    {
        childTransform = transform.GetChild(0).GetComponent<Transform>();
        bulletManagerGameObject = Instantiate(bulletManagerPrefab);
    }

    void Update()
    {
        bool isAttackInput = Input.GetKeyDown(attackKey);
        if(isAttackInput)
        {
            Attack();
        }
    }

    void Attack()
    {
        bool isNull = childTransform == null;

        if(!isNull)
        {
            Vector3 pos = childTransform.localPosition;
            Vector3 moveVector = new Vector3(pos.x, pos.y);

            bulletManagerGameObject.GenerateBullet(pos, moveVector);
        }
    }
}
