using Scenes;
using System;
using UnityEngine;
using UserInterfaces;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int currentHp;
    private bool isDeath = false;

    private bool isInvincible = false; // –³“G
    public bool IsInvincible => isInvincible;

    private const float maxInvicibleTime = 2.0f;
    private float currentInvicibleTime = 0.0f;

    public GameObject HealthBarObj;
    HealthBar healthBar;

    //public event Action<float, float> OnHPChanged;

    // Single Tone
    public static PlayerManager instance { get; private set; }

    #region Unity Method
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        currentHp = maxHp;
        healthBar = HealthBarObj.GetComponent<HealthBar>();
        healthBar.Initialize(currentHp, maxHp);
    }

    private void Update()
    {
        CalculateInvicibleTime();
        SetOnDeath();
    }
    #endregion

    #region Setter
    public void DecreaseCurrentHP(int value)
    {
        if (isInvincible)
        {
            return;
        }

        currentInvicibleTime = 0.0f;

        currentHp -= value;
        if (currentHp < 0)
        {
            currentHp = 0;
            isDeath = true;
        }

        healthBar.UpdateHealth(currentHp);

        Debug.Log("PlayerHP:" + currentHp);
    }

    public void ChangeInvencible(bool value)
    {
        this.isInvincible = value;
    }

    #endregion

    #region Calculator
    private void CalculateInvicibleTime()
    {
        if (!isInvincible)
        {
            return;
        }

        currentInvicibleTime += Time.deltaTime;

        if (currentInvicibleTime>maxInvicibleTime)
        {
            isInvincible = false;
            currentInvicibleTime = 0.0f;
        }
    }

    #endregion

    #region etc
    private void SetOnDeath()
    {
        if(currentHp >=1)
        {
            return;
        }

        isDeath = true;
        MainGameManager.GameOver();
    }

    #endregion

}
