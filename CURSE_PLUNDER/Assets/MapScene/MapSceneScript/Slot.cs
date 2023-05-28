using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour
{
    private Item item;
   // public static Slot singleton;

    [SerializeField]
    private UnityEngine.UI.Image itemImage;

    //状態を意地




    public Item MyItem { get => item; private set => item = value; }

    //public void Start()
    //{
    //    PlayerPrefs.GetString(key,ItemObject)
    //}

    public void Update()
    {
        //エンターで捨てる
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (MyItem == null) return;

            //ItemObjectを生成する。
            GameObject itemObj = MyItem.GetItemObj();

          
            //for　debugging
            //戻り値を保持する変数 ItemObjを用意する。
            //手に入れたアイテムの位置を調整するコード
            itemObj.transform.SetParent(GameObject.Find("PlayerCanvas").transform, false);


            //アイテムを捨てる
            SetItem(null);
            // アイテム消失
           // Object.Destroy(itemObj);
           



        }
         
    }

    //アイテムを使う時の処理
    public void SetItem(Item item)
    {
        MyItem = item;
        
        if(item!=null)
        {
            itemImage.color = new Color(1,1,1,1);
            itemImage.sprite = item.MyItemImage;
        }
        else
        {
            itemImage.color = new Color(0, 0, 0, 0);
        }
            
        
    }
}
