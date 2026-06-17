using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected float delayMultiplier;
    protected float delayDuration;

    protected virtual void Update()
    {
        delayDuration -= Time.deltaTime;
    }

    public virtual void OnSummon(Vector3 position)
    {
        this.transform.position = position;
    }


    public virtual void OnDamaged(int damage)
    {

    }

    public void GainDelay(float multiplier, float duration)
    {
        delayMultiplier = multiplier;
        delayDuration = Mathf.Max(duration, delayDuration);
    }

    protected bool HasDelay()
    {
        return delayDuration > 0.0f;
    }
}
