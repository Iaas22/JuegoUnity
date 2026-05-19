using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if (CoinManager.Instance == null) return;
        CoinManager.Instance.OnCoinChanged += UpdateText;
        UpdateText(CoinManager.Instance.Amount);
    }

    private void OnDestroy()
    {
        if (CoinManager.Instance != null)
            CoinManager.Instance.OnCoinChanged -= UpdateText;
    }

    void UpdateText(int amount)
    {
        _text.text = $"Monedes: {amount}";
    }
}
