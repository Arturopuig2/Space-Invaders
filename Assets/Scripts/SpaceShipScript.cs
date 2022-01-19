﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public int speed;
    Rigidbody2D myRB;
    public int force;
    public int forceTorpedo;
    public GameObject bala;
    public GameObject torpedo;

    // Start is called before the first frame update
    void Start()
    {
       myRB=GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        myRB.velocity=(transform.right*movement*force);


        float xPos = Mathf.Clamp(myRB.position.x, -3f, 3f);

        myRB.position = new Vector2(xPos, myRB.position.y);

        if (Input.GetButton("Jump"))
        {
            Debug.Log("he pulsado disparo");
        }
            if (Input.GetButton("Jump"))
            {

            Vector2 posTorpedo = new Vector2(transform.position.x, transform.position.y+1.5f);

           GameObject clone= Instantiate(torpedo, posTorpedo, Quaternion.identity);

            Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>();

            Vector2 direccion = new Vector2(0f,1f);

            cloneRB.velocity=direccion * forceTorpedo;
        }
    }
}