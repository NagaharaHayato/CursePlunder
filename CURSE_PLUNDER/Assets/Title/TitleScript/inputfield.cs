using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputfield : MonoBehaviour
{
    public Text texstring;

    private void Start()
    {
        //Deliverclass�擾
        DeliverClass deliver = FindObjectOfType<DeliverClass>();
        //DelliverClsss���當������擾���ăZ�b�g
        texstring.text = deliver.deliverString;
    }
}
