using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ÉQÅ[ÉÄÇÃåoâﬂéûä‘
public class GameTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text text;

    public float GetTime()
    {
        return time;
    }

    public string GetTimeText(float time)
    {
        int min = (int)(time / 60);
        int sec = (int)(time % 60);
        int ms = (int)(time % 1 * 1000);
        return min.ToString("D1") + ":" + sec.ToString("D2") + ":" + ms.ToString("D3");
    }

    public void ResetTimer()
    {
        time = 0.0f;
        UpdateText();
    }

    public void UpdateTimer( float deltaTime )
    {
        time += deltaTime;
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = "TIME:" + GetTimeText(time);
    }
}
