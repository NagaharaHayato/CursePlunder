using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputfield : MonoBehaviour
{
    public Text texstring;

    private void Start()
    {
        //Deliverclass取得
        DeliverClass deliver = FindObjectOfType<DeliverClass>();
        //DelliverClsssから文字列を取得してセット
        texstring.text = deliver.deliverString;
    }
}
