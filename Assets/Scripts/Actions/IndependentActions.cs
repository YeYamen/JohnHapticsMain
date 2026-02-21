using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentActions : MonoBehaviour
{

    public void MoveRigidbody(TravelPath path)
    {
        path.MoveCheck();
    }

    public void RotateRigidBody(RotatePath path)
    {
        path.CheckRotate();
    }
}
