using System;
using UnityEngine;
using UnityEngine.Events;

public sealed class HealthComponent : MonoBehaviour
{
    [SerializeField] private string playSoundHit;
    [SerializeField] private string playSoundDie;
    [SerializeField] private PlaySound _playSoundHitAndDie;
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

    [SerializeField] private GameObject _damageEffect;
    private void Start()
    {
        HealthChanged?.Invoke(health);
    }
    public void ApplyDamage(int damage)
    {
        health -= damage;
        

        HealthChanged?.Invoke(health);
        _playSoundHitAndDie.PlaySoundEffect(playSoundHit);
        ShowDamageEffect();
        if (health <= 0)
        {
            _playSoundHitAndDie.PlaySoundEffect(playSoundDie);
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

    public void ShowDamageEffect()
    {
        if (!_damageEffect) return;
        
        foreach (var effect in _damageEffect.GetComponentsInChildren<ParticleSystem>())
        {
            effect.Play();
        }
    }
}