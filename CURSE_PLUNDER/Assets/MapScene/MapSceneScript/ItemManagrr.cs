using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;
using UnityEditor.Search;

public class ItemData
{
    public string id;//アイテムid

    private int count;//所持数

    public ItemData(string id,int count)
    {
        this.id = id;
        this.count = count;

    }

    //所持数カウントアップ
    public void CountUp(int value=1)
    {
        count += value;
    }
    public void CountDown(int value=1)
    {
        count -= value;
    }
}

public class ItemManagrr : MonoBehaviour
{
    [SerializeField] private List<Item> _item;//アイテムデータベース

    private List<ItemData> _PlayerItemDataList = new List<ItemData>();//プレイヤーの所持アイテム

    private void Awake()
    {
        LoadItemSourceData();  
    }

    private void LoadItemSourceData()
    {
        _item = Resources.LoadAll("ScriptableObject", typeof(Item)).Cast<Item>().ToList();
    }
    //アイテムをロードする
    public Item GetItem(string id)
    {
        foreach(var sourceData in _item)
        {
            if(sourceData.id==id)
            {
                return sourceData;
            }
        }
        return null;
    }

    //アイテムを取得
    public void CountItem(string itemid,int count)
    {
        for(int i=0;i<_PlayerItemDataList.Count;i++)
        {
            //ID一致でカウント
            if (_PlayerItemDataList[i].id==itemid)
            {
                _PlayerItemDataList[i].CountUp(count);
                break;
            }
        }
        ItemData itemData = new ItemData(itemid, count);
        _PlayerItemDataList.Add(itemData);
    }

}
