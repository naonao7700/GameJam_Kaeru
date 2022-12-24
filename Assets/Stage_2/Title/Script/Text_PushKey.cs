using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_PushKey : MonoBehaviour
{
    public Text text;
    public float flash_speed = 1.0f;
    private float time;
    private float input_time;

    void Start()
    {
        text = GetComponent<Text>();
        text.color = new Color(0, 0, 0, 0);
    }

    void Update()
    {
        if (input_time < 0)
        {
            text.color = GetAlphaColor(text.color);
        }
        else
        {
            input_time -= 1.0f * Time.deltaTime;
        }
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * flash_speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

}
