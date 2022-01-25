using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int enemyForce; //Velocidad a la que se desplaza.
    Rigidbody2D enemyRB;
    public int direccion=1;
    public float enemyPosition;


    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
    }

    private void FixedUpdate()
    {
        enemyPosition = enemyRB.position.x;
        Debug.Log(enemyPosition);
        enemyRB.velocity = (transform.right*direccion* enemyForce); //Se mueve a la dcha. Si quiero a la izq. tengo que darle -1

        if (enemyPosition>5)
        {
            Debug.Log("SOY MAYOR QUE 5");
            direccion = -1;
        }
        else if(enemyPosition<-5)
        {
            Debug.Log("SOY MENOR QUE 5");
            direccion = +1;
        }


    }
    //ALTERNATIVA: Cuando entres, cambia la dirección del desplazamiento.
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("he chocado con el margen: " + collision.gameObject.name);
    //    direccion = direccion * -1;
    //}


}
