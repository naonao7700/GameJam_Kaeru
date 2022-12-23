using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Text text;
    public float flash_speed = 1.0f;
    private float time;
    public string nextScene = "MainGame";

    void Start()
    {
        text = GetComponent<Text>();
    }

    //void Update()
    //{
    //    if(Input.GetKey(KeyCode.Space))
    //    {
    //        SceneManager.LoadScene(nextScene);
    //    }

    //    text.color = GetAlphaColor(text.color);

    //}

    //Color GetAlphaColor(Color color)
    //{
    //    time += Time.deltaTime * 5.0f * flash_speed;
    //    color.a = Mathf.Sin(time) * 0.5f + 0.5f;

    //    return color;
    //}
}
