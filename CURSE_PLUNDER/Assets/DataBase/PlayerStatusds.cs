using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create PlayerDataBase")]
public class PlayerStatusds : ScriptableObject
{
    public string PlayerName;   //プレイヤーの名前
    public int HitPoint;        //現在の体力
    public int MaxHP;           //最大体力
    public int Attack;          //現在の攻撃力
    public int MaxAttack;       //元の攻撃力（ステ異常の復帰時に使用）
    public int Defence;         //現在の防御力
    public int MaxDefence;      //元の防御力（ステ異常の復帰時に使用）
    public int MOVE_SPEED;      //現在の移動速度
    public int MaxMS;           //元の移動速度（ステ異常の復帰時に使用）

    public int Gold;            //所持ゴールド

    public int GotExp;          //獲得した経験値
}
