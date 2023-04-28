using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemObject : MonoBehaviour
{


    ////Itemを保持
    //private Item Item { get; set; }
    ////オブジェクトを捨てる時に地面にオブジェクトが生成される機能。
    //public void OnMakeObject(Item item)
    //{
    // Item = item;
    //}



    ////プレイヤーが触れた場合にアイテムを拾う
    //void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("あああ");
    //        TakeItem();
           
    //    }
    //}

    ////オブジェクトを拾う
    //public bool TakeItem()
    //{
    //    //スロットグリッドのインスタンスを拾ってくる。
    //    if (SlotGrid.Instance.AddItem(Item))
    //    {
    //        Debug.Log("消えろ");
    //        //自分自身を消してtrueを返す
    //        Destroy(this.gameObject);

    //        //trueが返ってきたら成功
    //        return true;

    //    }
    //    //失敗した場合。
    //    return false;
    //}
}
