using HapE.Unity;
using Leap.Unity.PhysicalHands;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CardBehaviour : Raycastables
{
    private HapEDeviceManager hapticsDevice = null;
    private HapticLibraryPlayer library = null;
    private GameManager gm = null;
    private SoundPlayer audioSource = null;

    [SerializeField] AudioClip sound;
    public string hapticName;

    Vector3 closeUp = new UnityEngine.Vector3(0.5f, 0.05f, -0.3f);
    Vector3 originalPos;



    [Space, Header("Card Events"), Space]
    public UnityEvent correctCardEvent;
    public UnityEvent wrongCardEvent;
    public UnityEvent onHover;
    public UnityEvent offHover;

    private void Start()
    {
        hapticsDevice = FindAnyObjectByType<HapEDeviceManager>();
        library = FindAnyObjectByType<HapticLibraryPlayer>();
        gm = FindAnyObjectByType<GameManager>();

        SoundPlayer[] s = FindObjectsOfType<SoundPlayer>();
        foreach(SoundPlayer so in s)
        {
            if(so.gameObject.name == "CardAudio")
            {
                audioSource = so;
            }
        }

        originalPos = transform.localPosition;
    }

    public override void Casted()
    {
        CardHover();

        transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
    }

    private void FixedUpdate()
    {
        if (gm.currentCard != this.gameObject || gm.currentCard == null)
        {
            OffCardHover();
        }

        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    public void CorrectCardAction()
    {
        if (audioSource != null)
        {
            audioSource.PlayTheSound(sound);

            this.gameObject.SetActive(false);
        }
    }

    #region Events

    internal void CorrectCardEvent()
    {
        correctCardEvent?.Invoke();
    }

    internal void WrongCardEvent()
    {
        wrongCardEvent?.Invoke();
    }

    internal void CardHover()
    {
        onHover?.Invoke();
    }

    internal void OffCardHover()
    {
        offHover?.Invoke();
    }

    #endregion
}
