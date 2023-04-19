using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slime_Act : MonoBehaviour
{
    [SerializeField] GameObject HPBar;
    [SerializeField] GameObject ExpOrb_Obj;
    [SerializeField] GameObject DamageView;
    GameObject TargetObj;
    GameObject UIcanvas;
    

    Vector2 TargetPos;  //�ǐՂ���^�[�Q�b�g�̍��W������
    Vector2 SlimePos;   //�������g�̍��W

    private float   MOVE_SPEED  = 1.5f;                 //�ړ����x
    private int     direction   = 0;                    //�A�j���[�^�[�Ɍ����Ă��������������ׂ̕ϐ�
    [SerializeField] private int     Slime_HP    = 10;  //���̓G��HP
    RectTransform HPBarRect;                            //HP�o�[��RectTransform
    private int     Slime_MaxHP;                        //���̓G�̍ő�̗́iSlime_HP�Őݒ肳�ꂽ�l���ő�̗͂ɂȂ�j
    private float   rad;                                //�p�x

    Rigidbody2D SlimeRB;  //���̓G�̃��W�b�h�{�f�B
    Animator SlimeAnim; //���̓G�̃A�j���[�^�[

    [SerializeField] float HP_per;
    void Start()
    {
        SlimeAnim = GetComponent<Animator>();
        SlimeRB = GetComponent<Rigidbody2D>();
        Slime_MaxHP = Slime_HP;

        TargetObj = GameObject.Find("Player");
        UIcanvas = GameObject.Find("UI");
        HPBarRect = HPBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //HP�o�[�̍X�V
        HP_per = (float)Slime_HP / (float)Slime_MaxHP;
        HPBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f+(0.5f * HP_per)*2, HPBarRect.anchorMax.y);

        //�ǐՂ���I�u�W�F�N�g�̍��W�����X�V
        TargetPos = TargetObj.GetComponent<Transform>().position;

        //�ǐՂ���I�u�W�F�N�g�ƃX���C���̂Q�_�Ԃ̊p�x�����߂�
        Vector2 vector = new Vector2(transform.position.x - TargetPos.x, transform.position.y - TargetPos.y);
        rad = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        //�p�x���u-180�`180�x�v����u0�`360�x�v�ɕϊ�
        if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }


        //�ǐՂ���I�u�W�F�N�g����������֌���
        direction = 1;
        if (rad >= 337.5 || (rad >= 0.0f && rad <= 22.5f)) {

        } else {
            for (float r = 22.5f; r <= 315.0f; r += 45.0f)
            {
                direction++;
                if (rad >= r && rad <= r + 45.0f) break;
            }
        }
        //�A�j���[�^�[�ɕ����̒l��n��
        SlimeAnim.SetFloat("Direction", (float)direction);

        //�^�[�Q�b�g�̃I�u�W�F�N�g��ǂ�������悤�Ɉړ�
        
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, (MOVE_SPEED * Time.deltaTime)*UIManage.SpeedAdjust );
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Slime_HP--;
            GameObject _damageView = Instantiate(DamageView,this.transform.position, Quaternion.identity);
            _damageView.transform.SetParent(UIcanvas.transform,false);
            //_damageView.transform.position = transform.position;
            _damageView.GetComponent<TextMeshProUGUI>().text = "1";

            if (Slime_HP <= 0)
            {
                Instantiate(ExpOrb_Obj, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
