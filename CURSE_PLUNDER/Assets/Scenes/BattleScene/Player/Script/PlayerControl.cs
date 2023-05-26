using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEditor.Experimental.GraphView;

#pragma warning disable CS0618

public class PlayerControl : MonoBehaviour
{
	Animator animator;		//��l���̕��s�A�j���������A�j���[�^�[
	Rigidbody2D PlayerRB;   //��l���̈ړ��Ŏg�p���郊�W�b�h�{�f�B

	//�Ō�̓��͂��ꂽ�������o���Ă������߃x�N�^�[
	Vector2 lastmove = new Vector2(0,0);				//���͂��ꂽ������ۑ�����p
	Vector2 moveact;									//�ړ��x�N�g��
	[SerializeField] public GameObject SwordObj;                //���̃I�u�W�F�N�g
	[SerializeField] public GameObject FireObject;
    [SerializeField] public GameObject WaterObject;
    [SerializeField] public GameObject CyclonObject;
    [SerializeField] public GameObject FreeStyleSword;          //�t���[�X�^�C���\�[�h�i�p�x�w���

	[SerializeField] private float MOVE_SPEED = 6.0f;  //��l���̈ړ����x
	public static float PLAYER_DIR_RAD = 90.0f;         //��l���̌���

	public static bool  cmdselect_dialog   = false;					//�R�}���h�Z���N�g�����ǂ����̃t���O
	public static bool  Invisible          = false;		            //���G�t���O�i�m�b�N�_�E�����畜����ɓG����_���[�W���󂯂�̂�h���j
	public static int   InvisibleBlink     = 1; 					//���G��Ԏ��Ƀv���C���[�L������_�ł�����p
	public static float Invisible_Interval = 0;						//���G��Ԏ��̓_�ŃA�j���[�V�����p
	public static float InvisibleTime      = 0;                     //���G����
	public static bool	Invisible_Victory  = false;

	public static float[] CooldownTime = new float[5];
	public static int GuardLimit = 2;
	bool[] IsCoolTime = new bool[5];

	public static int ControlMode = 0;

