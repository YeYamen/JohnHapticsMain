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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(isMoving == true) { MoveCheck(); }
        if(isScaling == true) { ScaleObject(); }
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
}
