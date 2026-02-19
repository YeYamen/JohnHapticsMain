using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardBehaviour : Raycastables
{
    Vector3 closeUp = new UnityEngine.Vector3(0.5f, 0.05f, -0.3f);
    Vector3 originalPos;

    float minAngle = -20f;
    float maxAngle = 20f;
    float turnSpeed = 0.4f;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    public override void Update()
    {
        // PingPong creates a 0 -> duration -> 0 value
        float time = Mathf.PingPong(Time.time * turnSpeed, 1f);

        // LerpAngle handles 360-0 degree wrapping
        float nextAngle = Mathf.LerpAngle(minAngle, maxAngle, time);

        transform.eulerAngles = new Vector3(0, nextAngle, 0);
    }

    public override void Casted()
    {
        transform.localPosition = closeUp;
        transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
    }

    private void FixedUpdate()
    {
        transform.localPosition = originalPos;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }
}
