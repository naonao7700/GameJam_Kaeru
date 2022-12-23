using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed;
    public float speedwater;
    Rigidbody2D rb;
    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = Vector2.zero;
        velocity = rb.velocity;
        bool waterFlag = GameManager.GetWaterFlag();
        if (waterFlag == false)
        {
            if (Input.GetKey(KeyCode.D))  //
            {
                velocity.x = speed;// * Time.deltaTime;


            }

            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -speed;// * Time.deltaTime;
                                    //transform.Translate(-speed * Time.deltaTime, 0, 0);

            }
        }
        if (waterFlag == true)
        {
            if (Input.GetKey(KeyCode.D))  //
            {
                velocity.x = speedwater;// * Time.deltaTime;
                                        //transform.Translate(speedwater * Time.deltaTime, 0, 0);      //AD‚ÅˆÚ“®

            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -speedwater;// * Time.deltaTime;

            }
            //rb.velocity += velocity;
            rb.velocity = velocity;
        }
    }
}