using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create EnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
	public string Name;         //����
	public int MaxHP;           //�ő�HP
	public int MaxST;           //�X�^�~�i
	public int Attribute;       //����
	public int ATK;             //�U����
	public int DEF;             //�h���
	public float MOVE_SPEED;    //��{�̈ړ����x
	public int GetExp;          //�l���ł���o���l
	public int GetGold;         //�l���ł��邨��
}
