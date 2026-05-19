using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] int _coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CoinManager.AddCoin(_coinValue);
        gameObject.SetActive(false);
    }
}
