using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseActions : MonoBehaviour
{

    [SerializeField] LineRenderer leftLaser;
    [SerializeField] ParticleSystem rightSmoke;
    public void EnableLaser()
    {
        leftLaser.enabled = true;
    }

    public void DisableLaser()
    {
        leftLaser.enabled = false;
    }

    public void OpenHand()
    {
        rightSmoke.Play();
    }

    public void CloseHand()
    {
        rightSmoke.Stop();
    }
}
