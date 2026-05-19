using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    [SerializeField] float _patrolDistance = 3f;
    [SerializeField] float _stompBounce = 6f;

    Rigidbody2D _body;
    Vector2 _startPos;
    int _direction = 1;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }

    void FixedUpdate()
    {
        float distanceTraveled = transform.position.x - _startPos.x;

        if (distanceTraveled >= _patrolDistance)
            _direction = -1;
        else if (distanceTraveled <= -_patrolDistance)
            _direction = 1;

        _body.linearVelocity = new Vector2(_direction * _speed, _body.linearVelocity.y);
        transform.localScale = new Vector3(_direction, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Rigidbody2D playerBody = collision.rigidbody;
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerBody != null && playerBody.linearVelocity.y < -0.5f)
        {
            playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, _stompBounce);
            Destroy(gameObject);
        }
        else
        {
            playerHealth?.TakeDamage(1);
        }
    }
}
