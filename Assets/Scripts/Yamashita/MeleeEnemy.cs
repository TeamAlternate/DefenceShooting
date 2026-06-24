using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MeleeEnemy : EnemyBase
{

    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private int attackPower;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackInterval;
    [SerializeField] private int initialHealth;
    [SerializeField] private GameObject defeatedEffectObjectPrefab;

    private Animator animator;

    private GameObject targetObject;

    private int currentHealth;
    private float attackWaitTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        targetObject = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        if (targetObject == null)
        {
            return;
        }

        if (Vector2.Distance(this.transform.position, targetObject.transform.position) < attackRange)
        {
            attackWaitTime -= Time.deltaTime;
            if (attackWaitTime <= 0.0f)
            {
                animator.Play("Attack");
                attackWaitTime = attackInterval;
            }
            return;
        }
        Vector2 move = targetObject.transform.position - this.transform.position;
        move = move.normalized * baseMoveSpeed * Time.deltaTime;
        if (HasDelay())
        {
            move *= delayMultiplier;
        }
        this.transform.position += (Vector3)move;
        AdjustLayer();
        if (move.x < 0.0f)
        {
            this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            this.transform.localScale = new Vector3(+1.0f, 1.0f, 1.0f);
        }
    }

    public override void OnSummon(Vector3 position)
    {
        base.OnSummon(position);
        this.transform.position = position;
        currentHealth = initialHealth;
        animator.Play("Walk");
    }

    public override void OnDamaged(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        base.OnDamaged(damage);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDefeated();
        }
    }

    public void OnAttack()
    {
        //Debug.Log(attackPower);
        PlayerManager.instance.DecreaseCurrentHP(attackPower);
        PlayerManager.instance.ChangeInvencible(true);
    }

    public void OnDefeated()
    {
        Scenes.MainGameManager.EarnScore(100);
        GameObject newEffect = Instantiate(defeatedEffectObjectPrefab);
        newEffect.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

    private void AdjustLayer()
    {
        Vector3 prevPosition = this.transform.position;
        prevPosition.z = prevPosition.y;
        this.transform.position = prevPosition;
    }


}
