using EventBusEventData;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed;

    [SerializeField] bool canMove;

    private void OnEnable()
    {
        EventBus.Subscribe<PauseChangeEvent>(OnPauseChange);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PauseChangeEvent>(OnPauseChange);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        if (!canMove) return;
        MoveForward();
    }

    void MoveForward()
    {
        rb.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
    }

    void OnPauseChange(PauseChangeEvent e)
    {
        if (e.IsPaused) canMove = false;
        else canMove = true;
    }
}
