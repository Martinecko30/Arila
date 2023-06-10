using UnityEngine;

public class Utils
{
    public static Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {
        float currentY = vectorToRotate.y;
        // Get the forward and right directional vectors of the camera
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        // Remove the Y values to ignore upward/downward camera angles
        camForward.y = 0;
        camRight.y = 0;

        // Re-normalize both vectors so the each have magnitude of 1
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        Vector3 vectorRotatedToCameraSpace = (vectorToRotate.z * camForward) + (vectorToRotate.x * camRight);
        vectorRotatedToCameraSpace.y = currentY;
        return vectorRotatedToCameraSpace;
    }
}
