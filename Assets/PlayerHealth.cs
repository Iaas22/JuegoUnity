using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;

    public int Health { get; private set; }
    public int MaxHealth => _maxHealth;
    public Action<int> OnHealthChanged;

    Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
        Health = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Health = Mathf.Max(0, Health - amount);
        OnHealthChanged?.Invoke(Health);

        if (Health <= 0)
            Die();
    }

    void Die()
    {
        Health = _maxHealth;
        transform.position = _startPosition;
        OnHealthChanged?.Invoke(Health);
    }
}
