using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slime_Act : MonoBehaviour
{
    [SerializeField] GameObject HPBar;
    [SerializeField] GameObject ExpOrb_Obj;
    [SerializeField] GameObject DamageView;
    GameObject TargetObj;
    GameObject UIcanvas;
    

    Vector2 TargetPos;  //追跡するターゲットの座標が入る
    Vector2 SlimePos;   //自分自身の座標

    private float   MOVE_SPEED  = 1.5f;                 //移動速度
    private int     direction   = 0;                    //アニメーターに向いている方向を教える為の変数
    [SerializeField] private int     Slime_HP    = 10;  //この敵のHP
    RectTransform HPBarRect;                            //HPバーのRectTransform
    private int     Slime_MaxHP;                        //この敵の最大体力（Slime_HPで設定された値が最大体力になる）
    private float   rad;                                //角度

    Rigidbody2D SlimeRB;  //この敵のリジッドボディ
    Animator SlimeAnim; //この敵のアニメーター

    [SerializeField] float HP_per;
    void Start()
    {
        SlimeAnim = GetComponent<Animator>();
        SlimeRB = GetComponent<Rigidbody2D>();
        Slime_MaxHP = Slime_HP;

        TargetObj = GameObject.Find("Player");
        UIcanvas = GameObject.Find("UI");
        HPBarRect = HPBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //HPバーの更新
        HP_per = (float)Slime_HP / (float)Slime_MaxHP;
        HPBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f+(0.5f * HP_per)*2, HPBarRect.anchorMax.y);

        //追跡するオブジェクトの座標情報を更新
        TargetPos = TargetObj.GetComponent<Transform>().position;

        //追跡するオブジェクトとスライムの２点間の角度を求める
        Vector2 vector = new Vector2(transform.position.x - TargetPos.x, transform.position.y - TargetPos.y);
        rad = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        //角度を「-180〜180度」から「0〜360度」に変換
        if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }


        //追跡するオブジェクトがいる方向へ向く
        direction = 1;
        if (rad >= 337.5 || (rad >= 0.0f && rad <= 22.5f)) {

        } else {
            for (float r = 22.5f; r <= 315.0f; r += 45.0f)
            {
                direction++;
                if (rad >= r && rad <= r + 45.0f) break;
            }
        }
        //アニメーターに方向の値を渡す
        SlimeAnim.SetFloat("Direction", (float)direction);

        //ターゲットのオブジェクトを追いかけるように移動
        
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, (MOVE_SPEED * Time.deltaTime)*UIManage.SpeedAdjust );
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Slime_HP--;
            GameObject _damageView = Instantiate(DamageView,this.transform.position, Quaternion.identity);
            _damageView.transform.SetParent(UIcanvas.transform,false);
            //_damageView.transform.position = transform.position;
            _damageView.GetComponent<TextMeshProUGUI>().text = "1";

            if (Slime_HP <= 0)
            {
                Instantiate(ExpOrb_Obj, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
