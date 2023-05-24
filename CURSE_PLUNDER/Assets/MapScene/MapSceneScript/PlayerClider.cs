using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerClider : MonoBehaviour
{
    void Awake()
    {
        if(UIManager.HitEnemyObj != null)
        {
            Destroy(UIManager.HitEnemyObj);
            UIManager.HitEnemyObj = null;

        } 
    }
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

        if (collision.gameObject.CompareTag("Cave2"))
        {
            SceneManager.LoadScene("CaveScene2");


        }
        if (collision.gameObject.CompareTag("Cave3"))
        {
            SceneManager.LoadScene("CaveScene3");


        }

        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            UIManager.HitEnemyObj = collision.gameObject;
            SceneManager.LoadScene("BattleScene");
        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            UIManager.HitEnemyObj = collision.gameObject;
            SceneManager.LoadScene("BattleScene2");
        }
        if (collision.gameObject.CompareTag("Enemy3"))
        {
            UIManager.HitEnemyObj = collision.gameObject;
            SceneManager.LoadScene("BattleScene3");
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            SceneManager.LoadScene("BossFight");
        }
    }

}