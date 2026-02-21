using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePath : MonoBehaviour
{
    [SerializeField] Transform minAngle;
    [SerializeField] Transform maxAngle;
    [SerializeField] AnimationCurve rotationCurve;
    Rigidbody rb;

    Quaternion rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotation = minAngle.rotation;
    }

    public void CheckRotate()
    {
        SwitchRotation();
    }

    private void FixedUpdate()
    {
        SwitchRotation();
    }

    void SwitchRotation()
    {
        float rot = Quaternion.Dot(transform.rotation, rotation);
        if (rot > 0.99)
        {
            if(rotation == minAngle.rotation) 
            { 
                rotation = maxAngle.rotation; 
            }
            else if (rotation == maxAngle.rotation) 
            { 
                rotation = minAngle.rotation;
            }
        }

        Quaternion newRot = Quaternion.Lerp(transform.rotation, rotation, rotationCurve.Evaluate(Time.deltaTime));
        rb.MoveRotation(newRot);
    }
}
