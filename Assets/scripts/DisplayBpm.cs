using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBpm : MonoBehaviour
{
    private Text bpmDisplay;
    public Bpm bpm;
    void Awake()
    {
        bpmDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bpmDisplay.text = bpm.bpm.ToString();
    }
}
