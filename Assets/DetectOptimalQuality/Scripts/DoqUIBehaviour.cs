using UnityEngine;
using System.Collections;

public class DoqUIBehaviour : MonoBehaviour
{
    public GameObject resultBox, runTestDialogue;

	void Start ()
    {
        if (PlayerPrefs.GetInt(DoqController.SHOW_BENCHMARK_RESULT, 0) == 1)
        {
            resultBox.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(DoqController.BENCHMARK_DONE, 0) != 1)
        {
            runTestDialogue.SetActive(true);
        }

        PlayerPrefs.SetInt(DoqController.SHOW_BENCHMARK_RESULT, 0);
    }
}
