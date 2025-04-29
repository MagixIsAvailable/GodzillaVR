using UnityEngine;

public class GiantCameraFollow : MonoBehaviour
{
    public Transform target; // drag cosulus_mixamo here
    public Vector3 offset = new Vector3(0, 25, -50); // adjust for over-the-shoulder

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;
        transform.LookAt(target.position + Vector3.up * 10f); // Look at upper chest/head
    }
}
