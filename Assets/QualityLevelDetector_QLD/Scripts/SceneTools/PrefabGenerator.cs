using UnityEngine;
using System.Collections.Generic;
using System;

public class PrefabGenerator : MonoBehaviour {

    public GameObject prefab;
    public int numberOfPrefabs = 10;
    public bool shiftObjects = false;
    public int shiftDistance = 1;
    public int prefabsPerRow = 5;

    private int prefabCounter = 1;
    private Vector3 currentShift;

    void Start ()
    {
        currentShift = new Vector3(0, 0, 0);
        GeneratePrefab();
    }

    private void GeneratePrefab()
    {
        while (prefabCounter < numberOfPrefabs)
        {
            if (shiftObjects)
            {
                if (currentShift.x < shiftDistance * (prefabsPerRow-1))
                {
                    currentShift = new Vector3(currentShift.x + shiftDistance, 0, currentShift.z);
                }
                else
                {
                    currentShift = new Vector3(0, 0, currentShift.z + shiftDistance);
                }
            }

            prefabCounter++;
            Instantiate(prefab).transform.position += currentShift;
        }
    }
}
