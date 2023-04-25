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
    [SerializeField]
    private ItemObject itemObj;

    public string MyItemName { get => itemName; }
    public Sprite MyItemImage { get => itemImage; }

    //ó‘Ô‚ğˆÓ’n
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    public GameObject GetItemObj()
    {
        GameObject go = Instantiate(itemObj.gameObject);
        go.GetComponent<ItemObject>().OnMakeObject(this);
        return go;
    }
}
