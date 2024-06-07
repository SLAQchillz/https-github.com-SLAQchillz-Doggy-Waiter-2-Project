using System.Collections.Generic;
using UnityEngine;

public class ShootObjectsProcess : SingleEventProcess
{
    public ObjectTracker objectTracker;
    public Vector3 mainForceDirection = Vector3.up;
    public float mainForceMagnitude = 10f;
    public float randomForceRange = 5f;
    public float torqueRange = 5f;

    public override void ProcessSpecificOverride()
    {
        base.ProcessSpecificOverride();

        List<GameObject> ObjectsToShoot = objectTracker.MyObjectList;

        foreach (GameObject go in ObjectsToShoot)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply main force
                Vector3 force = mainForceDirection.normalized * mainForceMagnitude;

                // Add random force in other axes
                force += new Vector3(
                    Random.Range(-randomForceRange, randomForceRange),
                    Random.Range(-randomForceRange, randomForceRange),
                    Random.Range(-randomForceRange, randomForceRange));

                rb.AddForce(force, ForceMode.Impulse);

                // Apply random torque
                Vector3 torque = new Vector3(
                    Random.Range(-torqueRange, torqueRange),
                    Random.Range(-torqueRange, torqueRange),
                    Random.Range(-torqueRange, torqueRange));

                rb.AddTorque(torque, ForceMode.Impulse);
            }

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
