using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class QLDController : Singleton<QLDController>
{
    [Tooltip("The scene to load after the Test has finished")]
    public string menuSceneName = "Menu";
    [Tooltip("Provide the names of all Quality Levels to check, starting with the highset level, descending")]
    public string[] definedQualityLevels;
    [Tooltip("Define a minimal FPS requirement for each defined Quality Level. Start with the highset Quality Level, descending")]
    public int[] levelGradingFPS;
    [HideInInspector]
    public int benchmarkRun;

    private List<QLDBean> qualityLevels;
    private QLDBean bestQualityOption;
    private int numberOfQualityLevels;

    private const string HASH = "5ghovBdh";

    public const string NEXT_QUALITY_LEVEL = HASH + "QLevel";
    public const string BENCHMARK_RUN = HASH + "BRun";
    public const string BENCHMARK_LAST_RUN = HASH + "BLRun";
    public const string BENCHMARK_DONE = HASH + "BDone";
    public const string SHOW_BENCHMARK_RESULT = HASH + "BResult";
    public const string MENU_SCENE = HASH + "MenuScene";

    void Start ()
    {
        if (PlayerPrefs.GetInt(BENCHMARK_DONE, 0) == 1)
        {
            if (QLDLogger.Instance.resetPrefs)
            {
                PlayerPrefs.SetInt(BENCHMARK_DONE, 0);
            }

            this.enabled = false;
            return;
        }
    }

    public void StartQualityTest()
    {
        DontDestroyOnLoad(this);

        if (levelGradingFPS.Length != definedQualityLevels.Length)
        {
            QLDLogger.Instance.LogError("Quality Levels and Level Grading FPS must have the same amount of elements! (Check your BenchmarkController values)");
            return;
        }

        SortQualityLevels();
        //SetBenchmark();
        benchmarkRun = numberOfQualityLevels - 1;
        SetCurrentAsBestQualityOption();
        LoadNextScene();
    }

    public void StoreResult(float avgFps)
    {
        if (IsFPSRequirementFulfilled(avgFps))
        {
            // If the fps requirement is fulfilled, check the next better quality level
            SetCurrentAsBestQualityOption();
            benchmarkRun--;
            LoadNextScene();
        }
        else
        {
            // Don't check better quality levels if fps is already low at the current level
            EndTest();
            return;
        }
    }

    private void LoadNextScene()
    {
        if (benchmarkRun >= 0)
        {
            int qualityLevelIndex = GetQualityLevelBySortingValue(benchmarkRun).originalIndex;
            QualitySettings.SetQualityLevel(qualityLevelIndex);
            // Load Benchmark Scene
            SceneManager.LoadScene("benchmark");
        }
        else
        {
            EndTest();
        }
    }

    private void EndTest()
    {
        PlayerPrefs.SetInt(SHOW_BENCHMARK_RESULT, 1);
        PlayerPrefs.SetInt(BENCHMARK_DONE, 1);
        PlayerPrefs.Save();
        SetOptimalQualityLevel();
        LoadMenuScene();
    }

    private void SetCurrentAsBestQualityOption()
    {
        QLDLogger.Instance.Log("Current level is set as best quality match!");
        bestQualityOption = GetQualityLevelBySortingValue(benchmarkRun);
    }

    private bool IsFPSRequirementFulfilled(float avgFps)
    {
        QLDLogger.Instance.Log(QualitySettings.names[QualitySettings.GetQualityLevel()] + " has average FPS " + avgFps + ", required: " + GetQualityLevelBySortingValue(benchmarkRun).fpsRequirement);
        return (avgFps >= GetQualityLevelBySortingValue(benchmarkRun).fpsRequirement);
    }

    private void SetOptimalQualityLevel()
    {
        QualitySettings.SetQualityLevel(bestQualityOption.originalIndex);
        QLDLogger.Instance.Log("Optimal QualityLevel for this device has been set: " + bestQualityOption.qualityLevelName);
    }

    private void SortQualityLevels()
    {
        qualityLevels = new List<QLDBean>();
        int sortingValue = 0;
        for (int q = 0; q < definedQualityLevels.Length; q++)
        {
            for (int index = 0; index < QualitySettings.names.Length; index++)
            {
                if (QualitySettings.names[index].ToLower().Equals(definedQualityLevels[q].ToLower()))
                {
                    qualityLevels.Add(new QLDBean(QualitySettings.names[index], index, sortingValue, levelGradingFPS[q]));
                    //DoqLogger.Instance.Log("Level added: " + QualitySettings.names[index] + " " + index + " " + sortingValue);
                    sortingValue++;
                }
            }
        }

        numberOfQualityLevels = qualityLevels.Count;
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
        Destroy(this);
    }

    private QLDBean GetQualityLevelBySortingValue(int sortingValue)
    {
        foreach (QLDBean o in qualityLevels)
        {
            if(o.sortingValue == sortingValue)
            {
                return o;
            }
        }

        return null;
    }
}
