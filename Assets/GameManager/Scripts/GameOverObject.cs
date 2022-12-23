using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObject : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    [SerializeField] private Timer timer;
    [SerializeField] private AnimationCurve curve;

    private bool gameOverFlag;

    // Start is called before the first frame update
    void Start()
    {
        gameOverFlag = false;
        textObject.SetActive(false);
    }

    public bool IsEnd()
    {
        if (!gameOverFlag) return false;
        return timer.IsEnd();
    }

    public void OnGameOver()
    {
        gameOverFlag = true;
        textObject.SetActive(true);
        textObject.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOverFlag) return;

        timer.DoUpdate(Time.deltaTime);
        var t = curve.Evaluate(timer.GetRate());
        textObject.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
    }
}
