using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _healthPoint;
    private Coroutine _changeValue;

    private void Start()
    {
        _healthPoint = Random.Range(0, 100);
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        float targetHp = _healthPoint + targetValue;

        while (true)
        {
            _healthPoint = Mathf.MoveTowards(_healthPoint, targetHp, 10 * Time.deltaTime);
            _slider.value = _healthPoint;

            yield return null;
        }
    }

    public void Heal()
    {
        float value = 10;
        int maxHealthPoint = 100;

        if (_healthPoint <= maxHealthPoint)
        {
            if (_changeValue != null)
                StopCoroutine(_changeValue);
            _changeValue = StartCoroutine(ChangeValue(value));
        }
    }

    public void Damage()
    {
        float value = -10;
        int minHealthPoint = 0;

        if (_healthPoint >= minHealthPoint)
        {
            if (_changeValue != null)
                StopCoroutine(_changeValue);
            _changeValue = StartCoroutine(ChangeValue(value));
        }
    }
}
