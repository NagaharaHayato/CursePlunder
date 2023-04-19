//アイテムがデータベースに存在するか確認する。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private ItemDataBase itemDataBase;

    static ItemManager instance;

    //インスタンスから取って雇用ではないか
    public static ItemManager GetInstance()
    {
        return instance;
    }

    //Use this for Initialization
    void Start()
    {
        instance = this;
    }

    public bool HasItem(string searchName)
    {
        return itemDataBase.GetItemLists().Exists(item => item.GetItemName() == searchName);
    }


}
