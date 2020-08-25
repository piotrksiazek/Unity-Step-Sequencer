using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularIndex : MonoBehaviour
{
    [SerializeField] Bpm bpm;
    private int minIndex = 0;
    [SerializeField] public int maxIndex;
    [SerializeField] public int currentIndex = 0;
    public int nextIndex()
    {
        if(currentIndex >= maxIndex)
        {
            currentIndex = minIndex;
        }
        else
        {
            currentIndex++;
        }
        return currentIndex;
    }
}
