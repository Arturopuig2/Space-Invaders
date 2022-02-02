using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverText;


    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(true);
        //    GameOverText.GetComponent<TextMesh>().text = "GAME OVER";

    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
