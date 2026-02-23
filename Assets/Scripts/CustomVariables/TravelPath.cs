using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TravelPath : MonoBehaviour
{
    public Transform pathPosition;
    [SerializeField] AnimationCurve speedCurve;

    [Space]
    public Vector3 scaleSize;
    [SerializeField] AnimationCurve scaleSpeed;
    Rigidbody rb;

    private bool isMoving = false;
    bool isScaling = false;

    [SerializeField] Transform minAngle;
    [SerializeField] Transform maxAngle;
    [SerializeField] AnimationCurve rotationCurve;

    Quaternion rotation;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotation = minAngle.rotation;
    }

    private void FixedUpdate()
    {
        if(isMoving == true) { MoveCheck(); }
        if(isScaling == true) { ScaleObject(); }
        SwitchRotation();
    }

    public void MoveCheck()
    {
        float dist = (transform.position - pathPosition.position).sqrMagnitude;

        if (dist > 0.0001)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        float speed = speedCurve.Evaluate(dist);

        Vector3 newPos = Vector3.Lerp(transform.position, pathPosition.position, speedCurve.Evaluate(Time.deltaTime));
        rb.MovePosition(newPos);
    }

    public void ScaleObject()
    {
        float sca = (transform.localScale - scaleSize).sqrMagnitude;

        if (sca > 0.0001)
        {
            isScaling = true;
        }
        else
        {
            isScaling = false;
        }
        Vector3 newScale = Vector3.Lerp(transform.localScale, scaleSize, scaleSpeed.Evaluate(Time.deltaTime));
        
        transform.localScale = newScale;
    }


    public void CheckRotate()
    {
        SwitchRotation();
    }


    void SwitchRotation()
    {
        float rot = Quaternion.Dot(transform.rotation, rotation);
        if (rot > 0.99)
        {
            if (rotation == minAngle.rotation)
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
