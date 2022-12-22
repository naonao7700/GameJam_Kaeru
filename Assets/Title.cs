using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string nextScene = "MainGame";
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
