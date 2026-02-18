using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] float rayLength = 20;
    GameObject currentObj;

    [SerializeField] TMP_Text debugText;
    [SerializeField] GameObject lastObj;

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

    public void ChooseObject()
    {
        if (currentObj != null)
        {
            
            lastObj.SetActive(true);

            currentObj.SetActive(false);

            if (debugText.enabled)
            {
                debugText.text = "Chosen object : " + currentObj.name + "\n Last object : " + lastObj.name;
            }

            lastObj = currentObj;
        }
    }
}
