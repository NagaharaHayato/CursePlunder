using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatasOpen : MonoBehaviour
{
    /// <summary>
    //メッセージを出すオブジェクトを選択
    /// </summary>
    public GameObject WindowObject;
    public GameObject WindowObject2;
    public GameObject WindowObject3;
    //オープン用メッセージウィンドウは表示扱い
    bool Wenabled = true;
    
    //ステータスウィンドウは非表示扱い
    bool Wenabled2 = false;

    //bool Wenabled3 = false;


    private void FixedUpdate()
    {
        //ウィンドウをセット
        WindowObject.SetActive(Wenabled);
        //ウィンドウ2をセット
        WindowObject2.SetActive(Wenabled2);

        //ウィンドウ2をセット
        //WindowObject3.SetActive(Wenabled3);

    }
    private void Update()
    {
        //Xキーが押された場合 ステータスオープン
        if (Input.GetKeyDown(KeyCode.X))
        {
            Wenabled = false;
            Wenabled2 = true;
           // Wenabled3 = true;
        }
        //閉じる
        if(Input.GetKeyDown(KeyCode.D))
        {
            Wenabled = true;
            Wenabled2 = false;
           
        }



    }
}