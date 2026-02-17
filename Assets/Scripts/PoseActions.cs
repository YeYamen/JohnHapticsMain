using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseActions : MonoBehaviour
{

    [SerializeField] LineRenderer leftLaser;
    [SerializeField] ParticleSystem rightSmoke;
    [SerializeField] SphereCollider rightHandDetection;

    private Collider rightCol;
    private bool isColliding = false;

    private void Start()
    {
        rightCol = rightHandDetection.GetComponent<SphereCollider>();
    }

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
        if (isColliding)
        {
            rightSmoke.Play();
        }
        else
        {
            rightSmoke.Stop();
        }
        
    }

    public void CloseHand()
    {
        rightSmoke.Stop();
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
