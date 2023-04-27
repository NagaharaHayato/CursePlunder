using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Create StatusData")]
public class charaData : ScriptableObject
{
    public int MaxHP;//最大Hp
    public int MAXMP;//最大MP
    public int ATK;//攻撃力
    public int DEF;//守備力
    public int INT;//魔力
    public int AGI;//移動力
    public int Lv;//レベル
    public int GETEXP;//取得できる経験値
    public int GETGOLD;//取得できるお金。

}
