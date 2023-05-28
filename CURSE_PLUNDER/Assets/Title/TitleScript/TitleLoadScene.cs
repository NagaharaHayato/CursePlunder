using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLoadScene : MonoBehaviour
{
    //ƒ{ƒ^ƒ“ˆÚ“®

    public InputField inputField;

	void Awake()
	{
        Application.targetFrameRate = 60;
	}

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

        //PlayerStat Player_Stat = FindObjectOfType<PlayerStat>();
        ////inputField‚Ì•¶Žš—ñ‚ðdeliver‚É“n‚·
        //Player_Stat.PlayerName = inputField.text;
        DeliverClass deliver = FindObjectOfType<DeliverClass>();
        deliver.deliverString= inputField.text;
        SceneManager.LoadScene("MapScene");

    }
    public void NameScene()
    {
        SceneManager.LoadScene("MapScene");

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
