using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemObject : MonoBehaviour
{


    ////Item��ێ�
    //private Item Item { get; set; }
    ////�I�u�W�F�N�g���̂Ă鎞�ɒn�ʂɃI�u�W�F�N�g�����������@�\�B
    //public void OnMakeObject(Item item)
    //{
    // Item = item;
    //}



    ////�v���C���[���G�ꂽ�ꍇ�ɃA�C�e�����E��
    //void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("������");
    //        TakeItem();
           
    //    }
    //}

    ////�I�u�W�F�N�g���E��
    //public bool TakeItem()
    //{
    //    //�X���b�g�O���b�h�̃C���X�^���X���E���Ă���B
    //    if (SlotGrid.Instance.AddItem(Item))
    //    {
    //        Debug.Log("������");
    //        //�������g��������true��Ԃ�
    //        Destroy(this.gameObject);

    //        //true���Ԃ��Ă����琬��
    //        return true;

    //    }
    //    //���s�����ꍇ�B
    //    return false;
    //}
}
