using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private float jumpcount;
    public float Jump;
    public float interbal;
    public bool waterFlag;
    public float jumpup;
    public float jumpdown;
    Rigidbody2D rd;
   

    // Start is called before the first frame update
    void Start()
    {
        
        interbal = 0;
        waterFlag = false;
        rd = this.GetComponent<Rigidbody2D>();

    }
  
    // Update is called once per frame
    void Update()
    {
        if (waterFlag == false)
        {
            if (jumpcount == 0)
            {
                if (Input.GetKey(KeyCode.Space))  //
                {

                    transform.Translate(0, Jump, 0);
                    interbal = 300;
                }
            }
            if (interbal > 0)
            {
                jumpcount = 1;
                interbal--;
            }
            if (interbal <= 0)
            {
                jumpcount = 0;

            }
        }
        if(waterFlag == true)
        {
            
            if (Input.GetKey(KeyCode.Space))  //
            {

                transform.Translate(0, jumpup, 0);
               
            }
            if (Input.GetKey(KeyCode.S))  //
            {

                transform.Translate(0, -jumpdown, 0);

            }
        }
    }
}
