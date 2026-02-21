using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentActions : MonoBehaviour
{
    private void FixedUpdate()
    {
        
    }

    public void MoveRigidbody(TravelPath path)
    {
        path.MoveCheck();
    }

    public void RotateRigidBody(RotatePath path)
    {
        path.CheckRotate();
    }

    public void ScaleObject(TravelPath path)
    {
        path.ScaleObject();
    }
}
