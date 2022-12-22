using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
   
    public float speed;
    public float speedwater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool waterFlag = GameManager.GetWaterFlag();
        if (waterFlag == false)
        {
            if (Input.GetKey(KeyCode.D))  //
            {

                transform.Translate(speed * Time.deltaTime, 0, 0);      //AD‚ÅˆÚ“®

            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);

            }
        }
        if(waterFlag == true)
        {
            if (Input.GetKey(KeyCode.D))  //
            {

                transform.Translate(speedwater * Time.deltaTime, 0, 0);      //AD‚ÅˆÚ“®

            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speedwater * Time.deltaTime, 0, 0);

            }
        }
    }
}
