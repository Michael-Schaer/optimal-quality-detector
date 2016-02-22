using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    /**
     * Returns the instance of this singleton.
     */
    public static T Instance
    {
        get
        {

            if (!HasInstance())
            {
                Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
            }

            return instance;
        }
    }

    public static bool HasInstance()
    {
        if (instance == null)
        {
            instance = (T)FindObjectOfType(typeof(T));
        }

        return instance != null;
    }
}