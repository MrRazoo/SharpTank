using UnityEngine;
using UnityEngine.Events;


public class TankMover : MonoBehaviour
{
    public UnityEvent<float> OnChangeSpeed = new UnityEvent<float>();
    public TankMoverData tankMoverData;
    private Rigidbody2D rb;
    private Vector2 movementVector;
    
    
    public float currentSpeed = 0;
    public float currentForwardDirection = 1;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    public void MoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        OnChangeSpeed?.Invoke(this.movementVector.magnitude);
        if(movementVector.y > 0) // to get correct direction
        {
            currentForwardDirection = 1;
        }
        else if(movementVector.y < 0)
        {
            currentForwardDirection = -1;
        }
    }

    private void CalculateSpeed(Vector2 movementVectors)
    {
        if(Mathf.Abs(movementVectors.y) > 0) // use Absolute to add direction in both sides
        {
            currentSpeed += tankMoverData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= tankMoverData.deceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, tankMoverData.speed);
    }

    private void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * currentSpeed * currentForwardDirection * Time.fixedDeltaTime; // calculations.
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * tankMoverData.rotationSpeed * Time.fixedDeltaTime));
    }
}