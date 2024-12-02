using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement Variables
    public CharacterController controller;
    public float stepDistance = 2f; // Distance to move on key press
    public float stepSpeed = 10f;   
    public float gravity = -9.81f;

    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Rotation Variables for "A" and "D"
    public float rotationAmount = 90f; 
    private bool isRotating = false;   
    private Quaternion targetRotation; // Desired rotation

    private Vector3 targetPosition; // Target position for step movement
    private bool isMoving = false;  // Check if the player is currently stepping

    void Start()
    {
        targetRotation = transform.rotation; 
        targetPosition = transform.position; 
    }

    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Handle Discrete Forward Movement (W)
        if (!isMoving && Input.GetKeyDown(KeyCode.W))
        {
            targetPosition = transform.position - transform.forward * stepDistance; // Move forward
            if (CanMoveTo(targetPosition))
            {
                isMoving = true; // Start moving
            }
        }

        // Handle Discrete Backward Movement (S)
        if (!isMoving && Input.GetKeyDown(KeyCode.S))
        {
            targetPosition = transform.position + transform.forward * stepDistance; // Move backward
            if (CanMoveTo(targetPosition))
            {
                isMoving = true; // Start moving
            }
        }

        
        if (isMoving)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            controller.Move(moveDirection * stepSpeed * Time.deltaTime);

            // Check if the player is close enough to the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f || controller.collisionFlags == CollisionFlags.Sides)
            {
                isMoving = false; // Stop moving
                targetPosition = transform.position; // Reset target position
            }
        }

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Handle "A" and "D" for 90-degree rotation
        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                targetRotation *= Quaternion.Euler(0, -rotationAmount, 0); // Rotate left
                isRotating = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                targetRotation *= Quaternion.Euler(0, rotationAmount, 0); // Rotate right
                isRotating = true;
            }
        }

        // Smoothly rotate towards the target rotation
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, stepSpeed * 50 * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false; // Stop rotating when close to the target
            }
        }
    }

    // Check if the player can move to the target position
    private bool CanMoveTo(Vector3 targetPos)
    {
        // Cast a capsule in the direction of movement to check for obstacles
        if (Physics.CheckCapsule(transform.position, targetPos, controller.radius, groundMask))
        {
            return false; // Block movement if there's an obstacle
        }
        return true; // Allow movement if no obstacles
    }
}
