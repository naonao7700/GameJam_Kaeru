using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_PushKey : MonoBehaviour
{
    public Text text;
    public float flash_speed = 1.0f;
    private float time;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.color = GetAlphaColor(text.color);
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * flash_speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

}
