using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    //メッセージを出すオブジェクトを選択
    /// </summary>
    public GameObject WindowObject;
    //メッセージウィンドウは非表示
    bool Wenabled = false;
    
    private void FixedUpdate()
    {
        //触れた場合にウィンドウをセット
        WindowObject.SetActive(Wenabled);
    }
    // Start is called before the first frame update
    //ぶつかった場合
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ///表示
            Wenabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //離れたので非表示
        Wenabled = false;
    }
}