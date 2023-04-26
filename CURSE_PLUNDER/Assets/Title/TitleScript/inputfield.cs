using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputfield : MonoBehaviour
{
    public Text texstring;

    private void Start()
    {
        //DeliverclassŽæ“¾
        DeliverClass deliver = FindObjectOfType<DeliverClass>();
        //DelliverClsss‚©‚ç•¶Žš—ñ‚ðŽæ“¾‚µ‚ÄƒZƒbƒg
        texstring.text = deliver.deliverString;
    }
}
