using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private Button _buttonHealth;
    [SerializeField] private int _value;

    private int _minHealth = 0;
    private int _maxHealth = 100;
    private int _healthPoint;

    public UnityAction<int>  ChangeHealth;


    private void OnEnable()
    {
        _buttonDamage?.onClick.AddListener(TakeDamage);
        _buttonHealth?.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _buttonDamage?.onClick.RemoveListener(TakeDamage);
        _buttonHealth?.onClick.RemoveListener(Heal);
    }

    private void Start()
    {
        _healthPoint = Random.Range(_minHealth, _maxHealth);

        ChangeHealth?.Invoke(_healthPoint);
    }

    public void Heal()
    {
        _healthPoint = Mathf.Clamp(_healthPoint+_value, _minHealth, _maxHealth);
        ChangeHealth?.Invoke(_healthPoint);
    }

    public void TakeDamage()
    {
        _healthPoint = Mathf.Clamp(_healthPoint - _value, _minHealth, _maxHealth);
        ChangeHealth?.Invoke(_healthPoint);
    }
}
