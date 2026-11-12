using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private int speed;

    [Header("Camera")]
    [SerializeField] private Vector2 cameraInput;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float sensitivity;
    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        cameraInput.x = context.ReadValue<Vector2>().x;
        cameraInput.y = -(context.ReadValue<Vector2>().y);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller.Move(new Vector3(0, -1000, 0));
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // To not allow the player to look to high or too low.
        cameraInput.y = Mathf.Clamp(cameraInput.y, -1, 1);

        transform.Rotate(Vector3.up * cameraInput.x * (sensitivity/100));
        // playerCamera.Rotate(cameraInput.y, 0f, 0f);

        Vector3 move = (transform.right * moveInput.x) + (transform.forward * moveInput.y);

        controller.Move(move * speed * Time.deltaTime);
    }
}
