using UnityEngine;
using System.Collections;

public class QualityDependantObject : MonoBehaviour {

    public int highestLowQualityLevel = 1;
    public bool disableOnHighQuality = false;

	void Start ()
    {
		if (disableOnHighQuality)
        {
            //DoqLogger.Instance.Log("Object removed (high quality): " + !IsLowQualitySetting());
            gameObject.SetActive(IsLowQualitySetting());
		}
        else
        {
            //DoqLogger.Instance.Log("Object removed (low quality): " + IsLowQualitySetting());
            gameObject.SetActive(!IsLowQualitySetting());
        }
	}

	public bool IsLowQualitySetting()
    {
		return QualitySettings.GetQualityLevel() <= highestLowQualityLevel;
	}
}
