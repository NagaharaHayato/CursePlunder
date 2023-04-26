using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour,IPointerClickHandler
{
    private Item item;

    [SerializeField]
    private UnityEngine.UI.Image itemImage;

    //状態を意地
  

    public Item MyItem { get => item; private set => item = value; }

    public void OnPointerClick(PointerEventData eventData)
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
    }

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
