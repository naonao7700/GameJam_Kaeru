using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public AudioClip move;
    public AudioClip mizumove;
    private float Seinter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool waterFlag = GameManager.GetWaterFlag();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.OnWaterChange(!GameManager.GetWaterFlag());
        }
        if (waterFlag == false)
        {
            if (Input.GetKey(KeyCode.D))  //
            {
              
                if (Seinter >= 0)
                {
                    Seinter--;
                }

                if (Seinter <= 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(move);
                    Seinter = 50;
                }

            }

            if (Input.GetKey(KeyCode.A))
            {
               
                if (Seinter >= 0)
                {
                    Seinter--;
                }
                if (Seinter <= 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(move);
                    Seinter = 50;
                }
            }
        }
        if (waterFlag == true)
        {
            if (Input.GetKey(KeyCode.D))  //
            {
               
                if (Seinter >= 0)
                {
                    Seinter--;
                }
                if (Seinter <= 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(mizumove);
                    Seinter = 50;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
               
                if (Seinter >= 0)
                {
                    Seinter--;
                }

                if (Seinter <= 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(mizumove);
                    Seinter = 50;
                }
            }
        }
    }
}
