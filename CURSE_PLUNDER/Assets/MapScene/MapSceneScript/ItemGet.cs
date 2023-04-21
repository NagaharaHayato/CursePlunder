using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemGet
{
    //アイテム取得可能
    [SerializeField] string itemName;
    GameObject gameObject;

    internal void Itemer(GameObject item)
    {
        gameObject = item;
        //inventory.GetInstance().Itemer(this);
    }
    
    internal string GetItemName()
    {
        return itemName;
    }

    internal GameObject GetGameObject()
    {
        return gameObject;
    }

    
}
