using System;
using UnityEngine;
using UnityEngine.Events;

public sealed class HealthComponent : MonoBehaviour
{
    public Action<int> OnHealthChanged;
    public event UnityAction<float> HealthChanged;

    public Action OnDead;

    
    public int Health
    {
        get => health;
    }

    public bool IsDead
    {
        get => isDead;
    }
    
    [SerializeField]
    private int health;

    [SerializeField]
    private bool isDead;
    private void Start()
    {
        HealthChanged?.Invoke(health);
    }
    public void ApplyDamage(int damage)
    {
        health -= damage;
        HealthChanged?.Invoke(health);
        if (health <= 0)
        {
            isDead = true;
            health = 0;
            OnDead?.Invoke();
        }

        OnHealthChanged?.Invoke(health);
    }

    public void ApplyDamage(AttackComponent attackComponent)
    {
        health -= attackComponent.Damage;
        HealthChanged?.Invoke(health);
        if (health <= 0)
        {
            isDead = true;
            health = 0;
            OnDead?.Invoke();
        }

        OnHealthChanged?.Invoke(health);
    }
}