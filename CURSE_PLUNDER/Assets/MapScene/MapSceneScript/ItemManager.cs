using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //アイテムデータベース
    [SerializeField]
    private ItemDataBase itemDataBase;
    //アイテム数管理
    private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();

    //Use this for initialization
    void Start()
    {
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            //アイテム数を適当に設定する。
            numOfItem.Add(itemDataBase.GetItemLists()[i], i);

            //確認のためのデータ出力
            Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ":" + itemDataBase.GetItemLists()[i].GetInformation());
        }
        //アイテム出てるかのデバッグ
        Debug.Log(GetItem("アイテム仮1").GetInformation());
        Debug.Log(numOfItem[GetItem("アイテム2")]);
        
    }
    //名前でアイテム取得
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
