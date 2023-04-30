using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create EnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
	public string Name;         //名称
	public int MaxHP;           //最大HP
	public int MaxST;           //スタミナ
	public int Attribute;       //属性
	public int ATK;             //攻撃力
	public int DEF;             //防御力
	public float MOVE_SPEED;    //基本の移動速度
	public int GetExp;          //獲得できる経験値
	public int GetGold;         //獲得できるお金
}
