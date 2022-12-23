using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSave : MonoBehaviour
{
    public static TimeSave timeSave;

    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        var go = new GameObject("TimeSave");
        DontDestroyOnLoad(go);
        timeSave = go.AddComponent<TimeSave>();
        timeSave.ranking = new float[3]
        {
            99,
            99,
            99
        };
    }

    public float time;
    public float[] ranking;

    public float GetTime()
    {
        return time;
    }

    public void SetTime( float time )
    {
        this.time = time;
    }

    public float GetRankingTime( int index )
    {
        return ranking[index];
    }

    public void SetRankingTime( float time, int index )
    {
        ranking[index] = time;
    }

    public string GetTimeText(float time)
    {
        int min = (int)(time / 60);
        int sec = (int)(time % 60);
        int ms = (int)(time % 1 * 1000);
        return min.ToString("D1") + ":" + sec.ToString("D2") + ":" + ms.ToString("D3");
    }


}
