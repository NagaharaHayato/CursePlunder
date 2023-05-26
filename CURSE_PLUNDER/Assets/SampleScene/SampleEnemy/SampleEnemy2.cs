using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SampleEnemy2 : MonoBehaviour
{
    public static SampleEnemy2 instance;

    [SerializeField] GameObject HPBar; RectTransform HPBarRect;
    [SerializeField] GameObject STBar; RectTransform STBarRect;

    [SerializeField] public GameObject SwordObj;                //���̃I�u�W�F�N�g
   [SerializeField] public GameObject FreeStyleParticle;           //�t���[�X�^�C���\�[�h�i�p�x�w��j

    [SerializeField]
    GameObject centerObj;//��]�p�I�u�W�F�N�g

    //[SerializeField] GameObject ExpOrb_Obj;
    // [SerializeField] GameObject DamageView;
    [SerializeField] EnemyDataBase EnemyData;
    //[SerializeField] GameObject UIDisplayPos;
    GameObject TargetObj;
    GameObject UIcanvas;


    Vector2 TargetPos;                          //�ǐՂ���^�[�Q�b�g�̍��W������
    Vector2 SlimePos;                           //�������g�̍��W
    Vector2 lastmove = new Vector2(0, 0);               //���͂��ꂽ������ۑ�����p
    Vector2 moveact;                                    //�ړ��x�N�g��

    //��]�p�x
    public float angle = 75;

    public static float Spawn_DIR_RAD = 90.0f;         //��l���̌���

    private int EnemyGob_HP = 0;                //���̓G��HP
    private int EnemyGob_MaxHP = 0;                //���̓G�̍ő�HP
    private int EnemyGob_ST = 0;                //���̓G�̃X�^�~�i
    private int EnemyGob_MaxST = 0;                //���̓G�̍ő�X�^�~�i
    private float MOVE_SPEED = 0;                //�ړ����x
    private int direction = 0;                //�A�j���[�^�[�Ɍ����Ă��������������ׂ̕ϐ�
    private int SwoonTime = 0;                //�C��̎c�莞��
    private bool IsSwoon = false;            //�C���ԃt���O
    public static bool IsAttack = false;
    private float AttackDegree = 0.0f;
    private float AttackTime = 0.0f;
    private float rad = 0;                //�p�x

    ////// �o�ߎ���
    private float time;

    Rigidbody2D EnemyGobRB;                            //���̓G�̃��W�b�h�{�f�B
    //Animator EnemyGobAnim;                           //���̓G�̃A�j���[�^�[

    [SerializeField] float HP_per;
    [SerializeField] float ST_per;

    private AudioSource sound04;//���ʉ�

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (UIManager.isWin && this.gameObject == instance.gameObject) Destroy(instance.gameObject);
            //Destroy(gameObject);
        }
    }

    void Start()
    {
        //SlimeAnim = GetComponent<Animator>();           //�A�j���[�^�[�̏����擾
        EnemyGobRB = GetComponent<Rigidbody2D>();          //���W�b�g�{�f�B�̏����擾
        TargetObj = GameObject.Find("Player");          //�^�[�Q�b�g���v���C���[�ɐݒ�
        UIcanvas = GameObject.Find("UI");

        float radian = -Spawn_DIR_RAD * (Mathf.PI / 180);
        //DirectionChange(new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized);

        EnemyGob_HP = EnemyData.MaxHP;                  //�X���C����HP���f�[�^�x�[�X���玝���Ă���
        EnemyGob_ST = EnemyData.MaxST;                  //�X���C����ST���f�[�^�x�[�X���玝���Ă���
        MOVE_SPEED = EnemyData.MOVE_SPEED;             //�ړ����x�̒l���f�[�^�x�[�X���玝���Ă���
        EnemyGob_MaxHP = EnemyGob_HP;                         //�ő�̗͂̐ݒ�iHP�Q�[�W�\���Ɏg���j
        EnemyGob_MaxST = EnemyGob_ST;                         //�ő�X�^�~�i�̐ݒ�iST�Q�[�W�\���Ɏg���j

        HPBarRect = HPBar.GetComponent<RectTransform>();
        STBarRect = STBar.GetComponent<RectTransform>();

        sound04 = GetComponent<AudioSource>();//���ʉ��Z�b�g
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0.1f, 0));
        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;
        // Boss��HP50�C�J�Ŕ���
        if (time > 3.0f)
        {
            //���̃I�u�W�F�N�g�𐶐����A��l���������Ă�������֔�΂��i���̈ړ������͕ʂ̃X�N���v�g�Ŏ����ς݁j
            Instantiate(SwordObj, transform.position, Quaternion.Euler(0, 0, -Spawn_DIR_RAD + 90));

            // �o�ߎ��ԃ��Z�b�g
            time = 0f;
        }
        //UI�֘A
        {
            //HP�o�[�̍X�V
            HP_per = (float)EnemyGob_HP / (float)EnemyGob_MaxHP;
            HPBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f + (0.5f * HP_per) * 2, HPBarRect.anchorMax.y);

            //ST�o�[�̍X�V
            ST_per = (float)EnemyGob_ST / (float)EnemyGob_MaxST;
            STBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f + (0.5f * ST_per) * 2, STBarRect.anchorMax.y);
        }

        //�ړ��֘A����
        if (!IsSwoon)
        {
            if (!IsAttack)
            {

                //�ǐՂ���I�u�W�F�N�g�̍��W�����X�V
                //TargetPos = TargetObj.GetComponent<Transform>().position;

                ////�ǐՂ���I�u�W�F�N�g�ƃX���C���̂Q�_�Ԃ̊p�x�����߂�
                //Vector2 vector = new Vector2(transform.position.x - TargetPos.x, transform.position.y - TargetPos.y);
                //rad = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

                //�p�x���u-180�`180�x�v����u0�`360�x�v�ɕϊ�
                if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }


                ////�ǐՂ���I�u�W�F�N�g����������֌���
                //direction = 1;
                //if (rad >= 337.5 || (rad >= 0.0f && rad <= 22.5f))
                //{

                //}
                //else
                //{
                //    for (float r = 22.5f; r <= 315.0f; r += 45.0f)
                //    {
                //        direction++;
                //        if (rad >= r && rad <= r + 45.0f) break;
                //    }
                //}
                //�A�j���[�^�[�ɕ����̒l��n��
                //SlimeAnim.SetFloat("Direction", (float)direction);

                //�^�[�Q�b�g�̃I�u�W�F�N�g��ǂ�������悤�Ɉړ�
                //�v���C���[�̓���������悤�Ɉړ�
                //transform.position = Vector2.MoveTowards(transform.position, TargetPos, (MOVE_SPEED * Time.deltaTime) * UIManage.SpeedAdjust);
                //transform.position = new Vector3(transform.position.x, transform.position.y, 0);

                transform.RotateAround(centerObj.transform.position, Vector3.forward, angle * Time.deltaTime);
                //SlimeAnim.SetFloat("Multiplier", UIManage.SpeedAdjust);
            }
            else
            {

                AttackTime -= 1.0f;
                if (AttackTime <= 0.0f)
                {
                    IsAttack = false;
                    MOVE_SPEED = EnemyData.MOVE_SPEED;
                }
                else
                {
                    MOVE_SPEED += 0.5f;

                    float Force_X = Mathf.Cos(AttackDegree * Mathf.Deg2Rad);
                    float Force_Y = Mathf.Sin(AttackDegree * Mathf.Deg2Rad);

                    EnemyGobRB.velocity = new Vector2(Force_X * MOVE_SPEED, Force_Y * MOVE_SPEED);
                }
            }
        }

        //�C�⎞�̏���
        {
            //�X�^�~�i���s������ԂŁu�C���ԂłȂ��v�ꍇ�A���̓G�͋C���ԂɂȂ�
            if (!IsSwoon && ST_per <= 0.0f)
            {
                IsSwoon = true;
                SwoonTime = 100;
            }
            else if (IsSwoon)
            {
                SwoonTime--;
                if (SwoonTime <= 0)
                {
                    IsSwoon = false;            //�C���Ԃ�����
                    EnemyGob_ST = EnemyData.MaxST;  //�f�[�^�x�[�X����l�������Ă���ST�l�����Z�b�g
                }
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            sound04.PlayOneShot(sound04.clip);
            //�i�C�t������������HP��������ST�����炷
            EnemyGob_HP--;
            EnemyGob_ST--;
            //�uDamageView�i�_���[�W�\���I�u�W�F�N�g�j�v�̕������ɃX���C�������郏�[���h���W����r���[�|�[�g���W�ɕϊ�����
            //GameObject _damageView = Instantiate(DamageView, Camera.main.WorldToViewportPoint(transform.position), Quaternion.identity);
            //�`���̃L�����o�X��ݒ�i�e�Ǝq�̃I�u�W�F�N�g�ݒ�j
            //_damageView.transform.SetParent(UIcanvas.transform, false);
            //�e�X�g�Ȃ̂Ń_���[�W�\���́u1�v
            // _damageView.GetComponent<TextMeshProUGUI>().text = "1";

            //�X���C����HP���[���ɂȂ�����o���l�I�[�u�𐶐����āA���g�̃I�u�W�F�N�g���폜����
            if (EnemyGob_HP <= 0)
            {
                PlayerStat.AddCursePoint(10);
                //  Instantiate(ExpOrb_Obj, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Fire")
        {
            sound04.PlayOneShot(sound04.clip);
            EnemyGob_HP -= EnemyGob_MaxHP / 5;
        }
        else if (collision.gameObject.tag == "Cyclon")
        {
            sound04.PlayOneShot(sound04.clip);
            EnemyGob_HP -= EnemyGob_MaxHP / 3;
        }
        else if (collision.gameObject.tag == "Water")
        {
            sound04.PlayOneShot(sound04.clip);
            EnemyGob_HP--;
        }

        if (!IsAttack && collision.gameObject.CompareTag("Player"))
        {
            IsAttack = true;
            AttackTime = 10.0f;
            Vector2 Distance = TargetObj.transform.position - this.transform.position;
            AttackDegree = Mathf.Atan2(Distance.y, Distance.x) * Mathf.Rad2Deg;
            //transform.RotateAround(centerObj.transform.position, Vector3.forward, angle * Time.deltaTime);

        }
        if (collision.gameObject.CompareTag("Wall"))
        {

            //�ǂɂԂ���Δ���
            transform.Rotate(new Vector2(0, 180));
        }

    }
}

