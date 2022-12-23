using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public string Scene_Title = "";
    public string Scene_GameScene = "";
    public Image TitleButton;
    public Image ReStartButton;
    private bool cursorNum = false;

    void Update()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cursorNum = true;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            cursorNum = false;
        }

        // ReStart‘I‘ð’†
        if (cursorNum == false)
        {
            TitleButton.color = new Color32(0, 0, 0 , 0);
            ReStartButton.color = new Color32(255, 0, 0, 255);

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(Scene_GameScene);
            }
        }

        // Title‘I‘ð’†
        if (cursorNum)
        {
            TitleButton.color = new Color32(255, 0, 0, 255);
            ReStartButton.color = new Color32(0, 0, 0, 0);

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(Scene_Title);
            }
        }
    }

    
}
