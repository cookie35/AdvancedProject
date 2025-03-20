using System;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);

}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;
    private PlayerController playerController;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;

    public float fallThreshold = 10f;  // 추락 데미지를 받기 시작하는 높이
    public float fallDamageMultiplier = 1f;  // 떨어진 높이에 비례하여 배수로 데미지 설정
    public float maxFallDamage = 100f; // 최대 추락 데미지

    public UiGameOver uiGameOver;
    
    private Rigidbody rigidbody;
    private float fallStartHeight; // 추락 시작 높이
    private bool isFalling; // 추락 중인지 여부


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
        playerController = GetComponent<PlayerController>();
    }


    void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);  // 스태미나 증가 처리

        if (rigidbody.velocity.y < 0 && !isFalling)  // 추락시 데미지 처리
        {
            isFalling = true;
            fallStartHeight = transform.position.y;
        }

        if (isFalling && playerController.IsGrounded())
        {
            float fallHeight = fallStartHeight - transform.position.y;

            if (fallHeight > fallThreshold)
            {
                float damage = Mathf.Min(fallHeight * fallDamageMultiplier, maxFallDamage);

                if (health != null)
                {
                    health.Subtract(damage);
                    CheckForGameOver();  // Hp가 0 이하인지 확인
                }

                if (fallHeight > 50f && uiGameOver != null)
                {
                    HandleGameOver();
                }

            }

            isFalling = false; 
        }

        if (health != null && health.curValue <= 0f)  // HP가 0 이하인지 추가 확인(추락 외 데미지)
        {
            HandleGameOver();
        }

    }

    private void CheckForGameOver()
    {
        if(health != null && health.curValue <= 0f)
        {
            HandleGameOver();
        }
    }

    private void HandleGameOver()
    {
        if(uiGameOver != null)
        {
            uiGameOver.GameOver();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        stamina.Add(amount);
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if(stamina.curValue - amount < 0f)
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }
}
