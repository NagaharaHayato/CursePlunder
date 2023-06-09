using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLoadScene : MonoBehaviour
{
    //ボタン移動

    public InputField inputField;

    public void CheckTextCount()
    {
        Debug.Log(inputField.text.Length);

        if (inputField.text.Length > 10)
        {
            inputField.text = inputField.text[..10];
        }
    }

    public void LoadNewScene()
    {

        //Deliverclass取得
        DeliverClass deliver = FindObjectOfType<DeliverClass>();
        //inputFieldの文字列をdeliverに渡す
        deliver.deliverString = inputField.text;
        SceneManager.LoadScene("MapScene");
        
    }
    public void NameScene()
    {
        SceneManager.LoadScene("NameScene");

    }
    public void TitleScene()
    {
        SceneManager.LoadScene("Title");

    }
    public void CregitScene()
    {
        SceneManager.LoadScene("Cregit");

    }
}
