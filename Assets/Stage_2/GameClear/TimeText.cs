using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    public float time = 0;
    public Text text;

    void Start()
    {
        text.GetComponent<Text>();
    }

    void Update()
    {

        time = TimeSave.timeSave.GetTime();

        text.text = TimeSave.timeSave.GetTimeText(time);
    }
}
