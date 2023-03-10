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

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            cursorNum = 1;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cursorNum = 0;
        }

        // ReStart?I????(Left)
        if (cursorNum == 0)
        {
            TitleButton.color = new Color32(0, 0, 0 , 0);
            ReStartButton.color = new Color32(255, 255, 255, 255);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(Scene_GameScene);
            }
        }

        // Title?I????(Right)
        if (cursorNum == 1)
        {
            TitleButton.color = new Color32(255, 255, 255, 255);
            ReStartButton.color = new Color32(0, 0, 0, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(Scene_Title);
            }
        }
    }

    
}
