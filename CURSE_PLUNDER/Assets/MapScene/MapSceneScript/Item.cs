using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Items",menuName ="items/item")]
public class Item : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Sprite itemImage;
    
    //�A�C�e���I�u�W�F�N�g�̕ϐ��B
    [SerializeField]
    private ItemObject itemObj;

    public string MyItemName { get => itemName; }
    public Sprite MyItemImage { get => itemImage; }


  
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    /// <summary>
    /// �v���n�u���C���X�^���X������@�\��ǉ�
    /// </summary>
    /// <returns></returns>
    public GameObject GetItemObj()
    {
        //�ϐ� go��p��
        GameObject go = Instantiate(itemObj.gameObject);
        //ItemObject��OnmakeObject���Ăяo��.
        //go����ItemObject�C���X�^���X�������o��
        ////�����Ƃ��Ď������g��Ԃ�..
        go.GetComponent<ItemObject>().OnMakeObject(this);
        //�߂�l�̓C���X�^���X���������\�b�h
        return go;
    }
}
