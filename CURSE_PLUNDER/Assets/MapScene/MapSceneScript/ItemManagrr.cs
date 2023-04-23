using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;
using UnityEditor.Search;

public class ItemData
{
    public string id;//�A�C�e��id

    private int count;//������

    public ItemData(string id,int count)
    {
        this.id = id;
        this.count = count;

    }

    //�������J�E���g�A�b�v
    public void CountUp(int value=1)
    {
        count += value;
    }
    public void CountDown(int value=1)
    {
        count -= value;
    }
}

public class ItemManagrr : MonoBehaviour
{
    [SerializeField] private List<Item> _item;//�A�C�e���f�[�^�x�[�X

    private List<ItemData> _PlayerItemDataList = new List<ItemData>();//�v���C���[�̏����A�C�e��

    private void Awake()
    {
        LoadItemSourceData();  
    }

    private void LoadItemSourceData()
    {
        _item = Resources.LoadAll("ScriptableObject", typeof(Item)).Cast<Item>().ToList();
    }
    //�A�C�e�������[�h����
    public Item GetItem(string id)
    {
        foreach(var sourceData in _item)
        {
            if(sourceData.id==id)
            {
                return sourceData;
            }
        }
        return null;
    }

    //�A�C�e�����擾
    public void CountItem(string itemid,int count)
    {
        for(int i=0;i<_PlayerItemDataList.Count;i++)
        {
            //ID��v�ŃJ�E���g
            if (_PlayerItemDataList[i].id==itemid)
            {
                _PlayerItemDataList[i].CountUp(count);
                break;
            }
        }
        ItemData itemData = new ItemData(itemid, count);
        _PlayerItemDataList.Add(itemData);
    }

}
