using UnityEngine;
using System.Collections;

public class QLD_UI : MonoBehaviour
{
    public GameObject resultBox, runTestDialogue;

	void Start ()
    {
        if (PlayerPrefs.GetInt(QLDController.SHOW_BENCHMARK_RESULT, 0) == 1)
        {
            resultBox.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(QLDController.BENCHMARK_DONE, 0) != 1)
        {
            runTestDialogue.SetActive(true);
        }

        PlayerPrefs.SetInt(QLDController.SHOW_BENCHMARK_RESULT, 0);
    }
}
