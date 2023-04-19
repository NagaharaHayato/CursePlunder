//�A�C�e�����f�[�^�x�[�X�ɑ��݂��邩�m�F����B
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private ItemDataBase itemDataBase;

    static ItemManager instance;

    //�C���X�^���X�������Čٗp�ł͂Ȃ���
    public static ItemManager GetInstance()
    {
        return instance;
    }

    //Use this for Initialization
    void Start()
    {
        instance = this;
    }

    public bool HasItem(string searchName)
    {
        return itemDataBase.GetItemLists().Exists(item => item.GetItemName() == searchName);
    }


}
