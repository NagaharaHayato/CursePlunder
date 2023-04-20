using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //�A�C�e���f�[�^�x�[�X
    [SerializeField]
    private ItemDataBase itemDataBase;
    //�A�C�e�����Ǘ�
    private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();

    //Use this for initialization
    void Start()
    {
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            //�A�C�e������K���ɐݒ肷��B
            numOfItem.Add(itemDataBase.GetItemLists()[i], i);

            //�m�F�̂��߂̃f�[�^�o��
            Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ":" + itemDataBase.GetItemLists()[i].GetInformation());
        }
        //�A�C�e���o�Ă邩�̃f�o�b�O
        Debug.Log(GetItem("�A�C�e����1").GetInformation());
        Debug.Log(numOfItem[GetItem("�A�C�e��2")]);
        
    }
    //���O�ŃA�C�e���擾
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
