using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerClider : MonoBehaviour
{
    // Start is called before the first frame update
 void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Out"))
        {
            
                SceneManager.LoadScene("MapScene");
         
            
        }
        if (collision.gameObject.CompareTag("Home"))
        {
            SceneManager.LoadScene("HomeScene");


        }
        if (collision.gameObject.CompareTag("BattleGo"))
        {
            SceneManager.LoadScene("MapScene2");


        }
        if (collision.gameObject.CompareTag("Cave"))
        {
            SceneManager.LoadScene("CaveScene");


        }

    }
}