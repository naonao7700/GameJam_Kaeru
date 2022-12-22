using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private float jumpcount;
    public float Jump;
    public float interbal;
  
    public float jumpup;
    public float jumpdown;
    Rigidbody2D rb;
   public Vector2 velocity;
    public int Groundcount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Groundcount++;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Groundcount--;
        }
    }
    bool isGround()
    {
        return Groundcount > 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        interbal = 0;
     
       

    }
  
    // Update is called once per frame
    void Update()
    {
        velocity = Vector2.zero;
        bool waterFlag = GameManager.GetWaterFlag();
        if (waterFlag == false)
        {
            if (isGround())
            {
                if (Input.GetKeyDown(KeyCode.Space))  //
                {
                    velocity.y = Jump;
                    //transform.Translate(0, Jump, 0);
                    interbal = 300;
                }
            }
            if (interbal > 0)
            {
                //jumpcount = 1;
                interbal--;
            }
            if (interbal <= 0)
            {
                //jumpcount = 0;

            }
        }
        if(waterFlag == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))  //
            {
                velocity.y = jumpup;
                //transform.Translate(0, 1, 0);
               
            }
            //if (Input.GetKey(KeyCode.S))  //
            //{
            //    velocity.y = -jumpdown;
            //    //transform.Translate(0, -jumpdown, 0);

            //}
        }
        rb.velocity += velocity;
    }
}
