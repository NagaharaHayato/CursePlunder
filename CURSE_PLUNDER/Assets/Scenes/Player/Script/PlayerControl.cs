using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

#pragma warning disable CS0618

public class PlayerControl : MonoBehaviour
{
	Animator animator;		//��l���̕��s�A�j���������A�j���[�^�[
	Rigidbody2D PlayerRB;   //��l���̈ړ��Ŏg�p���郊�W�b�h�{�f�B

	//�Ō�̓��͂��ꂽ�������o���Ă������߃x�N�^�[
	Vector2 lastmove = new Vector2(0,0);

	[SerializeField]
	private float MOVE_SPEED = 60.0f;	//��l���̈ړ����x
	
	void Start()
	{
		//�A�j���[�^�[�̊֘A�t��
		this.animator = GetComponent<Animator>();
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
			//�A�j���[�^�[�̃X�e�[�^�X���uWalk�v�ɐ؂�ւ�
			this.animator.SetBool("Walk", true);
			
			//�A�j���[�^�[�ɓ��͂̏�Ԃ�n��
			//�n�����x�N�^�[�ɉ����Ď�l���̌������ς��
			this.animator.SetFloat("VectorX", moveact.x);
			this.animator.SetFloat("VectorY", moveact.y);

			//��l���̈ړ������ƍŌ�̓��͂��o���Ă���
			PlayerRB.velocity = moveact.normalized * MOVE_SPEED;
			
			lastmove = moveact;
		}
		else
		{
			//�������͂���Ă��Ȃ��ꍇ�́uWalk�v��Ԃ���uWait�v��
			//���t���O�ŊǗ�����`�ɂ��Ă���̂ŁuWalk�v��false�ɂ����
			//�����I�Ɂu�ҋ@���(Wait)�v�ɏ�Ԃ��ς��悤�ɂȂ��Ă�
			this.animator.SetBool("Walk", false);
			PlayerRB.velocity = Vector2.zero;
		}


	}
}