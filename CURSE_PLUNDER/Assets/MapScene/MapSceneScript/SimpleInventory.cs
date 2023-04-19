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

    //�A�C�e���������Ă��邩�̃t���O
    bool[] itemFlags;

    //�A�C�e�����A�C�e���ŊǗ�����v���O����
    Dictionary<int, GameObject> icons = new Dictionary<int, GameObject>();

   void Start()
    {
        itemFlags = new bool[items.Length];
    }

    //�A�C�e���������Ă��邩���m�F���郁�\�b�h
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
            //�A�C�e���������̏�ԂŐV�������͂����ꍇ�A
            //�V�����A�C�R�����쐬���A�C���x���g���̃L�����o�X���쐬�B
            GameObject icon = Instantiate(iconPrehab, iconParent);

            //�A�C�R���̉摜��ݒ�
            icon.GetComponent<Image>().sprite = items[index].itemSprite;

            icons.Add(index, icon); 
        }
        else if (itemFlags[index]&&!isOn)
        {
            //�A�C�e�����ɍ폜����Ƃ�
            GameObject icon = icons[index];
            //�A�C�e���̃A�C�R�����폜
            Destroy(icon);
            //�A�C�R���̃f�B���N�V���i������Ώۂ̃A�C�e�����폜
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
