using UnityEngine;

public class PlayerTurnComponent : MonoBehaviour
{
    [SerializeField] float rotationStrength;

    Rigidbody2D rb;

    float rotateInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
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

    private void FixedUpdate()
    {
        ApplyRotation();
    }

    void ApplyRotation()
    {
        rb.MoveRotation(rb.rotation + rotateInput * rotationStrength * Time.fixedDeltaTime);
    }
}
