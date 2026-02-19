using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotateSpeed;
    public bool autoRotate;
    public bool wiggle;
    public bool addTorque;

    // Update is called once per frame
    void Update()
    {

        if (addTorque)
        {
            Transform trans = this.transform.GetChild(0);
            GameObject obj = trans.gameObject;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddTorque(Vector3.up * 10f);
        }

        if (wiggle)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if (autoRotate)
            transform.Rotate(0.4f* rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime,  1.2f* rotateSpeed * Time.deltaTime);
        else
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
    }


}
