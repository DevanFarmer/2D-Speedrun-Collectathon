using EventBusEventData;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField] float currentSpeed;

    [Header("Speed Values")]
    [SerializeField] bool canChangeSpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float boostSpeed;
    [SerializeField] float slowDownSpeed;

    [Header("Speed Modifier")]
    [SerializeField] float speedModifier;

    [Header("Enable/Disable Movement")]
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

        currentSpeed = normalSpeed;
    }

    private void Update()
    {
        if (!canMove) return;
        HandleInput();
    }

    void FixedUpdate()
    {
        if (!canMove) return;
        MoveForward();
    }

    void MoveForward()
    {
        rb.MovePosition(transform.position + transform.up * (currentSpeed + speedModifier) * Time.fixedDeltaTime);
    }

    void OnPauseChange(PauseChangeEvent e)
    {
        if (e.IsPaused) canMove = false;
        else canMove = true;
    }

    void HandleInput()
    {
        if (!canChangeSpeed) return;

        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = slowDownSpeed;
        }
        else
            currentSpeed = normalSpeed;
    }

    public void AlterSpeedModifier(float speedValue)
    {
        speedModifier += speedValue;
    }
}
