using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
