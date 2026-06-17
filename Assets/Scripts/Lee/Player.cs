using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 実際のモンスターのTagと合わせて使う
    [SerializeField] private string monsterTag;

    // Blink
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float blinkSpeed = 2f;
    private bool wasInvincible = false;

    // Skill
    [SerializeField] private GameObject skillCollider;
    private const float maxSkillTime = 30.0f; // スキル活性化
    private float skillTimer = 0.0f;
    private bool canUseSkill = false;

    private const float skillColliderLifeTime = 1.0f; // コライダーActive調整
    private float skillColliderTimer = 0.0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        skillCollider.SetActive(false);
    }

    private void Update()
    {
        BlinkMode();
        AttackWholeMonster();
        CalculateSkillTime();
    }

    private void BlinkMode()
    {
        if (PlayerManager.instance.IsInvincible)
        {
            float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f);
            spriteRenderer.color = new Color(
                originalColor.r,
                originalColor.g,
                originalColor.b,
                alpha
            );

            wasInvincible = true;
        }
        else
        {
            if (wasInvincible)
            {
                spriteRenderer.color = originalColor;
                wasInvincible = false;
            }
        }
    }

    private void AttackWholeMonster()
    {
        if(!canUseSkill)
        {
            Debug.Log("クールタイムが残っています");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            skillCollider.SetActive(true);
            canUseSkill = false;
            skillTimer = 0.0f;
            skillColliderTimer = 0.0f;
        }
  
    }

    private void CalculateSkillTime()
    {
        skillTimer += Time.deltaTime;
        skillColliderTimer += Time.deltaTime;

        if (skillTimer > maxSkillTime)
        {
            canUseSkill = true;
        }

        if (skillColliderTimer > skillColliderLifeTime)
        {
            skillCollider.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == monsterTag)
        {
            //Debug.Log("Monster Attacked");
            PlayerManager.instance.DecreaseCurrentHP(10);
            PlayerManager.instance.ChangeInvencible(true);
        }
    }
}
