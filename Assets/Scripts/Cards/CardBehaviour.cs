using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardBehaviour : Raycastables
{
    Vector3 closeUp = new UnityEngine.Vector3(0.25f, 0.1f, -0.3f);
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    public override void Casted()
    {
        transform.localPosition = closeUp;
    }

    private void FixedUpdate()
    {
        transform.localPosition = originalPos;
    }
}
