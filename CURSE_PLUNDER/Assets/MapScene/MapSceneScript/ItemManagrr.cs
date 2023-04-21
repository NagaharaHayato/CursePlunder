using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemData
{
    public string id;//アイテムid

    private int count;//所持数

    public ItemData(string id,int count)
    {
        this.id = id;
        this.count = count;

    }

    //所持数カウントアップ
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
