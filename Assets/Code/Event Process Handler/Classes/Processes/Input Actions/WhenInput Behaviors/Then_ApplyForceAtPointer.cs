using UnityEngine;

public class Then_ApplyForceAtPointer : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public Collider col;
    public float forceMagnitude;

    public void ApplyForceAtPointer(InputActionContextData context)
    {
        // Convert the screen position to a world position at the near clip plane
        Vector3 screenPosition = new Vector3(context.screenPositionTrue.x, context.screenPositionTrue.y, cam.nearClipPlane);
        Vector3 worldPoint = cam.ScreenToWorldPoint(screenPosition);
        Debug.Log("World Point from Screen Position is " + worldPoint);

        Ray ray = cam.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        // Check if the ray hits the collider
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Raycast hit at: " + hit.point);
            Debug.DrawLine(cam.transform.position, hit.point, Color.green, 2f);

            // Calculate the direction from the hit point on the collider to the world point
            Vector3 forceDirection = (hit.point - cam.transform.position).normalized;

            // Apply the force at the hit point on the collider, in the direction from the camera to that point
            rb.AddForceAtPosition(forceDirection * forceMagnitude, hit.point, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Raycast did not hit any collider.");
        }
    }
}
