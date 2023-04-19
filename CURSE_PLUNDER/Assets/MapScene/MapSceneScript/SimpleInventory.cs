using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleInventory : MonoBehaviour
{
    [SerializeField]
    GameObject iconPrehab = null;
    [SerializeField]
    Transform iconParent = null;
    [SerializeField]
    InventoryItem[] items = null;

    //アイテムを持っているかのフラグ
    bool[] itemFlags;

    //アイテムをアイテムで管理するプログラム
    Dictionary<int, GameObject> icons = new Dictionary<int, GameObject>();

   void Start()
    {
        itemFlags = new bool[items.Length];
    }

    //アイテムを持っているかを確認するメソッド
    public bool GetItemFlag(string itemName)
    {
        int index = GetItemIndexFromName(itemName);
        return itemFlags[index];


    }

    public void SetItem(string itemName,bool isOn)
    {
        int index = GetItemIndexFromName(itemName);
        if (!itemFlags[index]&&isOn)
        {
            //アイテム未所持の状態で新しく入力した場合、
            //新しいアイコンを作成し、インベントリのキャンバスを作成。
            GameObject icon = Instantiate(iconPrehab, iconParent);

            //アイコンの画像を設定
            icon.GetComponent<Image>().sprite = items[index].itemSprite;

            icons.Add(index, icon); 
        }
        else if (itemFlags[index]&&!isOn)
        {
            //アイテム中に削除するとき
            GameObject icon = icons[index];
            //アイテムのアイコンを削除
            Destroy(icon);
            //アイコンのディレクショナリから対象のアイテムを削除
            icons.Remove(index);
        }
        itemFlags[index] = isOn;
    }
    int GetItemIndexFromName(string itemName)
    {
        for(int i=0;i<items.Length;i++)
        {
            if (items[i].itemName==itemName)
            {
                return 1;
            }
        }
        return 0;
    }


    [System.Serializable]
    public class InventoryItem
    {
        public string itemName = "";
        public Sprite itemSprite = null;
    }

}
