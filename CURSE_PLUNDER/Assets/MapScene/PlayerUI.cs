using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    //���b�Z�[�W���o���I�u�W�F�N�g��I��
    /// </summary>
    public GameObject WindowObject;
    //���b�Z�[�W�E�B���h�E�͔�\��
    bool Wenabled = false;
    
    private void FixedUpdate()
    {
        //�G�ꂽ�ꍇ�ɃE�B���h�E���Z�b�g
        WindowObject.SetActive(Wenabled);
    }
    // Start is called before the first frame update
    //�Ԃ������ꍇ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ///�\��
            Wenabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //���ꂽ�̂Ŕ�\��
        Wenabled = false;
    }
}