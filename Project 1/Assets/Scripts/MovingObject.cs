using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public int speed;
    protected Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //moving object as potion or fireball, whichever
    }

    public void movement(int speed)
    {
        rb.velocity = new Vector2(0f, -speed); //move that ish
    }

}