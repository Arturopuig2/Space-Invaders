using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public int speed;
    Rigidbody2D myRB;
    public int force;
    public int forceTorpedo;
    public GameObject torpedo;
    public GameObject clone;
    public float TiempoDeVida=2f;
    public bool cloneFuera = true;
    public bool fin = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB =GetComponent<Rigidbody2D>();

       // Instantiate(torpedo, transform.position, Quaternion.identity);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        myRB.velocity=(transform.right*movement*force);
        float xPos = Mathf.Clamp(myRB.position.x, -5f, 5f);
        myRB.position = new Vector2(xPos, myRB.position.y);


        if (Input.GetButton("Jump")&&!clone&&!fin)
            {
            //Debug.Log("He pulsado disparo");
            Vector2 posTorpedo = new Vector2(transform.position.x, transform.position.y+1.5f);

                clone = Instantiate(torpedo, posTorpedo, Quaternion.identity); //Creamos un GO que es la instanciación del Torpedo.
                Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>(); //Creamos una variable de tipo Rigidbody2D con las cualidades del RB del clone.
                Vector2 direccion = new Vector2(0f, 1f);
                cloneRB.velocity = direccion * forceTorpedo;
              //  Destroy(clone, TiempoDeVida); //Destruye el clone después del tiempo de vida.
            }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NAVE: Entro al área");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("NAVE: He chocado con " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemigo")
        {
            myRB.freezeRotation = true;
            myRB.constraints = RigidbodyConstraints2D.FreezeAll;
            //myRB.constraints = RigidbodyConstraints2D.FreezePositionX;
            Destroy(collision.gameObject);
            Debug.Log("FIN");
            fin = true;
            gameObject.GetComponent<GameOver>().enabled = true;

        }
    }    
}