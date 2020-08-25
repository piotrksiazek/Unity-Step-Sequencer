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
    private void Start()
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
            //sprite.color = black;
            bulb.GetComponent<SpriteRenderer>().color = white;
        }
        else
        {
            //sprite.color = white;
            bulb.GetComponent<SpriteRenderer>().color = transparent;
        }
    }

    public override string ToString() // For debugging
    {
        return this.stepIndex.ToString();
    }

    public void RedOnClick()
    {
        redButton.color = white;
    }
}
