using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class kwadrat : MonoBehaviour
{
    public string instrument;
    [SerializeField] private AudioSource currentInstrument;
    [SerializeField] public static bool isSwitchingInstrument;
    [SerializeField] private bool isArmed;
    [SerializeField] CircularIndex circular;
    private int currentIndex;
    [SerializeField] public int stepIndex;
    private SpriteRenderer redButton;
    private SpriteRenderer goldButton;
    private Color white;
    private Color transparent;
    private GameObject bulb;


    [SerializeField] public AudioClip closedHat;
    [SerializeField] public AudioClip openHat;
    [SerializeField] public AudioClip clap;
    [SerializeField] public AudioClip crash;
    [SerializeField] public AudioClip kick;
    [SerializeField] public AudioClip ride;
    [SerializeField] public AudioClip rim;
    [SerializeField] public AudioClip snare;

    public AudioSource closedHatSource;
    public AudioSource openHatSource;
    public AudioSource clapSource;
    public AudioSource crashSource;
    public AudioSource kickSource;
    public AudioSource rideSource;
    public AudioSource rimSource;
    public AudioSource snareSource;
    public AudioSource[] allAudioSources;

    public AudioSource currentAudioSource;

    private void Awake()   
    {
        isSwitchingInstrument = false;
        isArmed = true;
        currentIndex = circular.currentIndex;
        white = new Color(1, 1, 1, 1);
        transparent = new Color(0, 0, 0, 0);
        circular = FindObjectOfType<CircularIndex>();
        bulb = transform.GetChild(0).gameObject;

        redButton = transform.GetChild(3).GetComponent<SpriteRenderer>();
        redButton.color = transparent;

        closedHatSource = AddAudio(0f, closedHat);
        openHatSource = AddAudio(0f, openHat);
        clapSource = AddAudio(0f, clap);
        crashSource = AddAudio(0f, crash);
        kickSource = AddAudio(0f, kick);
        rideSource = AddAudio(0f, ride);
        rimSource = AddAudio(0f, rim);
        snareSource = AddAudio(0f, snare);

        allAudioSources = GetComponents<AudioSource>();

        currentAudioSource = null; //delete later
        currentInstrument = closedHatSource;
    }
    void Update()
    {
        LightTheBulbIfStep();
        ShiftInstrument();
        turnOffGoldIfNotSwitching();
        LightTheRedIfCurrentInstrument();
        PlaySounds();
        if (circular.currentIndex != stepIndex)
            isArmed = true;
    }

    private void LightTheBulbIfStep()
    {
        if (circular.currentIndex == stepIndex)
        {
            bulb.GetComponent<SpriteRenderer>().color = white;
        }
        else
        {
            bulb.GetComponent<SpriteRenderer>().color = transparent;
        }
    }

    private void PlaySounds()
    {
        if(circular.currentIndex == stepIndex && isArmed)
        {
            closedHatSource.PlayOneShot(closedHat);
        }

        isArmed = false;
    }

    private void LightTheRedIfCurrentInstrument()
    {
        if(currentInstrument.volume > 0)
        {
            redButton.color = white;
        }
        else
        {
            redButton.color = transparent;
        }
    }

    private AudioSource AddAudio(float vol, AudioClip clip)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip; 
        newAudio.volume = vol;
        newAudio.playOnAwake = false;
        return newAudio;
    }

    private void ShiftInstrument()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector3 myTouch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                if (GetComponent<Collider2D>().OverlapPoint(myTouch))
                {
                    if(isSwitchingInstrument == true)
                    {
                        if (instrument == "Kick")
                            currentInstrument = kickSource;
                        else if (instrument == "Snare")
                            currentInstrument = snareSource;
                        else if (instrument == "Rim")
                            currentInstrument = rimSource;
                        // TODO Dokończ wpisywać pozostałe instrumenty
                        kwadrat.isSwitchingInstrument = false;
                    }

                    else
                    {
                        if (currentInstrument.volume == 0)
                            currentInstrument.volume = 1;
                        else if (currentInstrument.volume > 0)
                            currentInstrument.volume = 0;
                    }

                }
            }


        }
    }

    private void turnOffGoldIfNotSwitching()
    {
        if(!isSwitchingInstrument)
        {
            transform.GetChild(2).GetComponent<SpriteRenderer>().color = transparent;
        }
    }


}

