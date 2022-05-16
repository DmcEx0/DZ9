using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float HealthPoint { get; private set; }
    private Coroutine _changeValue;

    private void Start()
    {
        HealthPoint = Random.Range(0, 100);
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        float targetHp = HealthPoint + targetValue;

        while (true)
        {
            HealthPoint = Mathf.MoveTowards(HealthPoint, targetHp, 10 * Time.deltaTime);

            yield return null;
        }
    }

    public void Heal()
    {
        float value = 10;
        int maxHealthPoint = 100;

        if (HealthPoint <= maxHealthPoint)
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

        if (HealthPoint >= minHealthPoint)
        {
            if (_changeValue != null)
                StopCoroutine(_changeValue);
            _changeValue = StartCoroutine(ChangeValue(value));
        }
    }
}
