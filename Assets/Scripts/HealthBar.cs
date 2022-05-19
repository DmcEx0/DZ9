using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private Coroutine _changeValue;

    private void OnEnable()
    {
        _player.ChangeHealth += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= OnChangeHealth;
    }

    private void OnChangeHealth(int value)
    {
        if (_changeValue != null)
            StopCoroutine(_changeValue);
        _changeValue = StartCoroutine(ChangeHealth(value));
    }

    private IEnumerator ChangeHealth(int value)
    {
        float maxDelta = 2f;

        while (_slider.value != (float)value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value / 100f, maxDelta * Time.deltaTime);

            yield return null;
        }
    }
}
