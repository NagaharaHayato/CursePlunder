using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLoadScene : MonoBehaviour
{
    //ƒ{ƒ^ƒ“ˆÚ“®

    public InputField inputField;
    public void LoadNewScene()
    {

        //DeliverclassŽæ“¾
        DeliverClass deliver = FindObjectOfType<DeliverClass>();
        //inputField‚Ì•¶Žš—ñ‚ðdeliver‚É“n‚·
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
