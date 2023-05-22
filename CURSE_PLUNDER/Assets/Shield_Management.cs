using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield_Management : MonoBehaviour
{
    public static Shield_Management Instance;

    [SerializeField] public GameObject Shield_HPobj;
    [SerializeField] public CircleCollider2D cCollider;

    public static bool  IsShield             = false;      //シールドの有効フラグ
    public static bool  IsShieldInvisible    = false;
    public static int   Shield_HP           = 0;          //シールドの耐久値
    public static int   Shield_MaxHP        = 0;          //シールドの最大耐久値
    public static int   Shield_LV           = 0;          //シールドのレベル

    void Start()
    {

        //シールドのレベルを取得
        Shield_LV = PlayerPrefs.GetInt("Shield_Lv");

        //シールドの耐久値設定
        Shield_MaxHP = 500 * Shield_LV;

        
    }

    // Update is called once per frame
    void Update()
    {
        Shield_HPobj.SetActive(IsShield);
        cCollider.enabled = IsShield;
    }

    public static void Awake_Shield(){
        //シールドがちゃんと無効の状態である場合のみシールドを発動
        if (!IsShield){
            //シールドを有効に
            IsShield = true;

            //プレイヤーのHPを基準にシールドの耐久値を設定
            Shield_HP = Shield_MaxHP;
        }
    }
    void Shield_Damage(int Shield_DMG)
    {
        if (IsShield && Shield_HP>=0){
            Shield_HP -= Shield_DMG;
            if (Shield_HP <= 0){
                IsShield = false;
                Shield_HPobj.SetActive(false);
            }
        }
    }

    public int GetShield_HP() { return (Shield_HP); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //スライムの攻撃フラグが立っている場合はシールドの耐久値を減らす
        if (Slime_Act.IsAttack && collision.gameObject.CompareTag("Enemy")) Shield_Damage(50);
        Debug.Log("Shield HP" + Shield_HP);

    }
}
