using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float acceleration = 8f;
    [SerializeField] private float deceleration = 8f;
    [SerializeField] private float brakeForce = 15f;
    [SerializeField] private float turnSpeed = 200f;

    [Header("Physics")]
    [SerializeField] private float dragCoefficient = 3f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float currentSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Disable gravity for top-down 2D movement
        rb.gravityScale = 0f;

        // Prevent physics-based rotation from collisions
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Get input directly from Input System
        var playerInput = InputSystem.GetDevice<Keyboard>();
        if (playerInput != null)
        {
            Vector2 input = Vector2.zero;

            // WASD input
            if (playerInput.wKey.isPressed) input.y += 1f;
            if (playerInput.sKey.isPressed) input.y -= 1f;
            if (playerInput.aKey.isPressed) input.x += 1f;  // Inverted
            if (playerInput.dKey.isPressed) input.x -= 1f;  // Inverted

            // Arrow keys
            if (playerInput.upArrowKey.isPressed) input.y += 1f;
            if (playerInput.downArrowKey.isPressed) input.y -= 1f;
            if (playerInput.leftArrowKey.isPressed) input.x += 1f;  // Inverted
            if (playerInput.rightArrowKey.isPressed) input.x -= 1f;  // Inverted

            moveInput = input.normalized;
        }

        // Also check for gamepad input
        var gamepad = InputSystem.GetDevice<UnityEngine.InputSystem.Gamepad>();
        if (gamepad != null)
        {
            Vector2 stickInput = gamepad.leftStick.ReadValue();
            if (stickInput.magnitude > 0.1f)
            {
                // Invert X axis for gamepad too
                stickInput.x = -stickInput.x;
                moveInput = stickInput;
            }
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        ApplyDrag();
    }

    private void HandleMovement()
    {
        float motor = moveInput.y;

        if (motor != 0)
        {
            // Check if braking (input opposite to current movement)
            bool isBraking = (currentSpeed > 0.1f && motor < 0) || (currentSpeed < -0.1f && motor > 0);

            if (isBraking)
            {
                // Apply brake force (stronger deceleration)
                float brakeDirection = currentSpeed > 0 ? -1f : 1f;
                currentSpeed += brakeDirection * brakeForce * Time.fixedDeltaTime;

                // Stop at zero to prevent overshooting
                if (currentSpeed > 0.1f && brakeDirection < 0)
                    currentSpeed = Mathf.Max(currentSpeed, 0);
                else if (currentSpeed < -0.1f && brakeDirection > 0)
                    currentSpeed = Mathf.Min(currentSpeed, 0);
            }
            else
            {
                // Normal acceleration
                currentSpeed += motor * acceleration * Time.fixedDeltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed * 0.5f, maxSpeed);
            }
        }
        else
        {
            // Natural deceleration when no input
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        }

        // Apply movement force
        Vector2 forwardForce = transform.up * currentSpeed;
        rb.AddForce(forwardForce, ForceMode2D.Force);
    }

    private void HandleRotation()
    {
        float steering = moveInput.x;

        // Only rotate when moving
        if (Mathf.Abs(currentSpeed) > 0.1f && steering != 0)
        {
            float turnFactor = steering * turnSpeed * Time.fixedDeltaTime;

            // Reverse steering when moving backward
            if (currentSpeed < 0)
                turnFactor = -turnFactor;

            transform.Rotate(0, 0, turnFactor);
        }
    }

    private void ApplyDrag()
    {
        // Apply drag to prevent infinite sliding
        Vector2 drag = -rb.linearVelocity * dragCoefficient;
        rb.AddForce(drag, ForceMode2D.Force);
    }
}
