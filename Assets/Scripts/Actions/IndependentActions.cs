using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentActions : MonoBehaviour
{
    public void MoveAllTransforms(TravelPath path)
    {
        MoveRigidbody(path);
        RotateRigidBody(path);
        ScaleObject(path);
    }

    public void MoveRigidbody(TravelPath path)
    {
        path.MoveCheck();
    }

    public void RotateRigidBody(TravelPath path)
    {
        path.CheckRotate();
    }

    public void ScaleObject(TravelPath path)
    {
        path.ScaleObject();
    }
}
