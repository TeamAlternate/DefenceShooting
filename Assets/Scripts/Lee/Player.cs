using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string monsterTag;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float blinkSpeed = 2f;
    private bool wasInvincible = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        BlinkMode();
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
