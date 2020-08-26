using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldButton : MonoBehaviour
{
    private GameObject[] goldButtons;
    private void Awake()
    {
        goldButtons = GameObject.FindGameObjectsWithTag("Gold");
    }
    public void shiftRedToGold()
    {
        foreach(var goldButton in goldButtons)
        {
            goldButton.GetComponent<SpriteRenderer>().color = Color.white;
        }
        kwadrat.isSwitchingInstrument = true;

    }

}
