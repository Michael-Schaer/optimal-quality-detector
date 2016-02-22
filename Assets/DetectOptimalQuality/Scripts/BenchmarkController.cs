﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

[RequireComponent(typeof(FPSCounter))]
public class BenchmarkController : MonoBehaviour
{
    public float fpsDropMaxCount = 10;
    public float timeLimit_sec = 4;

    private FPSCounter fpsCounter;

    void Start ()
    {
        fpsCounter = GetComponent<FPSCounter>();
        timeLimit_sec += Time.time;
    }

    void Update ()
    {
        if(Time.time > timeLimit_sec)
        {
            StopTest();
        }
	}

    private void StopTest()
    {
        StoreTestResults();
    }

    private void StoreTestResults()
    {
        if (DoqController.HasInstance())
        {
            DoqController.Instance.StoreResult(fpsCounter.averageFps);
        }
    }
}
