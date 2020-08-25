using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class kwadrat : MonoBehaviour
{
    [SerializeField] CircularIndex circular;
    [SerializeField] public int stepIndex;
    private SpriteRenderer sprite;
    private SpriteRenderer redButton;
    private Color white;
    private Color black;
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
    public AudioSource[] audioSources;

    private void Awake()   
    {
        white = new Color(1, 1, 1, 1);
        black = new Color(0, 0, 0, 1);
        transparent = new Color(0, 0, 0, 0);
        circular = FindObjectOfType<CircularIndex>();
        sprite = GetComponent<SpriteRenderer>();
        bulb = transform.GetChild(0).gameObject;
        redButton = transform.GetChild(2).GetComponent<SpriteRenderer>();
        redButton.color = transparent;
    }
    void Update()
    {
        if(circular.currentIndex == stepIndex)
        {
            bulb.GetComponent<SpriteRenderer>().color = white;
        }
        else
        {
            bulb.GetComponent<SpriteRenderer>().color = transparent;
        }
    }
}
