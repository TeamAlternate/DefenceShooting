using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public virtual void OnSummon(Vector3 position)
    {
        this.transform.position = position;
    }


    public virtual void OnDamaged(int damage)
    {

    }
}
