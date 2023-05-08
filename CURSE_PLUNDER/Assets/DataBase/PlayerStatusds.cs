using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create PlayerDataBase")]
public class PlayerStatusds : ScriptableObject
{
    public string PlayerName;   //�v���C���[�̖��O
    public int HitPoint;        //���݂̗̑�
    public int MaxHP;           //�ő�̗�
    public int Attack;          //���݂̍U����
    public int MaxAttack;       //���̍U���́i�X�e�ُ�̕��A���Ɏg�p�j
    public int Defence;         //���݂̖h���
    public int MaxDefence;      //���̖h��́i�X�e�ُ�̕��A���Ɏg�p�j
    public int MOVE_SPEED;      //���݂̈ړ����x
    public int MaxMS;           //���̈ړ����x�i�X�e�ُ�̕��A���Ɏg�p�j

    public int Gold;            //�����S�[���h

    public int GotExp;          //�l�������o���l
}
