using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chest : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Sprite openImage;
    [SerializeField] private Sprite closeImage;

    private bool isOpened = false;
    private SpriteRenderer spriteRenderer;
   

    public bool IsOpened
    {
        get => isOpened; set
        {
            isOpened = value;
            spriteRenderer.sprite = value ? openImage : closeImage;
        }
    }
    //protected override string

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    //protected override void OnClick()
    //{
    //    SlotGrid
    //}
    //プレイヤーが触れた場合にアイテムを拾う
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("チェスト開きます。");
            SlotGrid.Instance.GetItem(item);
            IsOpened = true;

        }
    }

}
