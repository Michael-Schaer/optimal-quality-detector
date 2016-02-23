using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QLD_UI : Singleton<QLD_UI>
{
    public GameObject resultBox, runTestDialogue, loadingScreen;
    public Text qualityLevelText;

	void Start ()
    {
        if (PlayerPrefs.GetInt(QLDController.SHOW_BENCHMARK_RESULT, 0) == 1)
        {
            qualityLevelText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
            resultBox.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(QLDController.BENCHMARK_DONE, 0) != 1)
        {
            runTestDialogue.SetActive(true);
        }

        PlayerPrefs.SetInt(QLDController.SHOW_BENCHMARK_RESULT, 0);
    }

    public void ShowLoadingScreen()
    {
        loadingScreen.SetActive(true);
    }
}
