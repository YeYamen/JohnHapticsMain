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

    float minAngle = -20f;
    float maxAngle = 20f;
    float turnSpeed = 0.4f;


    [Space, Header("Card Events"), Space]
    public UnityEvent correctCardEvent;
    public UnityEvent wrongCardEvent;
    public UnityEvent onHover;

    private void Start()
    {
        hapticsDevice = FindAnyObjectByType<HapEDeviceManager>();
        library = FindAnyObjectByType<HapticLibraryPlayer>();
        gm = gameObject.GetComponent<GameManager>();

        SoundPlayer[] s = FindObjectsOfType<SoundPlayer>();
        foreach(SoundPlayer so in s)
        {
            if(so.gameObject.name == "LeftHandAudio")
            {
                audioSource = so;
            }
        }

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
        this.CardHover();

        transform.localPosition = closeUp;
        transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
    }

    private void FixedUpdate()
    {
        transform.localPosition = originalPos;
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

    #endregion
}
