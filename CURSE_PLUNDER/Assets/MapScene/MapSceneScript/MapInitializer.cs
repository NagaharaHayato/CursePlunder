using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInitializer : MonoBehaviour
{
    [SerializeField] private Item item;

    void Start()
    {
        item.GetItemObj().transform.SetParent(this.transform,false);
    }
}
