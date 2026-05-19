using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] PlayerHealth _playerHealth;

    TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if (_playerHealth == null) return;
        _playerHealth.OnHealthChanged += UpdateText;
        UpdateText(_playerHealth.Health);
    }

    void OnDestroy()
    {
        if (_playerHealth != null)
            _playerHealth.OnHealthChanged -= UpdateText;
    }

    void UpdateText(int health)
    {
        _text.text = $"Vida: {health}";
    }
}
