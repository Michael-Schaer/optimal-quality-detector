using UnityEngine;
using System.Collections;

public class CPUStresser : MonoBehaviour
{
    public int loopsPerFrame = 1000;

	void Update ()
    {
        int i = 0;
        while (i < loopsPerFrame)
        {
            Vector3 vector = new Vector3(Random.value, Random.value, Random.value);
            vector.Normalize();
            i += Mathf.RoundToInt(vector.magnitude);
        }
	}
}
