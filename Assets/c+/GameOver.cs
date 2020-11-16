using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag=="Player")
        {
            gameOver.SetActive(true);
        }


    }
}
