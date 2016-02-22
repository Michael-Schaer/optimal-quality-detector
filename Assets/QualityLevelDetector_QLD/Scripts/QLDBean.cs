using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class QLDBean : IComparable<QLDBean>
{
	public string qualityLevelName;
    public int sortingValue;
    public int originalIndex;
    public int fpsRequirement;

    public float averageFPS = 0;

    public QLDBean(string qualityLevelName, int originalIndex, int sortingValue, int fpsRequirement)
    {
        this.qualityLevelName = qualityLevelName;
        this.originalIndex = originalIndex;
        this.sortingValue = sortingValue;
        this.fpsRequirement = fpsRequirement;
    }

    public static List<QLDBean> GetSortedList(List<QLDBean> unsorted)
    {
        unsorted.Sort();
        return unsorted;
    }

    public int CompareTo(QLDBean other)
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
