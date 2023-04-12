using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Act : MonoBehaviour
{
    [SerializeField] GameObject TargetObj;

    Vector2 TargetPos;  //�ǐՂ���^�[�Q�b�g�̍��W������
    Vector2 SlimePos;   //�������g�̍��W

    private float   MOVE_SPEED  = 10.5f;    //�ړ����x
    private int     direction   = 0;  //�A�j���[�^�[�Ɍ����Ă��������������ׂ̕ϐ�
    private int     Slime_HP    = 10;  //���̓G��HP
    private float   rad;

    Rigidbody2D SlimeRB;  //���̓G�̃��W�b�h�{�f�B
    Animator SlimeAnim; //���̓G�̃A�j���[�^�[

    void Start()
    {
        SlimeAnim = GetComponent<Animator>();
        SlimeRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //�ǐՂ���I�u�W�F�N�g�̍��W�����X�V
        TargetPos = TargetObj.GetComponent<Transform>().position;

        //�ǐՂ���I�u�W�F�N�g�ƃX���C���̂Q�_�Ԃ̊p�x�����߂�
        Vector2 vector = new Vector2(transform.position.x - TargetPos.x, transform.position.y - TargetPos.y);
        rad = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        //�p�x���u-180�`180�x�v����u0�`360�x�v�ɕϊ�
        if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }


        //�ǐՂ���I�u�W�F�N�g����������֌���
        direction = 1;
        if (rad>=337.5 || (rad >= 0.0f && rad <= 22.5f)){

        }else{
            for (float r = 22.5f; r <= 315.0f; r += 45.0f)
            {
                direction++;
                if (rad >= r && rad <= r + 45.0f) break;
            }
        }
        //�A�j���[�^�[�ɕ����̒l��n��
        SlimeAnim.SetFloat("Direction", (float)direction);

        //�^�[�Q�b�g�̃I�u�W�F�N�g��ǂ�������悤�Ɉړ�
        SlimeRB.velocity = new Vector2((Mathf.Cos(rad) * MOVE_SPEED), -(Mathf.Sin(rad) * MOVE_SPEED));

    }
}
