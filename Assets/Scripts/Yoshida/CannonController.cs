using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private AmmoManager ammoManagerPrefab;
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode reloadKey;
    [SerializeField] private int reloadAmmo = 20;

    private Transform childTransform;
    private AmmoManager ammoManagerGameObject;
    private bool canReload = false;
    
    private void Awake()
    {
        childTransform = transform.GetChild(0).GetComponent<Transform>();
        ammoManagerGameObject = Instantiate(ammoManagerPrefab);
    }

    void Update()
    {
        bool isAttackInput = Input.GetKeyDown(attackKey);
        if(isAttackInput)
        {
            Attack();
        }

        bool isReloadInput = Input.GetKeyDown(reloadKey);
        if(isReloadInput)
        {
            ReloadAmmo();
        }
    }

    private void Attack()
    {
        bool isNull = childTransform == null;

        if(!isNull)
        {
            Vector3 pos = childTransform.localPosition;
            Vector3 moveVector = new Vector3(pos.x, pos.y);

            canReload = !ammoManagerGameObject.GenerateBullet(pos, moveVector);
        }
    }

    private void ReloadAmmo()
    {
        if(canReload)
        {
            ammoManagerGameObject.ReloadAmmo(reloadAmmo);
        }
    }
}
