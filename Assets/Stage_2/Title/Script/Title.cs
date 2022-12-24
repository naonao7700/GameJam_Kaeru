using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private float time;

    public string nextScene = "MainGame";

    void Update()
    {
        if (time < 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
        else
        {
            time -= 1.0f * Time.deltaTime;
        }
    }
}
