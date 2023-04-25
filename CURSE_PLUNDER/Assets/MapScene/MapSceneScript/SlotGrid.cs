using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
  

    [SerializeField]
    private GameObject slotPrefab;

    private int slotNumber = 20;

    [SerializeField]
    private Item[] allItems;

    private List<Slot> allSlots;

    private static SlotGrid instance;
    private int Length;

    //状態を意地
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static SlotGrid Instance
    {
        get
        {
            SlotGrid[] instances = null;
            if(instance==null)
            {
                instance = FindObjectOfType<SlotGrid>();
                if(instance.Length==0)
                {
                    Debug.LogError("スロットグリットのインスタンスが見つからねぇ");
                    return null;
                }
                else if(instance.Length>1)
                {
                    Debug.LogError("SlotGridのインスタンスが複数に存在してます.");
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
            allSlots.Add(slot);

      

        }

        foreach(var item in allItems)
        {
            AddItem(item);
        }

    }

    public bool AddItem(Item item)
    {
        foreach(var slot in allSlots)
        {
            if(slot.MyItem==null)
            {
                slot.SetItem(item);
                return true;
            }
        }
        return false;
    }
}
