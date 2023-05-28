using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SampleEnemy2 : MonoBehaviour
{
    public static SampleEnemy2 instance;

    [SerializeField] GameObject HPBar; RectTransform HPBarRect;
    [SerializeField] GameObject STBar; RectTransform STBarRect;

    [SerializeField] public GameObject SwordObj;                //剣のオブジェクト
   [SerializeField] public GameObject FreeStyleParticle;           //フリースタイルソード（角度指定可）

    [SerializeField]
    GameObject centerObj;//回転用オブジェクト

    //[SerializeField] GameObject ExpOrb_Obj;
    // [SerializeField] GameObject DamageView;
    [SerializeField] EnemyDataBase EnemyData;
    //[SerializeField] GameObject UIDisplayPos;
    GameObject TargetObj;
    GameObject UIcanvas;


    Vector2 TargetPos;                          //追跡するターゲットの座標が入る
    Vector2 SlimePos;                           //自分自身の座標
    Vector2 lastmove = new Vector2(0, 0);               //入力された方向を保存する用
    Vector2 moveact;                                    //移動ベクトル

    //回転角度
    public float angle = 75;

    public static float Spawn_DIR_RAD = 90.0f;         //主人公の向き

    private int EnemyGob_HP = 0;                //この敵のHP
    private int EnemyGob_MaxHP = 0;                //この敵の最大HP
    private int EnemyGob_ST = 0;                //この敵のスタミナ
    private int EnemyGob_MaxST = 0;                //この敵の最大スタミナ
    private float MOVE_SPEED = 0;                //移動速度
    private int direction = 0;                //アニメーターに向いている方向を教える為の変数
    private int SwoonTime = 0;                //気絶の残り時間
    private bool IsSwoon = false;            //気絶状態フラグ
    public static bool IsAttack = false;
    private float AttackDegree = 0.0f;
    private float AttackTime = 0.0f;
    private float rad = 0;                //角度

    ////// 経過時間
    private float time;

    Rigidbody2D EnemyGobRB;                            //この敵のリジッドボディ
    //Animator EnemyGobAnim;                           //この敵のアニメーター

    [SerializeField] float HP_per;
    [SerializeField] float ST_per;

    private AudioSource sound04;//効果音

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (UIManager.isWin && this.gameObject == instance.gameObject) Destroy(instance.gameObject);
            //Destroy(gameObject);
        }
    }

    void Start()
    {
        //SlimeAnim = GetComponent<Animator>();           //アニメーターの情報を取得
        EnemyGobRB = GetComponent<Rigidbody2D>();          //リジットボディの情報を取得
        TargetObj = GameObject.Find("Player");          //ターゲットをプレイヤーに設定
        UIcanvas = GameObject.Find("UI");

        float radian = -Spawn_DIR_RAD * (Mathf.PI / 180);
        //DirectionChange(new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized);

        EnemyGob_HP = EnemyData.MaxHP;                  //スライムのHPをデータベースから持ってくる
        EnemyGob_ST = EnemyData.MaxST;                  //スライムのSTをデータベースから持ってくる
        MOVE_SPEED = EnemyData.MOVE_SPEED;             //移動速度の値をデータベースから持ってくる
        EnemyGob_MaxHP = EnemyGob_HP;                         //最大体力の設定（HPゲージ表示に使う）
        EnemyGob_MaxST = EnemyGob_ST;                         //最大スタミナの設定（STゲージ表示に使う）

        HPBarRect = HPBar.GetComponent<RectTransform>();
        STBarRect = STBar.GetComponent<RectTransform>();

        sound04 = GetComponent<AudioSource>();//効果音セット
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0.1f, 0));
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;
        // BossのHP50イカで発動
        if (time > 3.0f)
        {
            //剣のオブジェクトを生成し、主人公が向いている方向へ飛ばす（剣の移動処理は別のスクリプトで実装済み）
            Instantiate(SwordObj, transform.position, Quaternion.Euler(0, 0, -Spawn_DIR_RAD + 90));

            // 経過時間リセット
            time = 0f;
        }
        //UI関連
        {
            //HPバーの更新
            HP_per = (float)EnemyGob_HP / (float)EnemyGob_MaxHP;
            HPBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f + (0.5f * HP_per) * 2, HPBarRect.anchorMax.y);

            //STバーの更新
            ST_per = (float)EnemyGob_ST / (float)EnemyGob_MaxST;
            STBar.GetComponent<RectTransform>().anchorMax = new Vector2(-0.5f + (0.5f * ST_per) * 2, STBarRect.anchorMax.y);
        }

        //移動関連処理
        if (!IsSwoon)
        {
            if (!IsAttack)
            {

                //追跡するオブジェクトの座標情報を更新
                //TargetPos = TargetObj.GetComponent<Transform>().position;

                ////追跡するオブジェクトとスライムの２点間の角度を求める
                //Vector2 vector = new Vector2(transform.position.x - TargetPos.x, transform.position.y - TargetPos.y);
                //rad = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

                //角度を「-180～180度」から「0～360度」に変換
                if (rad <= 0.0f) { rad = Mathf.Abs(rad); } else { rad = 360.0f - Mathf.Abs(rad); }


                ////追跡するオブジェクトがいる方向へ向く
                //direction = 1;
                //if (rad >= 337.5 || (rad >= 0.0f && rad <= 22.5f))
                //{

                //}
                //else
                //{
                //    for (float r = 22.5f; r <= 315.0f; r += 45.0f)
                //    {
                //        direction++;
                //        if (rad >= r && rad <= r + 45.0f) break;
                //    }
                //}
                //アニメーターに方向の値を渡す
                //SlimeAnim.SetFloat("Direction", (float)direction);

                //ターゲットのオブジェクトを追いかけるように移動
                //プレイヤーの当たりを回るように移動
                //transform.position = Vector2.MoveTowards(transform.position, TargetPos, (MOVE_SPEED * Time.deltaTime) * UIManage.SpeedAdjust);
                //transform.position = new Vector3(transform.position.x, transform.position.y, 0);

                transform.RotateAround(centerObj.transform.position, Vector3.forward, angle * Time.deltaTime);
                //SlimeAnim.SetFloat("Multiplier", UIManage.SpeedAdjust);
            }
            else
            {

                AttackTime -= 1.0f;
                if (AttackTime <= 0.0f)
                {
                    IsAttack = false;
                    MOVE_SPEED = EnemyData.MOVE_SPEED;
                }
                else
                {
                    MOVE_SPEED += 0.5f;

                    float Force_X = Mathf.Cos(AttackDegree * Mathf.Deg2Rad);
                    float Force_Y = Mathf.Sin(AttackDegree * Mathf.Deg2Rad);

                    EnemyGobRB.velocity = new Vector2(Force_X * MOVE_SPEED, Force_Y * MOVE_SPEED);
                }
            }
        }

        //気絶時の処理
        {
            //スタミナが尽きた状態で「気絶状態でない」場合、この敵は気絶状態になる
            if (!IsSwoon && ST_per <= 0.0f)
            {
                IsSwoon = true;
                SwoonTime = 100;
            }
            else if (IsSwoon)
            {
                SwoonTime--;
                if (SwoonTime <= 0)
                {
                    IsSwoon = false;            //気絶状態を解除
                    EnemyGob_ST = EnemyData.MaxST;  //データベースから値を持ってきてST値をリセット
                }
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            sound04.PlayOneShot(sound04.clip);
            //ナイフが当たったらHPもしくはSTを減らす
            EnemyGob_HP--;
            EnemyGob_ST--;
            //「DamageView（ダメージ表示オブジェクト）」の複製時にスライムがいるワールド座標からビューポート座標に変換する
            //GameObject _damageView = Instantiate(DamageView, Camera.main.WorldToViewportPoint(transform.position), Quaternion.identity);
            //描画先のキャンバスを設定（親と子のオブジェクト設定）
            //_damageView.transform.SetParent(UIcanvas.transform, false);
            //テストなのでダメージ表示は「1」
            // _damageView.GetComponent<TextMeshProUGUI>().text = "1";

            //スライムのHPがゼロになったら経験値オーブを生成して、自身のオブジェクトを削除する
            if (EnemyGob_HP <= 0)
            {
                PlayerStat.AddCursePoint(10);
                //  Instantiate(ExpOrb_Obj, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Fire")
        {
            sound04.PlayOneShot(sound04.clip);
            EnemyGob_HP -= EnemyGob_MaxHP / 5;
        }
        else if (collision.gameObject.tag == "Cyclon")
        {
            sound04.PlayOneShot(sound04.clip);
            EnemyGob_HP -= EnemyGob_MaxHP / 3;
        }
        else if (collision.gameObject.tag == "Water")
        {
            sound04.PlayOneShot(sound04.clip);
            EnemyGob_HP--;
        }

        if (!IsAttack && collision.gameObject.CompareTag("Player"))
        {
            IsAttack = true;
            AttackTime = 10.0f;
            Vector2 Distance = TargetObj.transform.position - this.transform.position;
            AttackDegree = Mathf.Atan2(Distance.y, Distance.x) * Mathf.Rad2Deg;
            //transform.RotateAround(centerObj.transform.position, Vector3.forward, angle * Time.deltaTime);

        }
        if (collision.gameObject.CompareTag("Wall"))
        {

            //壁にぶつかれば反発
            transform.Rotate(new Vector2(0, 180));
        }

    }
}

