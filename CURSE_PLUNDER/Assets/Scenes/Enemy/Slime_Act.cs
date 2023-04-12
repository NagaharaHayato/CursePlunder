using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Act : MonoBehaviour
{
    [SerializeField] GameObject TargetObj;

    Vector2 TargetPos;  //追跡するターゲットの座標が入る
    Vector2 SlimePos;   //自分自身の座標

    private float   MOVE_SPEED  = 10.5f;    //移動速度
    private int     direction   = 0;  //アニメーターに向いている方向を教える為の変数
    private int     Slime_HP    = 10;  //この敵のHP
    private float   rad;

    Rigidbody2D SlimeRB;  //この敵のリジッドボディ
    Animator SlimeAnim; //この敵のアニメーター

    void Start()
    {
        SlimeAnim = GetComponent<Animator>();
        SlimeRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //追跡するオブジェクトの座標情報を更新
        TargetPos = TargetObj.GetComponent<Transform>().position;

        //追跡するオブジェクトとスライムの２点間の角度を求める
        Vector2 vector = new Vector2(transform.position.x - TargetPos.x, transform.position.y - TargetPos.y);
        rad = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        //角度を「-180～180度」から「0～360度」に変換
        if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }


        //追跡するオブジェクトがいる方向へ向く
        direction = 1;
        if (rad>=337.5 || (rad >= 0.0f && rad <= 22.5f)){

        }else{
            for (float r = 22.5f; r <= 315.0f; r += 45.0f)
            {
                direction++;
                if (rad >= r && rad <= r + 45.0f) break;
            }
        }
        //アニメーターに方向の値を渡す
        SlimeAnim.SetFloat("Direction", (float)direction);

        //ターゲットのオブジェクトを追いかけるように移動
        SlimeRB.velocity = new Vector2((Mathf.Cos(rad) * MOVE_SPEED), -(Mathf.Sin(rad) * MOVE_SPEED));

    }
}
