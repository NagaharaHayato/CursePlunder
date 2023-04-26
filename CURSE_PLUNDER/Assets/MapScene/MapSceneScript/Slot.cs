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

    //��Ԃ��Ӓn
  

    public Item MyItem { get => item; private set => item = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MyItem == null) return;

        //ItemObject�𐶐�����B
        GameObject itemObj = MyItem.GetItemObj();

        //for�@debugging
        //�߂�l��ێ�����ϐ� ItemObj��p�ӂ���B
        //��ɓ��ꂽ�A�C�e���̈ʒu�𒲐�����R�[�h
        itemObj.transform.SetParent(GameObject.Find("PlayerCanvas").transform, false);

        //�A�C�e�����̂Ă�
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
