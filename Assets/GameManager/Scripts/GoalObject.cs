using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalObject : MonoBehaviour
{
    [SerializeField] private GameObject clearEffect;

    private bool clearFlag;

    [SerializeField] Timer timer;
    [SerializeField] private Timer waitTimer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" )
        {
            clearFlag = true;
            clearEffect.SetActive(true);
            clearEffect.transform.localScale = Vector3.zero;
            GameManager.OnGameClear();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        clearFlag = false;
        clearEffect.SetActive(false);
        timer.Reset();
        waitTimer.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!clearFlag) return;
        timer.DoUpdate(Time.deltaTime);
        var t = timer.GetRate();
        clearEffect.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t );

        if( timer.IsEnd() )
        {
            waitTimer.DoUpdate(Time.deltaTime);
            if( waitTimer.IsEnd())
            {
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}
