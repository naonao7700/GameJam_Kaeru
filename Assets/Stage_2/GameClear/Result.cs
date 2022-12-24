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
    private int cursorNum = 0;

    void Update()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cursorNum = 1;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            cursorNum = 0;
        }

        // ReStart‘I‘ð’†(Left)
        if (cursorNum == 0)
        {
            TitleButton.color = new Color32(0, 0, 0 , 0);
            ReStartButton.color = new Color32(255, 255, 255, 255);

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(Scene_GameScene);
            }
        }

        // Title‘I‘ð’†(Right)
        if (cursorNum == 1)
        {
            TitleButton.color = new Color32(255, 255, 255, 255);
            ReStartButton.color = new Color32(0, 0, 0, 0);

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(Scene_Title);
            }
        }
    }

    
}
