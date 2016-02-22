using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class QualityLevelBean : IComparable<QualityLevelBean>
{
	public string qualityLevelName;
    public int sortingValue;
    public int originalIndex;
    public int fpsRequirement;

    public float averageFPS = 0;

    public QualityLevelBean(string qualityLevelName, int originalIndex, int sortingValue, int fpsRequirement)
    {
        this.qualityLevelName = qualityLevelName;
        this.originalIndex = originalIndex;
        this.sortingValue = sortingValue;
        this.fpsRequirement = fpsRequirement;
    }

    public static List<QualityLevelBean> GetSortedList(List<QualityLevelBean> unsorted)
    {
        unsorted.Sort();
        return unsorted;
    }

    public int CompareTo(QualityLevelBean other)
    {
        if (sortingValue == other.sortingValue)
        {
            return 0;
        }
        else if (sortingValue > other.sortingValue)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
