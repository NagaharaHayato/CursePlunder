using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoadScene : MonoBehaviour
{
    //ボタン移動

    public void LoadNewScene()
    {
            SceneManager.LoadScene("MapScene2");
        
    }
}
