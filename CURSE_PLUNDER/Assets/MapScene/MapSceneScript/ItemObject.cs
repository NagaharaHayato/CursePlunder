using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemObject : MonoBehaviour
{
    private Item Item { get; set; }
   public void OnMakeObject(Item item)
    {
        Item = item;
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeItem();
        }
    }

    ////èÛë‘Çà”ín
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    public bool TakeItem()
    {
        if (SlotGrid.Instance.AddItem(Item))
        {
            Destroy(this.gameObject);
            return true;

        }       
        return false;
    }
}
