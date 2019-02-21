using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WitchController : MonoBehaviour
{
    Rigidbody2D rb; //rigid body for object
    public float speed; //can change variable in unity I think

    public float topBorder;
    public float bottomBorder;
    public float rightBorder;
    public float leftBorder;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //reference gameobject (player) looks for rigidbody2d and saves to rb

    }

    //Update called once per frame
    void Update()
    {
        //float xSpeed=Input.GetAxis("Horizontal");
        //float ySpeed=Input.GetAxis("Vertical");

        //Set Velocity by GetKey 
        float xSpeed = 0f;
        float ySpeed = 0f;

        //print(xSpeed); //will appear at the bottom of screen-cool

        // jk dont use this >>> transform.Translate(new Vector2(xSpeed, ySpeed) * speed); 


        if (Input.GetKey(KeyCode.D) && transform.position.x < rightBorder) //D before A means D takes precedence
        {
            xSpeed = 1;
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.x > leftBorder)
        {
            xSpeed = -1;
        }

        if (Input.GetKey(KeyCode.W) && transform.position.y < topBorder)
        {
            ySpeed = 1;
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.y > bottomBorder)
        {
            ySpeed = -1;
        }

        //rb.AddForce(new Vector2(xSpeed, ySpeed)*speed); //we're just doing velocity

        rb.velocity = new Vector2(xSpeed, ySpeed) * speed;
    }

}
