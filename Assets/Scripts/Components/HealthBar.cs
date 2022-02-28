using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private Image image;

    private void OnEnable()
    {
        _healthComponent.HealthChanged += OnHealthChange;
    }
    private void OnDisable()
    {
        _healthComponent.HealthChanged -= OnHealthChange;
    }

    private void OnHealthChange(float value)
    {
        image.fillAmount = value*0.1f;
    }

}
