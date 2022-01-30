using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("he chocado con: "+collision.gameObject.name);
        //Debug.Log("he chocado con: " + collision.gameObject.tag);
        Destroy(gameObject);

        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("he chocado con: " + collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
    }
}
