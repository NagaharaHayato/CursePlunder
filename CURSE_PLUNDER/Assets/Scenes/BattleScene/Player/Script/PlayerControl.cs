using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEditor.Experimental.GraphView;

#pragma warning disable CS0618

public class PlayerControl : MonoBehaviour
{
	Animator animator;		//主人公の歩行アニメを扱うアニメーター
	Rigidbody2D PlayerRB;   //主人公の移動で使用するリジッドボディ

	//最後の入力された方向を覚えておくためベクター
	Vector2 lastmove = new Vector2(0,0);				//入力された方向を保存する用
	Vector2 moveact;									//移動ベクトル
	[SerializeField] public GameObject SwordObj;                //剣のオブジェクト
	[SerializeField] public GameObject FireObject;
    [SerializeField] public GameObject WaterObject;
    [SerializeField] public GameObject CyclonObject;
    [SerializeField] public GameObject FreeStyleSword;          //フリースタイルソード（角度指定可

	[SerializeField] private float MOVE_SPEED = 6.0f;  //主人公の移動速度
	public static float PLAYER_DIR_RAD = 90.0f;         //主人公の向き

	public static bool  cmdselect_dialog   = false;					//コマンドセレクト中かどうかのフラグ
	public static bool  Invisible          = false;		            //無敵フラグ（ノックダウンから復活後に敵からダメージを受けるのを防ぐ）
	public static int   InvisibleBlink     = 1; 					//無敵状態時にプレイヤーキャラを点滅させる用
	public static float Invisible_Interval = 0;						//無敵状態時の点滅アニメーション用
	public static float InvisibleTime      = 0;                     //無敵時間
	public static bool	Invisible_Victory  = false;

	public static float[] CooldownTime = new float[5];
	public static int GuardLimit = 2;
	bool[] IsCoolTime = new bool[5];

	public static int ControlMode = 0;

	private static int Damage_Color = 255;
	
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
		//
		if (Damage_Color <= 255) Damage_Color += 15;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, (float)Damage_Color / 255, (float)Damage_Color / 255, InvisibleBlink );

		for(int i = 0; i < 5; i++){
			if (CooldownTime[i] > 0){
				CooldownTime[i] -= Time.deltaTime;
            }
            else{
				IsCoolTime[i] = false;
			}
		}

		switch (ControlMode) {
			case 0:
				moveact = Vector2.zero;
                moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

				//選択されたスキルをカースポイントもしくはHPを消費して発動
				if (Input.GetKeyDown(KeyCode.S))
				{
					if (PlayerStat.HP > UISkill_Selector.GetSkillCost() ||
						Timer.countdownSecound > UISkill_Selector.GetSkillCost()){
                        switch (UISkill_Selector.GetSkillID())
                        {
                            //拡散発射
                            case 0:
								if (!IsCoolTime[0]){
									KnifeThrow();
									IsCoolTime[0] = true;

									Skill_CostPay();
                                }
                                break;

                            //ファイア
                            case 1:
								if (!IsCoolTime[1])
								{
                                    Instantiate(FireObject, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                                    IsCoolTime[1] = true;
                                    Skill_CostPay();

                                }
                                break;
                            //ガード
                            case 2:
								if (!Shield_Management.IsShield && !IsCoolTime[2] && UISkill_Selector.GuardLimit > 0){
									Shield_Management.Awake_Shield();
									UISkill_Selector.GuardLimit--;
                                    IsCoolTime[2] = true;

									Skill_CostPay();
                                }
                                break;

							//ウォーター
							case 3:
								if (!IsCoolTime[3]){
                                    Instantiate(WaterObject, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                                    IsCoolTime[3] = true;
                                    Skill_CostPay();
                                }
								break;

							//サイクロン
							case 4:
                                if (!IsCoolTime[4]){
                                    Instantiate(CyclonObject, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                                    IsCoolTime[4] = true;
                                    Skill_CostPay();
                                }
                                break;
                        }

						

                        
                    }
                }

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

                }else{
                    //何も入力されていない場合は「Walk」状態から「Wait」へ
                    //※フラグで管理する形にしているので「Walk」をfalseにすると
                    //自動的に「待機状態(Wait)」に状態が変わるようになってる
                    this.animator.SetBool("Walk", false);
                    PlayerRB.velocity = Vector2.zero;
                }

                //剣を投げる
                if (UIManage.ControlMode == 0 && Input.GetKeyDown(KeyCode.F))
                {
                    //剣のオブジェクトを生成し、主人公が向いている方向へ飛ばす（剣の移動処理は別のスクリプトで実装済み）
                    Instantiate(SwordObj, transform.position, Quaternion.Euler(0, 0, -PLAYER_DIR_RAD + 90));
                }
                break;
			default:
				break;
		}

		//無敵状態の場合
		if (Invisible)
		{
			InvisibleTime -= 1.0f;
			Invisible_Interval += Time.deltaTime;

			//点滅インターバルが0.2fを超えた場合
			if (Invisible_Interval >= 0.01f)
			{
				if (InvisibleBlink == 0) InvisibleBlink = 1; else InvisibleBlink = 0;
				Invisible_Interval = 0.0f;
			}

			if (InvisibleTime <= 0.0f){
				InvisibleBlink = 1;
				Invisible = false;
			}
		}

		//HPがゼロになったら行動不可に
		if (PlayerStat.HP <= 0) this.gameObject.SetActive(false);
	}

	private void DirectionChange(Vector2 vec)
	{
		//アニメーターにベクトルの値をセット（ベクトルの値に応じて画像が切り替わる）
		this.animator.SetFloat("VectorX", vec.x);
		this.animator.SetFloat("VectorY", vec.y);
		return;
	}

	public void KnifeThrow()
	{
		for(int i = 0; i < 45; i++) Instantiate(FreeStyleSword, transform.position, Quaternion.Euler(0, 0,i*16));
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!Invisible && !Invisible_Victory && collision.gameObject.CompareTag("Enemy"))
		{
			//スライムの攻撃状態を解除
			Slime_Act.IsAttack = false;

			//ダメージ処理を行う
			DamageProcess(50);

        }
		else if (collision.gameObject.CompareTag("EnemyFire")){
			DamageProcess(60);
        }
		else if (collision.gameObject.CompareTag("EnemyCyclon")){
			DamageProcess(40);
		}
		else if (collision.gameObject.CompareTag("EnemyWater")){
			DamageProcess(70);
		}
	}
	private void DamageProcess(int DamagePoint){
        //シールドの耐久値が残っていれば、シールドの耐久値をダメージ分減らし
        //シールドが張られていない状態であれば、そのままダメージをHPで受ける
        if (!Shield_Management.IsShield){
            
            PlayerStat.GiveDamage(DamagePoint);
			DamageColorZero();
			Invisibled();
        }
    }
	public static void DamageColorZero() { Damage_Color = 0; }
	public static void Invisibled()
	{
		//既に無敵状態の場合は無敵状態にならない
		if (!Invisible)
		{
			Invisible = true;
			InvisibleTime = 30.0f;
		}
	}

	void Skill_CostPay()
	{
        //クールダウンに入る
        CooldownTime[UISkill_Selector.GetSkillID()] = UISkill_Selector.Skill_CT;
        //コストを支払う
        PlayerStat.CostPay(UISkill_Selector.GetSkillCost());
    }
}