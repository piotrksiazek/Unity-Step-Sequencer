using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Bpm : MonoBehaviour
{
    [SerializeField] public float bpm;
    [SerializeField] private float beatInterval;
    [SerializeField] private float timePassed;
    [SerializeField] private List<AudioSource> stepsAudioSource;
    [SerializeField] public List<kwadrat> steps;
    [SerializeField] public CircularIndex circular;

    private void Awake()
    {
        beatInterval = 60 / bpm; // interval in seconds
        var steps = FindObjectsOfType<kwadrat>();
        //steps = steps.OrderBy(x => x.stepIndex).ToArray();
        circular.maxIndex = steps.Length - 1;
        //foreach(kwadrat step in steps)
        //{
        //    stepsAudioSource.Add(step.GetComponent<AudioSource>());
        //}
    }
    void Update()
    {
        PlayStep();
    }

    private void PlayStep()
    {
        if (timePassed >= beatInterval)
        {
            circular.nextIndex();
            timePassed = 0f;
        }

        else
        {
            timePassed += Time.deltaTime;
        }
    }

}
