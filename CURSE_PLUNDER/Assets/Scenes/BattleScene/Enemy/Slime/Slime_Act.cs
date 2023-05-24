using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slime_Act : MonoBehaviour
{
    public static Slime_Act instance;

    [SerializeField] GameObject     HPBar;  RectTransform  HPBarRect;
	[SerializeField] GameObject     STBar;  RectTransform  STBarRect;

   // [SerializeField] GameObject ExpOrb_Obj;
    [SerializeField] GameObject DamageView;
    [SerializeField] EnemyDataBase EnemyData;
    [SerializeField] GameObject UIDisplayPos;

    GameObject TargetObj;
    GameObject UIcanvas;


    
    Vector2         TargetPos;                          //�ǐՂ���^�[�Q�b�g�̍��W������
    Vector2         SlimePos;                           //�������g�̍��W

	private int     Slime_HP        = 0;                //���̓G��HP
	private int     Slime_MaxHP     = 0;                //���̓G�̍ő�HP
	private int     Slime_ST        = 0;                //���̓G�̃X�^�~�i
    private int     Slime_MaxST     = 0;                //���̓G�̍ő�X�^�~�i
    private float   MOVE_SPEED      = 0;                //�ړ����x
    private int     direction       = 0;                //�A�j���[�^�[�Ɍ����Ă��������������ׂ̕ϐ�
    private int     SwoonTime       = 0;                //�C��̎c�莞��
    private bool    IsSwoon         = false;            //�C���ԃt���O
    public static bool    IsAttack        = false;
    private float   AttackDegree    = 0.0f;
    private float   AttackTime      = 0.0f;
    private float   AttackInverval = 50.0f;
    private float   rad             = 0;                //�p�x



    Rigidbody2D     SlimeRB;                            //���̓G�̃��W�b�h�{�f�B
    Animator        SlimeAnim;                           //���̓G�̃A�j���[�^�[

    [SerializeField] float HP_per;
    [SerializeField] float ST_per;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            if (UIManager.isWin && this.gameObject == instance.gameObject) Destroy(instance.gameObject);
            
            //Destroy(gameObject);
        }
    }

    void Start()
    {
        SlimeAnim = GetComponent<Animator>();           //�A�j���[�^�[�̏����擾
        SlimeRB = GetComponent<Rigidbody2D>();          //���W�b�g�{�f�B�̏����擾
		TargetObj = GameObject.Find("Player");          //�^�[�Q�b�g���v���C���[�ɐݒ�
		UIcanvas = GameObject.Find("UI");               

		Slime_HP    = EnemyData.MaxHP;                  //�X���C����HP���f�[�^�x�[�X���玝���Ă���
        Slime_ST    = EnemyData.MaxST;                  //�X���C����ST���f�[�^�x�[�X���玝���Ă���
		MOVE_SPEED  = EnemyData.MOVE_SPEED;             //�ړ����x�̒l���f�[�^�x�[�X���玝���Ă���
		Slime_MaxHP = Slime_HP;                         //�ő�̗͂̐ݒ�iHP�Q�[�W�\���Ɏg���j
        Slime_MaxST = Slime_ST;                         //�ő�X�^�~�i�̐ݒ�iST�Q�[�W�\���Ɏg���j
        
        HPBarRect = HPBar.GetComponent<RectTransform>();
        STBarRect = STBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //UI�֘A
        {
            //HP�o�[�̍X�V
            HP_per = (float)Slime_HP / (float)Slime_MaxHP;
            HPBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f + (0.5f * HP_per) * 2, HPBarRect.anchorMax.y);

            //ST�o�[�̍X�V
            ST_per = (float)Slime_ST / (float)Slime_MaxST;
            STBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f + (0.5f * ST_per) * 2, STBarRect.anchorMax.y);
        }

        

		//�ړ��֘A����
		if (!IsSwoon){
            if (!IsAttack)
            {
				//������ȏ�A�v���C���[���߂Â�����U�����s��
				if (Vector2.Distance(this.gameObject.transform.position, TargetObj.transform.position) < 5.0f) AttackLaunch();

				//�ǐՂ���I�u�W�F�N�g�̍��W�����X�V
				TargetPos = TargetObj.GetComponent<Transform>().position;

                //�ǐՂ���I�u�W�F�N�g�ƃX���C���̂Q�_�Ԃ̊p�x�����߂�
                Vector2 vector = new Vector2(transform.position.x - TargetPos.x, transform.position.y - TargetPos.y);
                rad = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

                //�p�x���u-180�`180�x�v����u0�`360�x�v�ɕϊ�
                if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }


                //�ǐՂ���I�u�W�F�N�g����������֌���
                direction = 1;
                if (rad >= 337.5 || (rad >= 0.0f && rad <= 22.5f))
                {

                }
                else
                {
                    for (float r = 22.5f; r <= 315.0f; r += 45.0f)
                    {
                        direction++;
                        if (rad >= r && rad <= r + 45.0f) break;
                    }
                }
                //�A�j���[�^�[�ɕ����̒l��n��
                SlimeAnim.SetFloat("Direction", (float)direction);

                //�^�[�Q�b�g�̃I�u�W�F�N�g��ǂ�������悤�Ɉړ�

                transform.position = Vector2.MoveTowards(transform.position, TargetPos, (MOVE_SPEED * Time.deltaTime) * UIManage.SpeedAdjust);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);

                SlimeAnim.SetFloat("Multiplier", UIManage.SpeedAdjust);

                if (AttackInverval >= 0.0f) AttackInverval -= 1.0f;

                
			}
			else
			{

                AttackTime -= 1.0f;
                if (AttackTime <= 0.0f)
                {
                    IsAttack = false;
                    AttackInverval = 150.0f;
					SlimeRB.velocity = Vector2.zero;
					MOVE_SPEED = EnemyData.MOVE_SPEED;
                }
                else
                {
                    MOVE_SPEED += 0.5f;

                    float Force_X = Mathf.Cos(AttackDegree * Mathf.Deg2Rad);
                    float Force_Y = Mathf.Sin(AttackDegree * Mathf.Deg2Rad);

                    SlimeRB.velocity = new Vector2(Force_X * MOVE_SPEED, Force_Y * MOVE_SPEED);
                }
			}
        }

        //�C�⎞�̏���
        {
            //�X�^�~�i���s������ԂŁu�C���ԂłȂ��v�ꍇ�A���̓G�͋C���ԂɂȂ�
            if (!IsSwoon && ST_per <= 0.0f){
                IsSwoon     = true;
                SwoonTime   = 100;
            }else if (IsSwoon){
                SwoonTime--;
                if (SwoonTime <= 0){
                    IsSwoon     = false;            //�C���Ԃ�����
                    Slime_ST    = EnemyData.MaxST;  //�f�[�^�x�[�X����l�������Ă���ST�l�����Z�b�g
                }
            }
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Sword"))
        {
            //�i�C�t������������HP��������ST�����炷
            Slime_HP--;
            Slime_ST--;
            //�uDamageView�i�_���[�W�\���I�u�W�F�N�g�j�v�̕������ɃX���C�������郏�[���h���W����r���[�|�[�g���W�ɕϊ�����
            GameObject _damageView = Instantiate(DamageView, Camera.main.WorldToViewportPoint(transform.position), Quaternion.identity);
            //�`���̃L�����o�X��ݒ�i�e�Ǝq�̃I�u�W�F�N�g�ݒ�j
            _damageView.transform.SetParent(UIcanvas.transform,false);
            //�e�X�g�Ȃ̂Ń_���[�W�\���́u1�v
            _damageView.GetComponent<TextMeshProUGUI>().text = "1";

            //�X���C����HP���[���ɂȂ�����o���l�I�[�u�𐶐����āA���g�̃I�u�W�F�N�g���폜����
            if (Slime_HP <= 0)
            {
                PlayerStat.AddCursePoint(10);
               // Instantiate(ExpOrb_Obj, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    public void AttackLaunch()
    {
        if (AttackInverval <= 0.0f)
        {
            IsAttack = true;
            AttackTime = 50.0f;
            Vector2 Distance = TargetObj.transform.position - this.transform.position;
            AttackDegree = Mathf.Atan2(Distance.y, Distance.x) * Mathf.Rad2Deg;
        }
    }
}
