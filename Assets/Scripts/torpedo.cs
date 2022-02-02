using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedo : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Enemigo")
        {
            Debug.Log("TORPEDO: HE DERRIBADO A UN: " + collision.gameObject.tag);
            audioSource=collision.gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TORPEDO: He chocado con  " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
