using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Behaviour_JoinToAnchor2D : MonoBehaviour
{
    public List<Rigidbody2D> rbs;
    public List<HingeJoint2D> joints;
    public float jointFriction = 10f;

    public Rigidbody2D anchor { get; private set; }

    private Vector2 pos;
    public bool isAnchored { get; private set; } = false;

    public UnityEvent OnJointsCreated;
    public UnityEvent OnJointBroken;

    public void CreateJoints()
    {
        foreach (Rigidbody2D rb in rbs)
        {
            HingeJoint2D joint = CreateJoint(rb);
            joint = SetMotor(joint);
            joints.Add(joint);
        }

        OnJointsCreated?.Invoke();

        isAnchored = true;
    }

    private HingeJoint2D CreateJoint(Rigidbody2D rb)
    {
        HingeJoint2D joint = rb.gameObject.AddComponent<HingeJoint2D>();
        joint.connectedBody = anchor;
        joint.anchor = rb.transform.InverseTransformPoint(pos);
        return joint;
    }

    private HingeJoint2D SetMotor(HingeJoint2D joint)
    {
        JointMotor2D motor = new JointMotor2D
        {
            motorSpeed = 0, // The target speed is zero, so the motor tries to hold the joint in place
            maxMotorTorque = 10f // A low torque value that provides just enough force to resist small movements
        };

        joint.motor = motor;
        joint.useMotor = true; // Enable the motor to apply the frictional force
        return joint;
    }

    public void BreakJoint()
    {
        foreach (HingeJoint2D joint in joints)
        {
            Destroy(joint);
        }
        joints.Clear();
        pos = Vector2.zero;
        anchor = null;
        isAnchored = false;

        OnJointBroken?.Invoke();
    }

    public void GetAnchor(Rigidbody2D newAnchor, Vector2 newPos)
    {
        anchor = newAnchor;
        pos = newPos;
        CreateJoints();
    }
}
