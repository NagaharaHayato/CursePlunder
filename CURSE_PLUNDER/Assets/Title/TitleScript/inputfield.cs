using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputfield : MonoBehaviour
{
    public Text texstring;

    private void Start()
    {
        ////Deliverclass�擾
        //PlayerStat Player_Stat = FindObjectOfType<PlayerStat>();
        ////DelliverClsss���當������擾���ăZ�b�g
        //texstring.text = Player_Stat.PlayerName;

        DeliverClass deliver= FindObjectOfType<DeliverClass>();
        texstring.text = deliver.deliverString;
    }
}
