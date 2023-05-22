using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

#pragma warning disable CS0618

public class PlayerControll2 : MonoBehaviour
{
    /// <summary>
    Animator animator;      //主人公の歩行アニメを扱うアニメーター
    /// </summary>
    Rigidbody2D PlayerRB;   //主人公の移動で使用するリジッドボディ

    //最後の入力された方向を覚えておくためベクター
    Vector2 lastmove = new Vector2(0, 0);               //入力された方向を保存する用
    Vector2 moveact;                                    //移動ベクトル
    //[SerializeField] public GameObject SwordObj;                //剣のオブジェクト
    //[SerializeField] public GameObject FreeStyleSword;          //フリースタイルソード（角度指定可）

    [SerializeField] private float MOVE_SPEED = 6.0f;  //主人公の移動速度
    public static float PLAYER_DIR_RAD = 90.0f;         //主人公の向き

    public static bool cmdselect_dialog = false;
    public static int ControlMode = 0;


    void Start()
    {
        //アニメーターの関連付け
        this.animator = GetComponent<Animator>();
        //リジッドボディの関連付け
        this.PlayerRB = GetComponent<Rigidbody2D>();

        float radian = -PLAYER_DIR_RAD * (Mathf.PI / 180);
        DirectionChange(new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized);
    }

    // Update is called once per frame
    void Update()
    {
        switch (ControlMode)
        {
            case 0:
                moveact = Vector2.zero;
                moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                ////コマンド選択画面を表示させる
                //if (Input.GetKeyDown(KeyCode.D))
                //{
                //    cmdselect_dialog = true;
                //    ControlMode = 1;
                //}

                if (moveact != Vector2.zero)
                {
                    //アニメーターのステータスを「Walk」に切り替え
                    this.animator.SetBool("Walk", true);

                    //アニメーターに入力の状態を渡す
                    //渡したベクターに応じて主人公の向きが変わる
                    DirectionChange(moveact);

                    //主人公の移動処理と最後の入力を覚えておく
                    PlayerRB.velocity = moveact.normalized * MOVE_SPEED;

                    //最後に入力された方向を一度保存
                    lastmove = moveact;

                    //角度をラジアンに変換
                    PLAYER_DIR_RAD = (Mathf.Atan2(lastmove.y, lastmove.x) * Mathf.Rad2Deg);

                    //角度を「-180～180度」から「0～360度」に変換
                    if (PLAYER_DIR_RAD <= 0.0f) { PLAYER_DIR_RAD = Mathf.Abs(PLAYER_DIR_RAD); } else { PLAYER_DIR_RAD = 360.0f - Mathf.Abs(PLAYER_DIR_RAD); }

                }
                else
                {
                    //何も入力されていない場合は「Walk」状態から「Wait」へ
                    //※フラグで管理する形にしているので「Walk」をfalseにすると
                    //自動的に「待機状態(Wait)」に状態が変わるようになってる
                    this.animator.SetBool("Walk", false);
                    PlayerRB.velocity = Vector2.zero;
                }

                ////剣を投げる
                //if (UIManage.ControlMode == 0 && Input.GetKeyDown(KeyCode.F))
                //{
                //    //剣のオブジェクトを生成し、主人公が向いている方向へ飛ばす（剣の移動処理は別のスクリプトで実装済み）
                //    Instantiate(SwordObj, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                //}
                break;
            default:
                break;
        }

    }

    private void DirectionChange(Vector2 vec)
    {
        //アニメーターにベクトルの値をセット（ベクトルの値に応じて画像が切り替わる）
        this.animator.SetFloat("VectorX", vec.x);
        this.animator.SetFloat("VectorY", vec.y);
        return;
    }

    //public void KnifeThrow()
    //{
    //    for (int i = 0; i < 90; i++) Instantiate(FreeStyleSword, transform.position, Quaternion.Euler(0, 0, i * 8));
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        if (Slime_Act.IsAttack) PlayerStat.GiveDamage(50);
    //        Slime_Act.IsAttack = false;
    //    }
    //    else if (collision.gameObject.CompareTag("EnemyFire"))
    //    {
    //        PlayerStat.GiveDamage(50);
    //    }
    //    else if (collision.gameObject.CompareTag("EnemyCyclon"))
    //    {
    //        PlayerStat.GiveDamage(50);
    //    }
    //    else if (collision.gameObject.CompareTag("EnemyWater"))
    //    {
    //        PlayerStat.GiveDamage(50);
    //    }
    //}
}