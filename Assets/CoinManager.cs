using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get { return _instance; } }
    private static CoinManager _instance;

    public int Amount { get; private set; }
    public Action<int> OnCoinChanged;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    public static void AddCoin(int value)
    {
        if (_instance == null) return;
        _instance.Amount += value;
        _instance.OnCoinChanged?.Invoke(_instance.Amount);
    }
}
