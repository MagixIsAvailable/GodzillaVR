using UnityEngine;

[DisallowMultipleComponent]
public class GodzillaVRRig : MonoBehaviour
{
    [Header("Bone Transforms (Generic Rig)")]
    public Transform centerBone;       // e.g. "center"
    public Transform headBone;         // e.g. "head"
    public Transform leftHandBone;     // e.g. "wrist-IK.L"
    public Transform rightHandBone;    // e.g. "wrist-IK.R"
    public Transform tailControlBone;  // e.g. "tailCTRL"

    [Header("VR Anchor Transforms")]
    public Transform centerAnchor;     // e.g. CameraRig->TrackingSpace (or floor origin)
    public Transform headAnchor;       // e.g. OVRCameraRig.centerEyeAnchor
    public Transform leftHandAnchor;   // e.g. OVRCameraRig.leftHandAnchor
    public Transform rightHandAnchor;  // e.g. OVRCameraRig.rightHandAnchor

    [Header("Smoothing Settings")]
    [Range(0.0f, 1.0f)]
    public float positionSmooth = 0.8f;
    [Range(0.0f, 1.0f)]
    public float rotationSmooth = 0.8f;

    [Header("Tail Sway (Optional)")]
    public float tailSwaySpeed = 1f;
    public float tailSwayAngle = 10f;

    // Stored offset so centerBone follows centerAnchor + this offset
    Vector3 centerOffset;

    void Start()
    {
        if (centerBone != null && centerAnchor != null)
            centerOffset = centerBone.position - centerAnchor.position;
    }

    void LateUpdate()
    {
        // 1) Center follow (keeps Godzilla grounded & moves entire body)
        if (centerBone && centerAnchor)
        {
            Vector3 targetPos = centerAnchor.position + centerOffset;
            centerBone.position = Vector3.Lerp(centerBone.position, targetPos, 1 - positionSmooth);
        }

        // 2) Head follow
        if (headBone && headAnchor)
        {
            headBone.position = Vector3.Lerp(headBone.position, headAnchor.position, 1 - positionSmooth);
            headBone.rotation = Quaternion.Slerp(headBone.rotation, headAnchor.rotation, 1 - rotationSmooth);
        }

        // 3) Left hand follow
        if (leftHandBone && leftHandAnchor)
        {
            leftHandBone.position = Vector3.Lerp(leftHandBone.position, leftHandAnchor.position, 1 - positionSmooth);
            leftHandBone.rotation = Quaternion.Slerp(leftHandBone.rotation, leftHandAnchor.rotation, 1 - rotationSmooth);
        }

        // 4) Right hand follow
        if (rightHandBone && rightHandAnchor)
        {
            rightHandBone.position = Vector3.Lerp(rightHandBone.position, rightHandAnchor.position, 1 - positionSmooth);
            rightHandBone.rotation = Quaternion.Slerp(rightHandBone.rotation, rightHandAnchor.rotation, 1 - rotationSmooth);
        }

        // 5) Simple tail sway
        if (tailControlBone != null)
        {
            float sway = Mathf.Sin(Time.time * tailSwaySpeed) * tailSwayAngle;
            tailControlBone.localRotation = Quaternion.Euler(0, sway, 0);
        }
    }
}
