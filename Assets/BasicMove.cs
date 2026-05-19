using UnityEngine;
using UnityEngine.InputSystem;

public class BasicMove : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float velocity = 2f;
    [SerializeField] float jumpForce = 5f;
    Vector2 input;
    private CheckGround _checkGround;

    void Start()
    {
        TryGetComponent<Rigidbody2D>(out body);
        _checkGround = GetComponentInChildren<CheckGround>();
    }

    private void FixedUpdate()
    {
        body.linearVelocity = new Vector2(input.x * velocity, body.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (body == null) { return; }
        input = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (_checkGround.isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}