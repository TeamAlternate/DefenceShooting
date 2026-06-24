using UnityEngine;
using UserInterfaces;

public class CannonController : MonoBehaviour
{
    [SerializeField] private AmmoManager ammoManagerPrefab;
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode reloadKey;
    [SerializeField] private int reloadAmmo = 20;
    [SerializeField] private int needToReload = 30;
    [SerializeField] private UserInterfaces.ReloadProgressDisplay reloadProgressDisplayPrefab;

    private Transform childTransform;
    private AmmoManager ammoManagerGameObject;
    private bool canReload = false;
    private int buttonDownCount = 0;
    
    private void Awake()
    {
        childTransform = transform.GetChild(0).GetComponent<Transform>();
        ammoManagerGameObject = Instantiate(ammoManagerPrefab);
        ammoManagerGameObject.ReloadAmmo(reloadAmmo);
    }

    void Update()
    {
        bool isAttackInput = Input.GetKeyDown(attackKey);
        if(isAttackInput)
        {
            Attack();
        }

        bool isReloadInput = Input.GetKeyDown(reloadKey) && canReload;
        if(isReloadInput)
        {
            buttonDownCount++;
            
            float percent = (float)buttonDownCount / (float)needToReload;
            reloadProgressDisplayPrefab.UpdateProgress(percent);

            bool canReload = buttonDownCount >= needToReload;
            if( canReload )
            {
                ReloadAmmo();
                reloadProgressDisplayPrefab.DoneReload();
                buttonDownCount = 0;
            }
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
            if(canReload)
            {
                reloadProgressDisplayPrefab.StartReload(); 
            }
        }
    }

    private void ReloadAmmo()
    {
        ammoManagerGameObject.ReloadAmmo(reloadAmmo);
    }
}
