using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public float time;

    public string nextScene = "MainGame";

     void Start()
    {
        //time = time;  
    }
    void Update()
    {
        time -= 1.0f * Time.deltaTime;
        if (time < 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
