using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Items",menuName ="items/item")]
public class Item : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Sprite itemImage;
    
    //アイテムオブジェクトの変数。
    [SerializeField]
    private ItemObject itemObj;

    public string MyItemName { get => itemName; }
    public Sprite MyItemImage { get => itemImage; }


  
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    /// <summary>
    /// プレハブをインスタンスかする機能を追加
    /// </summary>
    /// <returns></returns>
    public GameObject GetItemObj()
    {
        //変数 goを用意
        GameObject go = Instantiate(itemObj.gameObject);
        //ItemObjectのOnmakeObjectを呼び出す.
        //goからItemObjectインスタンスを見つけ出す
        ////引数として自分自身を返す..
        go.GetComponent<ItemObject>().OnMakeObject(this);
        //戻り値はインスタンス化したメソッド
        return go;
    }
}
