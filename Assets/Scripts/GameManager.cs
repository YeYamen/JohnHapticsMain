using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float rayLength = 20;
    GameObject currentObj;

    public void ShootRaycast(Transform obj)
    {
        RaycastHit hit;

        if (Physics.Raycast(obj.position, obj.forward, out hit, rayLength))
        {
            CheckObj(hit.collider.gameObject);
            currentObj = hit.collider.gameObject;
        }
    }

    void CheckObj(GameObject obj)
    {
        if (obj.gameObject.GetComponent<Raycastables>() != null)
        {
            Raycastables rayed = obj.gameObject.GetComponent<Raycastables>();
            rayed.Casted();
        }
    }

    public void DisableCard()
    {
        if (currentObj != null)
        {
            currentObj.SetActive(false);
        }
    }
}
