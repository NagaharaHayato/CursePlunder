using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

#pragma warning disable CS0618

public class PlayerDemoMap : MonoBehaviour
{
    Rigidbody2D PlayerRB;   //��l���̈ړ��Ŏg�p���郊�W�b�h�{�f�B

    //�Ō�̓��͂��ꂽ�������o���Ă������߃x�N�^�[
    Vector2 lastmove = new Vector2(0, 0);

    [SerializeField]
    private float MOVE_SPEED = 60.0f;   //��l���̈ړ����x

    void Start()
    {
        //���W�b�h�{�f�B�̊֘A�t��
        this.PlayerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //�����L�[�̓��͏�Ԃ��擾
        Vector2 moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //�����L�[�����͂���Ă����ꍇ
        if (moveact != Vector2.zero)
        {

            //��l���̈ړ������ƍŌ�̓��͂��o���Ă���
            PlayerRB.velocity = moveact.normalized * MOVE_SPEED;

            lastmove = moveact;
        }
        else
        {
            //�������͂���Ă��Ȃ��ꍇ�́uWalk�v��Ԃ���uWait�v��
            //���t���O�ŊǗ�����`�ɂ��Ă���̂ŁuWalk�v��false�ɂ����
            //�����I�Ɂu�ҋ@���(Wait)�v�ɏ�Ԃ��ς��悤�ɂȂ���
            PlayerRB.velocity = Vector2.zero;
        }


    }
}