using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    void MoveForward()
    {
        rb.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
    }
}
