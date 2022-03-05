using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private Image image;
    

    private void Start()
    {
        image = GetComponent<Image>();
    }
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
        StartCoroutine(Flashing());
    }
    public IEnumerator Flashing()// корутина для изменения цвета healthBar // почему она на старте игры начинает работать? как это исправить?
    {        
        for (float i = 0; i < 1; i += Time.deltaTime)
        {           
            image.color = Color.Lerp(image.color, Color.red, i);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            image.color = Color.Lerp(image.color, Color.green, i);
            yield return null;
        }

    }

}
