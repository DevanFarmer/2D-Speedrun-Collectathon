using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] RotationDirection direction;
    int directionValue;

    public enum RotationDirection
    {
        None,
        Left,
        Right
    }

    void Update()
    {
        HandleDirection();
        transform.Rotate(0, 0, directionValue * rotationSpeed * Time.deltaTime);
    }

    void HandleDirection()
    {
        switch (direction)
        {
            case RotationDirection.Left:
                directionValue = 1; 
                break;
            case RotationDirection.Right:
                directionValue = -1; 
                break;
            default:
                directionValue = 0; break;
        }
    }
}