	private static int Damage_Color = 255;
	
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
		//
		if (Damage_Color <= 255) Damage_Color += 15;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, (float)Damage_Color / 255, (float)Damage_Color / 255, InvisibleBlink );

		for(int i = 0; i < 5; i++){
			if (CooldownTime[i] > 0){
				CooldownTime[i] -= Time.deltaTime;
            }
            else{
				IsCoolTime[i] = false;
			}
		}

		switch (ControlMode) {
			case 0:
				moveact = Vector2.zero;
                moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

				//�I�����ꂽ�X�L�����J�[�X�|�C���g��������HP������Ĕ���
				if (Input.GetKeyDown(KeyCode.S))
				{
					if (PlayerStat.HP > UISkill_Selector.GetSkillCost() ||
						Timer.countdownSecound > UISkill_Selector.GetSkillCost()){
                        switch (UISkill_Selector.GetSkillID())
                        {
                            //�g�U����
                            case 0:
								if (!IsCoolTime[0]){
									KnifeThrow();
									IsCoolTime[0] = true;

									Skill_CostPay();
                                }
                                break;

                            //�t�@�C�A
                            case 1:
								if (!IsCoolTime[1])
								{
                                    Instantiate(FireObject, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                                    IsCoolTime[1] = true;
                                    Skill_CostPay();

                                }
                                break;
                            //�K�[�h
                            case 2:
								if (!Shield_Management.IsShield && !IsCoolTime[2] && UISkill_Selector.GuardLimit > 0){
									Shield_Management.Awake_Shield();
									UISkill_Selector.GuardLimit--;
                                    IsCoolTime[2] = true;

									Skill_CostPay();
                                }
                                break;

							//�E�H�[�^�[
							case 3:
								if (!IsCoolTime[3]){
                                    Instantiate(WaterObject, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                                    IsCoolTime[3] = true;
                                    Skill_CostPay();
                                }
								break;

							//�T�C�N����
							case 4:
                                if (!IsCoolTime[4]){
                                    Instantiate(CyclonObject, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                                    IsCoolTime[4] = true;
                                    Skill_CostPay();
                                }
                                break;
                        }

						

                        
                    }
                }

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

                }else{
                    //�������͂���Ă��Ȃ��ꍇ�́uWalk�v��Ԃ���uWait�v��
                    //���t���O�ŊǗ�����`�ɂ��Ă���̂ŁuWalk�v��false�ɂ����
                    //�����I�Ɂu�ҋ@���(Wait)�v�ɏ�Ԃ��ς��悤�ɂȂ��Ă�
                    this.animator.SetBool("Walk", false);
                    PlayerRB.velocity = Vector2.zero;
                }

                //���𓊂���
                if (UIManage.ControlMode == 0 && Input.GetKeyDown(KeyCode.F))
                {
                    //���̃I�u�W�F�N�g�𐶐����A��l���������Ă�������֔�΂��i���̈ړ������͕ʂ̃X�N���v�g�Ŏ����ς݁j
                    Instantiate(SwordObj, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                }
                break;
			default:
				break;
		}

		//���G��Ԃ̏ꍇ
		if (Invisible)
		{
			InvisibleTime -= 1.0f;
			Invisible_Interval += Time.deltaTime;

			//�_�ŃC���^�[�o����0.2f�𒴂����ꍇ
			if (Invisible_Interval >= 0.01f)
			{
				if (InvisibleBlink == 0) InvisibleBlink = 1; else InvisibleBlink = 0;
				Invisible_Interval = 0.0f;
			}

			if (InvisibleTime <= 0.0f){
				InvisibleBlink = 1;
				Invisible = false;
			}
		}

		//HP���[���ɂȂ�����s���s��
		if (PlayerStat.HP <= 0) this.gameObject.SetActive(false);
	}

	private void DirectionChange(Vector2 vec)
	{
		//�A�j���[�^�[�Ƀx�N�g���̒l���Z�b�g�i�x�N�g���̒l�ɉ����ĉ摜���؂�ւ��j
		this.animator.SetFloat("VectorX", vec.x);
		this.animator.SetFloat("VectorY", vec.y);
		return;
	}

	public void KnifeThrow()
	{
		for(int i = 0; i < 45; i++) Instantiate(FreeStyleSword, transform.position, Quaternion.Euler(0, 0,i*16));
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!Invisible && !Invisible_Victory && collision.gameObject.CompareTag("Enemy"))
		{
			//�X���C���̍U����Ԃ�����
			Slime_Act.IsAttack = false;

			//�_���[�W�������s��
			DamageProcess(50);

        }
		else if (collision.gameObject.CompareTag("EnemyFire")){
			DamageProcess(60);
        }
		else if (collision.gameObject.CompareTag("EnemyCyclon")){
			DamageProcess(40);
		}
		else if (collision.gameObject.CompareTag("EnemyWater")){
			DamageProcess(70);
		}
	}
	private void DamageProcess(int DamagePoint){
        //�V�[���h�̑ϋv�l���c���Ă���΁A�V�[���h�̑ϋv�l���_���[�W�����炵
        //�V�[���h�������Ă��Ȃ���Ԃł���΁A���̂܂܃_���[�W��HP�Ŏ󂯂�
        if (!Shield_Management.IsShield){
            
            PlayerStat.GiveDamage(DamagePoint);
			DamageColorZero();
			Invisibled();
        }
    }
	public static void DamageColorZero() { Damage_Color = 0; }
	public static void Invisibled()
	{
		//���ɖ��G��Ԃ̏ꍇ�͖��G��ԂɂȂ�Ȃ�
		if (!Invisible)
		{
			Invisible = true;
			InvisibleTime = 30.0f;
		}
	}

	void Skill_CostPay()
	{
        //�N�[���_�E���ɓ���
        CooldownTime[UISkill_Selector.GetSkillID()] = UISkill_Selector.Skill_CT;
        //�R�X�g���x����
        PlayerStat.CostPay(UISkill_Selector.GetSkillCost());
    }
}