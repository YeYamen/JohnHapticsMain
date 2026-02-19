using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HapE.Unity;

public class GameManager : MonoBehaviour
{
    public HapEDeviceManager hapticsDevice = null;

    [SerializeField] float rayLength = 20;
    GameObject currentObj;

    [SerializeField] TMP_Text debugText;
    [SerializeField] GameObject lastObj;

    private void Start()
    {
        hapticsDevice = FindAnyObjectByType<HapEDeviceManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hapticsDevice.PlayHapEJSON(CombineJSONName("2-Dial"));
        }
    }

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

    string CombineJSONName(string name)
    {
        string path = Application.streamingAssetsPath + "/haptics/" + name + ".json";

        return path;
    }
}
