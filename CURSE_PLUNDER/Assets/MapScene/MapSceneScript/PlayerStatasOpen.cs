using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatasOpen : MonoBehaviour
{
    /// <summary>
    //���b�Z�[�W���o���I�u�W�F�N�g��I��
    /// </summary>
    public GameObject WindowObject;
    public GameObject WindowObject2;
    public GameObject WindowObject3;
    //�I�[�v���p���b�Z�[�W�E�B���h�E�͕\������
    bool Wenabled = true;
    
    //�X�e�[�^�X�E�B���h�E�͔�\������
    bool Wenabled2 = false;

    //bool Wenabled3 = false;


    private void FixedUpdate()
    {
        //�E�B���h�E���Z�b�g
        WindowObject.SetActive(Wenabled);
        //�E�B���h�E2���Z�b�g
        WindowObject2.SetActive(Wenabled2);

        //�E�B���h�E2���Z�b�g
        //WindowObject3.SetActive(Wenabled3);

    }
    private void Update()
    {
        //X�L�[�������ꂽ�ꍇ �X�e�[�^�X�I�[�v��
        if (Input.GetKeyDown(KeyCode.X))
        {
            Wenabled = false;
            Wenabled2 = true;
           // Wenabled3 = true;
        }
        //����
        if(Input.GetKeyDown(KeyCode.D))
        {
            Wenabled = true;
            Wenabled2 = false;
           
        }



    }
}