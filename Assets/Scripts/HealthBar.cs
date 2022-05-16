using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Player _player;

    private void Update()
    {
        _healthBarSlider.value = _player.HealthPoint ; 
    }
}
