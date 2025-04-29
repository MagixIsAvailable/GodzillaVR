using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class TitanInputController : MonoBehaviour
{

    private void HandleLook(Vector2 lookInput)
    {
        if (animator == null) return;

        // Right = positive X, Left = negative X
        animator.SetBool("IsTurningLeft", lookInput.x < -0.5f);
        animator.SetBool("IsTurningRight", lookInput.x > 0.5f);
    }
    public float moveSpeed = 10f;
    public float turnSpeed = 5f;
    public Transform cameraTransform;
    public Animator animator;

    private CharacterController controller;
    private TitanInputActions inputActions;
    private Vector2 moveInput;

    private void Awake()
    {
        inputActions = new TitanInputActions();

        inputActions.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Gameplay.Jump.performed += ctx => animator.SetTrigger("Jump");
        inputActions.Gameplay.Stomp.performed += ctx => animator.SetTrigger("Stomp");

        inputActions.Gameplay.Look.performed += ctx => HandleLook(ctx.ReadValue<Vector2>());
        inputActions.Gameplay.Look.canceled += ctx => HandleLook(Vector2.zero);

    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);

        if (cameraTransform != null)
        {
            Vector3 camForward = cameraTransform.forward;
            camForward.y = 0f;
            direction = Quaternion.LookRotation(camForward) * direction;
        }

        if (direction.magnitude > 0.1f)
        {
            controller.SimpleMove(direction.normalized * moveSpeed);
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }

        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
    }
}
