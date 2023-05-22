using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    GameObject TargetObj;
    [SerializeField] private float bulletSpeed;  　 //弾の速度
    [SerializeField] private float limitSpeed;      //弾の制限速度
    private Rigidbody2D rb;                         //弾のRigidbody2D
    private Transform bulletTrans;                  //弾のTransform
    private float rad = 0;                //角度
    Vector3 TargetPoint;
    public float deleteTime = 2.0f;


    private void Awake()
    {
        TargetObj = GameObject.Find("Player");          //ターゲットをプレイヤーに設定
        rb = GetComponent<Rigidbody2D>();
        bulletTrans = GetComponent<Transform>();
        Destroy(gameObject, deleteTime);
    }

    private void FixedUpdate()
    {
        TargetPoint = TargetObj.GetComponent<Transform>().position;
        //追跡するオブジェクトとスライムの２点間の角度を求める
        //Vector3 vector = transform.position-bulletTrans.position;
        //追跡するオブジェクトとスライムの２点間の角度を求める
        Vector3 vector = new Vector3(transform.position.x - TargetPoint.x, transform.position.y - TargetPoint.y);
        //Vector3 vector3 = playerTrans.position - bulletTrans.position;  //弾から追いかける対象への方向を計算
        //rb.AddForce(TargetPoint.normalized * bulletSpeed);                  //方向の長さを1に正規化、任意の力をAddForceで加える


        //角度を「-180～180度」から「0～360度」に変換
        //if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }

        transform.position = Vector3.MoveTowards(transform.position, TargetPoint, (bulletSpeed * Time.deltaTime) * UIManage.SpeedAdjust);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed);　//X方向の速度を制限
        float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);  //Y方向の速度を制限
        rb.velocity = new Vector3(speedXTemp, speedYTemp);　　　　　　　　　　　//実際に制限した値を代入
    }
}
