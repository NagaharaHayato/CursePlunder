using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

#pragma warning disable CS0618

public class PlayerControl : MonoBehaviour
{
	Animator animator;		//��l���̕��s�A�j���������A�j���[�^�[
	Rigidbody2D PlayerRB;   //��l���̈ړ��Ŏg�p���郊�W�b�h�{�f�B

	//�Ō�̓��͂��ꂽ�������o���Ă������߃x�N�^�[
	Vector2 lastmove = new Vector2(0,0);
	Vector2 moveact;

	[SerializeField] GameObject SwordObj;

	[SerializeField] private float MOVE_SPEED = 60.0f;   //��l���̈ړ����x
	public static float PLAYER_DIR_RAD = 90.0f;    //��l���̌���

	[SerializeField] TextMeshProUGUI radview;
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
		

		//�����L�[�̓��͏�Ԃ��擾
		moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		
		//�����L�[�����͂���Ă����ꍇ
		if (moveact != Vector2.zero)
		{
			//�A�j���[�^�[�̃X�e�[�^�X���uWalk�v�ɐ؂�ւ�
			this.animator.SetBool("Walk", true);

			//�A�j���[�^�[�ɓ��͂̏�Ԃ�n��
			//�n�����x�N�^�[�ɉ����Ď�l���̌������ς��
			DirectionChange(moveact);

			//��l���̈ړ������ƍŌ�̓��͂��o���Ă���
			PlayerRB.velocity = moveact.normalized * MOVE_SPEED;
			
			lastmove = moveact;

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

		//���𓊂���
		if (Input.GetKeyDown(KeyCode.F))
		{
			Instantiate(SwordObj, transform.position,Quaternion.identity);
		}

		radview.text = PLAYER_DIR_RAD.ToString();
	}

	private void DirectionChange(Vector2 vec)
	{
		this.animator.SetFloat("VectorX", vec.x);
		this.animator.SetFloat("VectorY", vec.y);
		return;
	}
}