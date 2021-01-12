using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Gets the target's location dor the camera to focus on
    public Transform target;

    // How fast the camera will smooth
    public float smoothSpeed = 0.125f;

    // To offset the camera's position from the target
    public Vector3 offset;

    void FixedUpdate()
    {
        // Gets the location to move the camera to
        Vector3 desiredPosition = target.position + offset;

        // Smooths the camera movement using a lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Sets the cameras position
        transform.position = smoothedPosition;
    }
}
