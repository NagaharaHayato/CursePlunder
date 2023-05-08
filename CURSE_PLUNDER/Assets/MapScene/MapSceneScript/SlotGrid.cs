using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    //public static SlotGrid singleton;

    [SerializeField]
    private GameObject slotPrefab;

    private int slotNumber = 4;

    [SerializeField]
    private Item[] allItems;

    private List<Slot> allSlots;

    private static SlotGrid instance;
    private int Length;




    //// Use this for initialization
    //void Awake()
    //{
    //    //�@�X�N���v�g���ݒ肳��Ă��Ȃ���΃Q�[���I�u�W�F�N�g���c���X�N���v�g��ݒ�
    //    if (singleton == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        singleton = this;
    //        //�@����GameStart�X�N���v�g������΂��̃V�[���̓����Q�[���I�u�W�F�N�g���폜
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}



    //�X���b�g���ɑ��݂���A�X���b�g��ێ����郊�X�g���쐬����B
    public static SlotGrid Instance
    {
        get
        {
            ///ItemObject�p�̃X���b�g�O���b�h�C���X�^���X
            SlotGrid[] instances = null;
            if(instance==null)
            {
                instance = FindObjectOfType<SlotGrid>();
                if(instance.Length==0)
                {
                    Debug.LogError("�X���b�g�O���b�g�̃C���X�^���X��������˂�");
                    return null;
                }
                else if(instance.Length>1)
                {
                    Debug.LogError("SlotGrid�̃C���X�^���X�������ɑ��݂��Ă܂�.");
                    return null;
                }
                else
                {
                    instance = instances[0];
                }
            }
            return instance;
        }

    }

    void Start()
    {

       
        allSlots = new List<Slot>();
        for(int i=0;i<slotNumber;i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, this.transform);

            Slot slot = slotObj.GetComponent<Slot>();
            //�����ŃX���b�g���ׂē������B
            allSlots.Add(slot);

      

        }

        ////����m�F�p
        ////foreach (var item in allItems)
        ////{
        ////    AddItem(item);

        ////}



    }
    //�O���b�h�ŐV�����A�C�e����ǉ����郁�\�b�h�B
    public bool AddItem(Item item)
    {
        
        foreach (var slot in allSlots)
        {
            //slot.MyItem��null�Ȃ�����
            if(slot.MyItem==null)
            {
                //�A�C�e���������Ƃ���SetItem���g�p.
                slot.SetItem(item);
               
                return true;
            }
        }
        //���ׂẴX���b�g�ɃA�C�e���������Ă����� foreach�𔲂�false�ŕԂ�
        return false;
    }
}