using System;
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
        controller = GetComponent<CharacterController>();
        inputActions = new TitanInputActions();

        inputActions.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Gameplay.Jump.performed += ctx => animator.SetTrigger("Jump");
        inputActions.Gameplay.Stomp.performed += ctx => animator.SetTrigger("Stomp");

        inputActions.Gameplay.Look.performed += ctx => HandleLook(ctx.ReadValue<Vector2>());
        inputActions.Gameplay.Look.canceled += ctx => HandleLook(Vector2.zero);
    }

    private int CharacterController()
    {
        throw new NotImplementedException();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    void Update()
    {
        // Add this Debug Log
        Debug.Log($"Move Input: {moveInput}");

        // Calculate movement direction relative to camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0; // Keep movement horizontal
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * moveInput.y + right * moveInput.x).normalized;

        // Apply movement
        controller.SimpleMove(direction * moveSpeed); // SimpleMove applies gravity

        // Update Animator Speed based on input magnitude
        if (animator != null)
        {
            // Use moveInput.magnitude to reflect joystick input strength
            animator.SetFloat("Speed", moveInput.magnitude);
        }
    }
}
