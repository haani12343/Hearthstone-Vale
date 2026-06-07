using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 0.3f;
    public float jumpHeight = 3f;
    private CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private float xRotation = 0f;
    private Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Keyboard.current.wKey.isPressed) z = 1f;
        if (Keyboard.current.sKey.isPressed) z = -1f;
        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Keyboard.current.spaceKey.isPressed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity;
        float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}