using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChange : MonoBehaviour
{
    /// <summary>
    //メッセージを出すオブジェクトを選択
    /// </summary>
    public GameObject WindowObject;
    public GameObject WindowObject2;

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
    public void Update()
    {
        //ボタンが押された場合 名前を入力欄に移行

        if (Input.GetKeyDown(KeyCode.E))
        {
            Wenabled = false;
            Wenabled2 = true;
            // Wenabled3 = true;
        }
        // Wenabled3 = true
    }
    //その逆
    public void LoadWanabled2()
    {
        Wenabled = true;
        Wenabled2 = false;

    }
}