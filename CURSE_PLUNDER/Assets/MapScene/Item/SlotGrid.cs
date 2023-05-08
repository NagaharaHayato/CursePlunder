using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    private static SlotGrid instance;
    public static SlotGrid Instance { get {
            if (instance == null) instance = FindObjectOfType<SlotGrid>();
            return instance;
        } }
    [SerializeField] private int slotNumber;
    [SerializeField] private GameObject slotPrefab;
    private List<Slot> allSlots=new List<Slot>();
    [SerializeField] private List<Item> allItems;

    private void Start()
    {
        //全アイテムの格納先
        for(int i=0;i<slotNumber;i++)
        {
            Slot slot=Instantiate(slotPrefab, this.transform).GetComponent<Slot>();

            ////slotにallitemを挿入
            allSlots.Add(slot);

            //////動作確認用
            //foreach (var item in allItems)
            //{
            //    GetItem(item);

            //}
        }

    }
    public void GetItem(Item item)
    {
        foreach (var slot in allSlots)
        {
            if (slot.SetItem(item)) return;

        }
        Debug.Log("持ち物がいっぱい。");

    }

    ////public static SlotGrid singleton;

    //[SerializeField]
    //private GameObject slotPrefab;

    //private int slotNumber = 4;

    //[SerializeField]
    //private Item[] allItems;

    //private List<Slot> allSlots;

    //private static SlotGrid instance;
    //private int Length;




    ////// Use this for initialization
    ////void Awake()
    ////{
    ////    //　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
    ////    if (singleton == null)
    ////    {
    ////        DontDestroyOnLoad(gameObject);
    ////        singleton = this;
    ////        //　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
    ////    }
    ////    else
    ////    {
    ////        Destroy(gameObject);
    ////    }
    ////}



    ////スロット内に存在する、スロットを保持するリストを作成する。
    //public static SlotGrid Instance
    //{
    //    get
    //    {
    //        ///ItemObject用のスロットグリッドインスタンス
    //        SlotGrid[] instances = null;
    //        if(instance==null)
    //        {
    //            instance = FindObjectOfType<SlotGrid>();
    //            if(instance.Length==0)
    //            {
    //                Debug.LogError("スロットグリットのインスタンスが見つからねぇ");
    //                return null;
    //            }
    //            else if(instance.Length>1)
    //            {
    //                Debug.LogError("SlotGridのインスタンスが複数に存在してます.");
    //                return null;
    //            }
    //            else
    //            {
    //                instance = instances[0];
    //            }
    //        }
    //        return instance;
    //    }

    //}

    //void Start()
    //{


    //    allSlots = new List<Slot>();
    //    for(int i=0;i<slotNumber;i++)
    //    {
    //        GameObject slotObj = Instantiate(slotPrefab, this.transform);

    //        Slot slot = slotObj.GetComponent<Slot>();
    //        //ここでスロットすべて入った。
    //        allSlots.Add(slot);



    //    }

    //    ////動作確認用
    //    ////foreach (var item in allItems)
    //    ////{
    //    ////    AddItem(item);

    //    ////}



    //}
    ////グリッドで新しくアイテムを追加するメソッド。
    //public bool AddItem(Item item)
    //{

    //    foreach (var slot in allSlots)
    //    {
    //        //slot.MyItemがnullなら空っぽ
    //        if(slot.MyItem==null)
    //        {
    //            //アイテムをつかうときはSetItemを使用.
    //            slot.SetItem(item);

    //            return true;
    //        }
    //    }
    //    //すべてのスロットにアイテムが入っていたら foreachを抜けfalseで返す
    //    return false;
    //}
}
