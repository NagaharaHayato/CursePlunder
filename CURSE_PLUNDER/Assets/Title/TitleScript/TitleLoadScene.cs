using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLoadScene : MonoBehaviour
{
    //�{�^���ړ�

    public InputField inputField;
    public void LoadNewScene()
    {

        //Deliverclass�擾
        DeliverClass deliver = FindObjectOfType<DeliverClass>();
        //inputField�̕������deliver�ɓn��
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
