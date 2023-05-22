using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    GameObject TargetObj;
    [SerializeField] private float bulletSpeed;  �@ //�e�̑��x
    [SerializeField] private float limitSpeed;      //�e�̐������x
    private Rigidbody2D rb;                         //�e��Rigidbody2D
    private Transform bulletTrans;                  //�e��Transform
    private float rad = 0;                //�p�x
    Vector3 TargetPoint;
    public float deleteTime = 2.0f;


    private void Awake()
    {
        TargetObj = GameObject.Find("Player");          //�^�[�Q�b�g���v���C���[�ɐݒ�
        rb = GetComponent<Rigidbody2D>();
        bulletTrans = GetComponent<Transform>();
        Destroy(gameObject, deleteTime);
    }

    private void FixedUpdate()
    {
        TargetPoint = TargetObj.GetComponent<Transform>().position;
        //�ǐՂ���I�u�W�F�N�g�ƃX���C���̂Q�_�Ԃ̊p�x�����߂�
        //Vector3 vector = transform.position-bulletTrans.position;
        //�ǐՂ���I�u�W�F�N�g�ƃX���C���̂Q�_�Ԃ̊p�x�����߂�
        Vector3 vector = new Vector3(transform.position.x - TargetPoint.x, transform.position.y - TargetPoint.y);
        //Vector3 vector3 = playerTrans.position - bulletTrans.position;  //�e����ǂ�������Ώۂւ̕������v�Z
        //rb.AddForce(TargetPoint.normalized * bulletSpeed);                  //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����


        //�p�x���u-180�`180�x�v����u0�`360�x�v�ɕϊ�
        //if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }

        transform.position = Vector3.MoveTowards(transform.position, TargetPoint, (bulletSpeed * Time.deltaTime) * UIManage.SpeedAdjust);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed);�@//X�����̑��x�𐧌�
        float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);  //Y�����̑��x�𐧌�
        rb.velocity = new Vector3(speedXTemp, speedYTemp);�@�@�@�@�@�@�@�@�@�@�@//���ۂɐ��������l����
    }
}
