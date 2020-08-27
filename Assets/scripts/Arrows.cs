using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public Bpm bpm;
    [SerializeField] float bpmPerClick;

    public void IncreaseBpm()
    {
        if(bpm.bpm <= 400)
        {
            bpm.bpm += bpmPerClick;
            bpm.beatInterval = 60 / bpm.bpm;
        }
        
    }

    public void DecreaseBpm()
    {
        if(bpm.bpm >= 0)
        {
            bpm.bpm -= bpmPerClick;
            bpm.beatInterval = 60 / bpm.bpm;
        }
        
    }
}
