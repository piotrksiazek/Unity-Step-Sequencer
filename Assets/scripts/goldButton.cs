using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldButton : MonoBehaviour
{
    private GameObject[] goldButtons;
    private kwadrat[] steps;
    private void Awake()
    {
        goldButtons = GameObject.FindGameObjectsWithTag("Gold");
        steps = GameObject.FindObjectsOfType<kwadrat>();
    }
    public void shiftRedToGold()
    {
        for (int i = 0; i <= goldButtons.Length-1; i++)
        {
            goldButtons[i].GetComponent<SpriteRenderer>().color = Color.white;
            steps[i].isSwitchingInstrument = true;
        }

    }
}
