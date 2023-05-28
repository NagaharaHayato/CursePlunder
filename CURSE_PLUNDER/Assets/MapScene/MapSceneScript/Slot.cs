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

    //��Ԃ��Ӓn




    public Item MyItem { get => item; private set => item = value; }

    //public void Start()
    //{
    //    PlayerPrefs.GetString(key,ItemObject)
    //}

    public void Update()
    {
        //�G���^�[�Ŏ̂Ă�
        if (Input.GetKeyDown(KeyCode.Return))
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
            // �A�C�e������
           // Object.Destroy(itemObj);
           



        }
         
    }

    //�A�C�e�����g�����̏���
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
