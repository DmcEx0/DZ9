using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Player _player;

    private Coroutine _changeValue;

    private void Start()
    {
        _healthBarSlider.value = _player.HealthPoint;
    }

    private IEnumerator ChangeHealth()
    {
        float maxDelta = 200f;

        while (true)
        {
            _healthBarSlider.value = Mathf.MoveTowards(_healthBarSlider.value, _player.HealthPoint, maxDelta * Time.deltaTime);

            yield return null;
        }
    }

    public void OnButtonClick()
    {
        if (_changeValue != null)
            StopCoroutine(_changeValue);
        _changeValue = StartCoroutine(ChangeHealth());
    }
}
