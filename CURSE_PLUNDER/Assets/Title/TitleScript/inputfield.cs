using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputfield : MonoBehaviour
{
    public Text texstring;

    private void Start()
    {
        ////Deliverclass取得
        //PlayerStat Player_Stat = FindObjectOfType<PlayerStat>();
        ////DelliverClsssから文字列を取得してセット
        //texstring.text = Player_Stat.PlayerName;

        DeliverClass deliver= FindObjectOfType<DeliverClass>();
        texstring.text = deliver.deliverString;
    }
}
