using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SerializeField]
[CreateAssetMenu(fileName ="Item",menuName ="CreateItem")]
public class Item : ScriptableObject
{
   public enum KindOfItem
    {
        Weapon=0,
        UseItem=1
    }

    //�A�C�e�����ʗpid
    [SerializeField] private string _id;
    //id���擾
    public string id
    {
        get { return _id; }
    }

    //�A�C�e���̎��
    [SerializeField]
    private KindOfItem kindOfItem;

    //�A�C�e���̃A�C�R��
    [SerializeField]
    private Sprite icon;

    //�A�C�e���̖��O
    [SerializeField]
    private string itemName;

    //�A�C�e���̏��
    [SerializeField]
    private string information;

    public KindOfItem GetKindOfItem()
    {
        return kindOfItem;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetItemName()
    {
        return itemName;
    }
    public string GetInformation()
    {
        return information;
    }
}
