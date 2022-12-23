using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public GameObject Player;
    public float value;

    void Start()
    {
    }

    void Update()
    {
        
    }

    // ‚ ‚½‚è”»’è
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameManager.OnGameOver();
    }
}
