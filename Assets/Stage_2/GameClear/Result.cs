using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public string Scene_Return = "";
    public string Scene_Space = "";
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(Scene_Return);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(Scene_Space);
        }
    }

    
}
