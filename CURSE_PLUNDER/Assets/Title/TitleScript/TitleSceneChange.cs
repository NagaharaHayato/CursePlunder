using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChange : MonoBehaviour
{
    /// <summary>
    //���b�Z�[�W���o���I�u�W�F�N�g��I��
    /// </summary>
    public GameObject WindowObject;
    public GameObject WindowObject2;

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
    public void Update()
    {
        //�{�^���������ꂽ�ꍇ ���O����͗��Ɉڍs

        if (Input.GetKeyDown(KeyCode.E))
        {
            Wenabled = false;
            Wenabled2 = true;
            // Wenabled3 = true;
        }
        // Wenabled3 = true
    }
    //���̋t
    public void LoadWanabled2()
    {
        Wenabled = true;
        Wenabled2 = false;

    }
}