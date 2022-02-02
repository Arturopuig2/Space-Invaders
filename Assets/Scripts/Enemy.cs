using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemyForce=2f; //Velocidad a la que se desplaza.
    Rigidbody2D enemyRB;
    public int direccion=1;
    public float enemyPosition;
    AudioSource audioSource;
    public AudioClip explosion;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void movimiento()
    {
        enemyPosition = enemyRB.position.x;
        enemyRB.velocity = (transform.right * direccion * enemyForce); //Se mueve a la dcha. Si quiero a la izq. tengo que darle -1
        if (enemyPosition >= 5.00f){
            direccion = -1;
            enemyForce = enemyForce + 2f;
            transform.Translate(Vector3.down * 0.2f);
           // audioSource.PlayOneShot(explosion);
           // audioSource.Play();
        }
        else if (enemyPosition <= -5.00){
            direccion = +1;
            enemyForce = enemyForce + 0.02f;
            transform.Translate(Vector3.down * 0.2f);
        }
    }
        void OnCollisionEnter2D(Collision2D collision)
        {
        audioSource.PlayOneShot(explosion);
        gameObject.GetComponent<YouWin>().enabled = true;
        Debug.Log("ENEMIGO: Me ha dado el torpedo.");
    }


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
        movimiento();
     //   tocado();
    }
    //ALTERNATIVA: Cuando entres, cambia la dirección del desplazamiento.
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("he chocado con el margen: " + collision.gameObject.name);
    //    direccion = direccion * -1;
    //}
}
