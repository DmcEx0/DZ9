using UnityEngine;

public class Player : MonoBehaviour
{
    private int _minHealthPoint = 0;
    private int _maxHealthPoint = 100;
    public float HealthPoint { get; private set; }

    private void Awake()
    {
        HealthPoint = Random.Range(_minHealthPoint, _maxHealthPoint);
    }

    private void ChangeHealth(float targetValue)
    {
        HealthPoint += targetValue;
    }

    public void Heal()
    {
        float value = 10;
        if (HealthPoint < _maxHealthPoint)
            ChangeHealth(value);
    }

    public void Damage()
    {
        float value = -10;
        if (HealthPoint > _minHealthPoint)
            ChangeHealth(value);
    }
}
