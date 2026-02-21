using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseActions : MonoBehaviour
{
    [SerializeField] SphereCollider rightHandDetection;

    private Collider rightCol;
    private bool isColliding = false;

    private void Start()
    {
        rightCol = rightHandDetection.GetComponent<SphereCollider>();
    }

    public void EnableLaser(LineRenderer laser)
    {
        laser.enabled = true;
    }

    public void DisableLaser(LineRenderer laser)
    {
        laser.enabled = false;
    }

    public void PlaySmoke(ParticleSystem smoke)
    {
        if (isColliding)
        {
            smoke.Play();
        }
        else
        {
            smoke.Stop();
        }
        
    }

    public void StopSmoke(ParticleSystem smoke)
    {
        smoke.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CrystalBall"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CrystalBall"))
        {
            isColliding = false;
        }
    }
}
