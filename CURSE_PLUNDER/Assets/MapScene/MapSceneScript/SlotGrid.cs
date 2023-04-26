using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
  

    [SerializeField]
    private GameObject slotPrefab;

    private int slotNumber = 4;

    [SerializeField]
    private Item[] allItems;

    private List<Slot> allSlots;

    private static SlotGrid instance;
    private int Length;

    //スロット内に存在する、スロットを保持するリストを作成する。
    public static SlotGrid Instance
    {
        get
        {
            ///ItemObject用のスロットグリッドインスタンス
            SlotGrid[] instances = null;
            if(instance==null)
            {
                instance = FindObjectOfType<SlotGrid>();
                if(instance.Length==0)
                {
                    Debug.LogError("スロットグリットのインスタンスが見つからねぇ");
                    return null;
                }
                else if(instance.Length>1)
                {
                    Debug.LogError("SlotGridのインスタンスが複数に存在してます.");
                    return null;
                }
                else
                {
                    instance = instances[0];
                }
            }
            return instance;
        }
    }

    void Start()
    {
        allSlots = new List<Slot>();
        for(int i=0;i<slotNumber;i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, this.transform);

            Slot slot = slotObj.GetComponent<Slot>();
            //ここでスロットすべて入った。
            allSlots.Add(slot);

      

        }

        //動作確認用
        foreach(var item in allItems)
        {
            AddItem(item);
        }

    }
    //グリッドで新しくアイテムを追加するメソッド。
    public bool AddItem(Item item)
    {
        foreach(var slot in allSlots)
        {
            //slot.MyItemがnullなら空っぽ
            if(slot.MyItem==null)
            {
                //アイテムをつかうときはSetItemを使用.
                slot.SetItem(item);
                //アイテム回収した場合はtrue
                return true;
            }
        }
        //すべてのスロットにアイテムが入っていたら foreachを抜けfalseで返す
        return false;
    }
}
