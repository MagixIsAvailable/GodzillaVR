using UnityEngine;


[DisallowMultipleComponent]
public class GodzillaJawController : MonoBehaviour
{
    [Header("Jaw Bone")]
    public Transform jawBone;            // assign your "jaw" bone here
    public float maxOpenAngle = 30f;     // how far (in degrees) jaw opens at full expression

    OVRFaceExpressions faceExpr;         // the component that samples your face

    Quaternion jawClosedRotation;

    void Start()
    {
        // Cache the closed (initial) rotation of the jaw bone
        if (jawBone == null)
        {
            Debug.LogError("Jaw bone not assigned on " + name);
            enabled = false;
            return;
        }
        jawClosedRotation = jawBone.localRotation;

        // Find the OVRFaceExpressions on your camera rig
        faceExpr = FindObjectOfType<OVRFaceExpressions>();
        if (faceExpr == null)
            Debug.LogWarning("OVRFaceExpressions component not found; jaw will not track.");
    }

    void LateUpdate()
    {
        if (faceExpr == null) return;

        // Read the blend‐shape coefficient for JawOpen (0 → 1)
        float t = faceExpr.GetFaceExpression(OVRFaceExpressions.FaceExpression.JawOpen);

        // Calculate the target rotation: closed + (pitch down by maxOpenAngle * t)
        Quaternion openRot = Quaternion.Euler(maxOpenAngle * t, 0f, 0f);
        jawBone.localRotation = jawClosedRotation * openRot;
    }
}
