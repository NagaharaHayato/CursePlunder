using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SerializeField]
[CreateAssetMenu(fileName ="Item",menuName ="CreateItem")]
public class Item : ScriptableObject
{
   public enum KindOfItem
    {
        Weapon=0,
        UseItem=1
    }

    //アイテム識別用id
    [SerializeField] private string _id;
    //idを取得
    public string id
    {
        get { return _id; }
    }

    //アイテムの種類
    [SerializeField]
    private KindOfItem kindOfItem;

    //アイテムのアイコン
    [SerializeField]
    private Sprite icon;

    //アイテムの名前
    [SerializeField]
    private string itemName;

    //アイテムの情報
    [SerializeField]
    private string information;

    public KindOfItem GetKindOfItem()
    {
        return kindOfItem;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetItemName()
    {
        return itemName;
    }
    public string GetInformation()
    {
        return information;
    }
}
