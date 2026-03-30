using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float mouseSensitivity = 2f;

    // Jump + Gravity
    public float jumpHeight = 2f;
    public float gravity = -20f;

    // Sprint + Stamina
    public float sprintMultiplier = 1.8f;
    public float maxStamina = 5f;
    public float staminaDrain = 1.2f;
    public float staminaRegen = 0.4f;

    // Sprint cooldown
    public float sprintCooldown = 2f;
    float cooldownTimer = 0f;

    public Slider staminaBar;

    public float stamina;
    float xRotation = 0f;
    float yVelocity;
    bool isGrounded;

    bool isSprinting;
    public bool hasShield = false;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        stamina = maxStamina;

        if (staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
        }
    }

    void Update()
    {
        // Ground check
        isGrounded = controller.isGrounded;

        if (isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }

        Move();
        Look();
        Jump();
        HandleSprintFOV();

        if (staminaBar != null)
        {
            staminaBar.value = stamina;
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Cooldown timer
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Use keybind system
        isSprinting = Input.GetKey(Keybinds.sprintKey) && stamina > 0 && cooldownTimer <= 0;

        float currentSpeed = speed;

        if (isSprinting)
        {
            currentSpeed *= sprintMultiplier;

            stamina -= staminaDrain * Time.deltaTime;
            stamina = Mathf.Max(stamina, 0);

            // If stamina runs out → trigger cooldown
            if (stamina <= 0)
            {
                isSprinting = false;
                cooldownTimer = sprintCooldown;
            }
        }
        else
        {
            // Only regen when NOT cooling down
            if (cooldownTimer <= 0)
            {
                stamina += staminaRegen * Time.deltaTime;
            }
        }

        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Jump()
    {
        if (Input.GetKeyDown(Keybinds.jumpKey) && isGrounded)
        {
            AudioManager.instance.Play(AudioManager.instance.jump);
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        yVelocity += gravity * Time.deltaTime;
        controller.Move(Vector3.up * yVelocity * Time.deltaTime);
    }

    void HandleSprintFOV()
    {
        if (Camera.main == null) return;

        if (cooldownTimer > 0)
        {
            // slight zoom when exhausted
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 55f, Time.deltaTime * 5f);
        }
        else if (isSprinting)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 75f, Time.deltaTime * 5f);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, Time.deltaTime * 5f);
        }
    }
}