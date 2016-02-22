using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;
    public float framesToSkipAtStart = 5;
    [Tooltip("No need to set a value")]
    public float fps = 0.0f;
    [Tooltip("No need to set a value")]
    public float averageFps = 0;

    private float deltaTime = 0.0f;
    private float timer = 0;
    private int frameCounter = 0;
    private int averageElementsCounter = 0;

    private const float TIMER_PERIOD = 0.2f;

    void Start()
    {
        // Overwrite possible editor set values
        fps = 0;
        averageFps = 0;
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;

        if (frameCounter < framesToSkipAtStart)
        {
            frameCounter++;
            return;
        }

        averageFps = (averageFps * averageElementsCounter + fps) / ++averageElementsCounter;

        if (Time.time > timer)
        {
            timer = Time.time + TIMER_PERIOD;
            fpsText.text = Mathf.RoundToInt(fps) + " FPS";
            //DoqLogger.Instance.Log(averageFps);
        }
    }
}