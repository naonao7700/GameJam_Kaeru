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

    // �����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Player" )
        {
            PlayerSound.PlaySE(SEID.Damage);
            GameManager.OnGameOver();

        }
    }
}
