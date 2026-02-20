using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HapE.Unity;

public class GameManager : MonoBehaviour
{
    public HapEDeviceManager hapticsDevice = null;
    public HapticLibraryPlayer library =  null;

    [SerializeField] float rayLength = 20;
    GameObject currentObj;

    [SerializeField] TMP_Text debugText;
    [SerializeField] GameObject lastObj;

    [SerializeField] List<CardBehaviour> cards;
    public GameObject currentCard;
    public CardBehaviour correctCard;

    private void Start()
    {
        hapticsDevice = FindAnyObjectByType<HapEDeviceManager>();
        library = FindAnyObjectByType<HapticLibraryPlayer>();
    }

    #region Card Actions
    public void FindCardsInScene()
    {
        CardBehaviour[] foundCards = FindObjectsOfType<CardBehaviour>();
        cards.AddRange(foundCards);
        foreach (CardBehaviour card in foundCards) { print(card.name); }
    }

    public void SetCorrectCard()
    {
        correctCard = cards[Random.Range(0, cards.Count)];
    }

    public void IsCardCorrect(GameObject cardChosen)
    {
        if (correctCard == null) return;

        if (cardChosen.name == correctCard.name)
        {
            foreach (CardBehaviour card in cards)
            {
                if (card.name == correctCard.name)
                {
                    card.CorrectCardAction();
                }
            }
        }
    }

    #endregion

    #region Detection
    public void ShootRaycast(Transform obj)
    {
        RaycastHit hit;

        if (Physics.Raycast(obj.position, obj.forward, out hit, rayLength))
        {
            CheckObj(hit.collider.gameObject);
            currentObj = hit.collider.gameObject;

            if (currentObj.GetComponent<CardBehaviour>()){
                currentCard = currentObj;
            }
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
    #endregion

    public void ChooseObject()
    {
        if(currentCard == null) return;

        if (currentCard.GetComponent<CardBehaviour>() != null)
        {
            IsCardCorrect(currentObj);
            correctCard = null;
        }

        //if (currentObj != null)
        //{
            
        //    lastObj.SetActive(true);

        //    currentObj.SetActive(false);

        //    if (debugText.enabled)
        //    {
        //        debugText.text = "Chosen object : " + currentObj.name + "\n Last object : " + lastObj.name;
        //    }

        //    lastObj = currentObj;
        //}
    } //Checks what object the pointer is hovering


    public void PlayHaptic(string name = "Presence")
    {
        library.PlaySensationWithName(name);
    }

    public void StopHaptic()
    {
        library.ClearCurrentSensation();
    }

    string CombineJSONName(string name)
    {
        string path = Application.streamingAssetsPath + "/haptics/" + name + ".json";

        return path;
    }
}
