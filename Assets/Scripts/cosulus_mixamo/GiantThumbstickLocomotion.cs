using UnityEngine;
using Oculus;

[RequireComponent(typeof(Rigidbody))]
public class GiantThumbstickLocomotion : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(
            OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x,
            OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y
        );

        Vector3 move = new Vector3(input.x, 0, input.y);

        // Move relative to the headset forward direction
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 direction = (cameraForward * move.z + cameraRight * move.x).normalized;

        if (direction.magnitude > 0.1f)
        {
            Vector3 newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }
}
