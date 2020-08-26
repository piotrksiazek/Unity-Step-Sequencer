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
    [SerializeField] List<kwadrat> otherSteps;

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

        currentAudioSource = null; //delete later
        currentInstrument = closedHatSource;
        foreach(var step in FindObjectsOfType<kwadrat>())
        {
            otherSteps.Add(step);
        }

    }
    void Update()
    {
        LightTheBulbIfStep();
        ShiftInstrument();
        turnOffGoldIfNotSwitching();
        LightTheRedIfCurrentInstrument();
        PlaySounds();
        ArmWhenDisabled();
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
            openHatSource.PlayOneShot(openHat);
            clapSource.PlayOneShot(clap);
            crashSource.PlayOneShot(crash);
            kickSource.PlayOneShot(kick);
            rideSource.PlayOneShot(ride);
            rimSource.PlayOneShot(rim);
            snareSource.PlayOneShot(snare);
        }

        isArmed = false;
    }

    private void ArmWhenDisabled()
    {
        if (circular.currentIndex != stepIndex)
            isArmed = true;
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
                        if (instrument == "Closed Hat")
                            otherSteps.ForEach(x => x.currentInstrument = x.closedHatSource);
                        else if (instrument == "Open Hat")
                            otherSteps.ForEach(x => x.currentInstrument = x.openHatSource);
                        else if (instrument == "Clap")
                            otherSteps.ForEach(x => x.currentInstrument = x.clapSource);
                        else if (instrument == "Crash")
                            otherSteps.ForEach(x => x.currentInstrument = x.crashSource);
                        else if (instrument == "Kick")
                            otherSteps.ForEach(x => x.currentInstrument = x.kickSource);
                        else if (instrument == "Ride")
                            otherSteps.ForEach(x => x.currentInstrument = x.rideSource);
                        else if (instrument == "Rim")
                            otherSteps.ForEach(x => x.currentInstrument = x.rimSource);
                        else if (instrument == "Snare")
                            otherSteps.ForEach(x => x.currentInstrument = x.snareSource);
                        
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

    private void UpdateOtherCurrentInstruments()
    {

    }
    private void turnOffGoldIfNotSwitching()
    {
        if(!isSwitchingInstrument)
        {
            transform.GetChild(2).GetComponent<SpriteRenderer>().color = transparent;
        }
    }


}

