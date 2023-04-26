using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverClass : MonoBehaviour
{
    public string deliverString;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
