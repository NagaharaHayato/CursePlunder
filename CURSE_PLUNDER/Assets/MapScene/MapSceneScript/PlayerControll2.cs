using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

#pragma warning disable CS0618

public class PlayerControll2 : MonoBehaviour
{
    /// <summary>
    Animator animator;      //��l���̕��s�A�j���������A�j���[�^�[
    /// </summary>
    Rigidbody2D PlayerRB;   //��l���̈ړ��Ŏg�p���郊�W�b�h�{�f�B

    //�Ō�̓��͂��ꂽ�������o���Ă������߃x�N�^�[
    Vector2 lastmove = new Vector2(0, 0);               //���͂��ꂽ������ۑ�����p
    Vector2 moveact;                                    //�ړ��x�N�g��
    //[SerializeField] public GameObject SwordObj;                //���̃I�u�W�F�N�g
    //[SerializeField] public GameObject FreeStyleSword;          //�t���[�X�^�C���\�[�h�i�p�x�w��j

    [SerializeField] private float MOVE_SPEED = 6.0f;  //��l���̈ړ����x
    public static float PLAYER_DIR_RAD = 90.0f;         //��l���̌���

    public static bool cmdselect_dialog = false;
    public static int ControlMode = 0;


    void Start()
    {
        //�A�j���[�^�[�̊֘A�t��
        this.animator = GetComponent<Animator>();
        //���W�b�h�{�f�B�̊֘A�t��
        this.PlayerRB = GetComponent<Rigidbody2D>();

        float radian = -PLAYER_DIR_RAD * (Mathf.PI / 180);
        DirectionChange(new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized);
    }

    // Update is called once per frame
    void Update()
    {
        switch (ControlMode)
        {
            case 0:
                moveact = Vector2.zero;
                moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                ////�R�}���h�I����ʂ�\��������
                //if (Input.GetKeyDown(KeyCode.D))
                //{
                //    cmdselect_dialog = true;
                //    ControlMode = 1;
                //}

                if (moveact != Vector2.zero)
                {
                    //�A�j���[�^�[�̃X�e�[�^�X���uWalk�v�ɐ؂�ւ�
                    this.animator.SetBool("Walk", true);

                    //�A�j���[�^�[�ɓ��͂̏�Ԃ�n��
                    //�n�����x�N�^�[�ɉ����Ď�l���̌������ς��
                    DirectionChange(moveact);

                    //��l���̈ړ������ƍŌ�̓��͂��o���Ă���
                    PlayerRB.velocity = moveact.normalized * MOVE_SPEED;

                    //�Ō�ɓ��͂��ꂽ��������x�ۑ�
                    lastmove = moveact;

                    //�p�x�����W�A���ɕϊ�
                    PLAYER_DIR_RAD = (Mathf.Atan2(lastmove.y, lastmove.x) * Mathf.Rad2Deg);

                    //�p�x���u-180�`180�x�v����u0�`360�x�v�ɕϊ�
                    if (PLAYER_DIR_RAD <= 0.0f) { PLAYER_DIR_RAD = Mathf.Abs(PLAYER_DIR_RAD); } else { PLAYER_DIR_RAD = 360.0f - Mathf.Abs(PLAYER_DIR_RAD); }

                }
                else
                {
                    //�������͂���Ă��Ȃ��ꍇ�́uWalk�v��Ԃ���uWait�v��
                    //���t���O�ŊǗ�����`�ɂ��Ă���̂ŁuWalk�v��false�ɂ����
                    //�����I�Ɂu�ҋ@���(Wait)�v�ɏ�Ԃ��ς��悤�ɂȂ��Ă�
                    this.animator.SetBool("Walk", false);
                    PlayerRB.velocity = Vector2.zero;
                }

                ////���𓊂���
                //if (UIManage.ControlMode == 0 && Input.GetKeyDown(KeyCode.F))
                //{
                //    //���̃I�u�W�F�N�g�𐶐����A��l���������Ă�������֔�΂��i���̈ړ������͕ʂ̃X�N���v�g�Ŏ����ς݁j
                //    Instantiate(SwordObj, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                //}
                break;
            default:
                break;
        }

    }

    private void DirectionChange(Vector2 vec)
    {
        //�A�j���[�^�[�Ƀx�N�g���̒l���Z�b�g�i�x�N�g���̒l�ɉ����ĉ摜���؂�ւ��j
        this.animator.SetFloat("VectorX", vec.x);
        this.animator.SetFloat("VectorY", vec.y);
        return;
    }

    //public void KnifeThrow()
    //{
    //    for (int i = 0; i < 90; i++) Instantiate(FreeStyleSword, transform.position, Quaternion.Euler(0, 0, i * 8));
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        if (Slime_Act.IsAttack) PlayerStat.GiveDamage(50);
    //        Slime_Act.IsAttack = false;
    //    }
    //    else if (collision.gameObject.CompareTag("EnemyFire"))
    //    {
    //        PlayerStat.GiveDamage(50);
    //    }
    //    else if (collision.gameObject.CompareTag("EnemyCyclon"))
    //    {
    //        PlayerStat.GiveDamage(50);
    //    }
    //    else if (collision.gameObject.CompareTag("EnemyWater"))
    //    {
    //        PlayerStat.GiveDamage(50);
    //    }
    //}
}