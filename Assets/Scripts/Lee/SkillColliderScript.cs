using UnityEngine;

public class SkillColliderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MeleeEnemy>(out var targetStat))
        {
            targetStat.OnDamaged(500);
        }
    }

}
