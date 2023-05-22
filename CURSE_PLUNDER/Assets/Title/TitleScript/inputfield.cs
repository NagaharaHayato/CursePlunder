using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputfield : MonoBehaviour
{
    public Text texstring;

    private void Start()
    {
        ////DeliverclassŽæ“¾
        //PlayerStat Player_Stat = FindObjectOfType<PlayerStat>();
        ////DelliverClsss‚©‚ç•¶Žš—ñ‚ðŽæ“¾‚µ‚ÄƒZƒbƒg
        //texstring.text = Player_Stat.PlayerName;

        DeliverClass deliver= FindObjectOfType<DeliverClass>();
        texstring.text = deliver.deliverString;
    }
}
