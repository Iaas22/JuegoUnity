using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyEnemyAI : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _stompBounce = 6f;

    Rigidbody2D _body;
    Transform _player;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _body.bodyType = RigidbodyType2D.Kinematic;
        _body.gravityScale = 0f;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            _player = playerObj.transform;
    }

    void FixedUpdate()
    {
        if (_player == null) return;

        Vector2 direction = ((Vector2)_player.position - _body.position).normalized;
        _body.MovePosition(_body.position + direction * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D playerBody = other.GetComponent<Rigidbody2D>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        bool stompedFromAbove = playerBody != null
            && playerBody.linearVelocity.y < -1f
            && other.transform.position.y > transform.position.y + 0.2f;

        if (stompedFromAbove)
        {
            if (playerBody != null)
                playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, _stompBounce);
            Destroy(gameObject);
        }
        else
        {
            playerHealth?.TakeDamage(1);
        }
    }
}
