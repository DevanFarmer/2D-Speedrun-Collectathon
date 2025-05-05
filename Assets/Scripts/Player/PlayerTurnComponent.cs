using EventBusEventData;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurnComponent : MonoBehaviour
{
    [SerializeField] float rotationStrength;

    public enum RotationType { Smooth, Instant }

    [SerializeField] RotationType rotationType;

    Rigidbody2D rb;

    float rotateInput;

    bool canRotate;

    int direction;

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

        direction = 1;
    }

    void Update()
    {
        if (rotationType == RotationType.Smooth)
        {
            HandleSmoothInput();
        }
        else
            HandleInstantInput();
    }

    private void FixedUpdate()
    {
        if (!canRotate) return;
        if (rotationType == RotationType.Smooth) ApplySmoothRotation();
    }

    void ApplySmoothRotation()
    {
        rb.MoveRotation(rb.rotation + (rotateInput * direction) * rotationStrength * Time.fixedDeltaTime);
    }

    void ApplyInstantRotation(int modifier)
    {
        rb.MoveRotation(rb.rotation + rotationStrength * modifier * direction);
    }

    void HandleSmoothInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotateInput = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotateInput = -1f;
        }
        else
            rotateInput = 0f;
    }

    void HandleInstantInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ApplyInstantRotation(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ApplyInstantRotation(-1);
        }
    }

    void OnPauseChange(PauseChangeEvent e)
    {
        if (e.IsPaused) canRotate = false;
        else canRotate = true;
    }

    public void ReverseControls()
    {
        direction *= -1;
    }
}
