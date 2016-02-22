using UnityEngine;
using System.Collections;

public class QLDLogger : Singleton<QLDLogger>
{
    public bool debug = true;
    public bool errors = true;
    public bool resetPrefs = true;

    public void Log(string text)
    {
        if (debug)
        {
            Debug.Log(text);
        }
    }

    public void LogError(string text)
    {
        if (errors)
        {
            Debug.LogError(text);
        }
    }
}
