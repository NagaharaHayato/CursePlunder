using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

#pragma warning disable CS0618

public class PlayerControl : MonoBehaviour
{
	Animator animator;		//主人公の歩行アニメを扱うアニメーター
	Rigidbody2D PlayerRB;   //主人公の移動で使用するリジッドボディ

	//最後の入力された方向を覚えておくためベクター
	Vector2 lastmove = new Vector2(0,0);
	Vector2 moveact;

	[SerializeField] GameObject SwordObj;

	[SerializeField] private float MOVE_SPEED = 60.0f;   //主人公の移動速度
	public static float PLAYER_DIR_RAD = 90.0f;    //主人公の向き

	[SerializeField] TextMeshProUGUI radview;
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
		

		//方向キーの入力状態を取得
		moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		
		//方向キーが入力されていた場合
		if (moveact != Vector2.zero)
		{
			//アニメーターのステータスを「Walk」に切り替え
			this.animator.SetBool("Walk", true);

			//アニメーターに入力の状態を渡す
			//渡したベクターに応じて主人公の向きが変わる
			DirectionChange(moveact);

			//主人公の移動処理と最後の入力を覚えておく
			PlayerRB.velocity = moveact.normalized * MOVE_SPEED;
			
			lastmove = moveact;

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

		//剣を投げる
		if (Input.GetKeyDown(KeyCode.F))
		{
			Instantiate(SwordObj, transform.position,Quaternion.identity);
		}

		radview.text = PLAYER_DIR_RAD.ToString();
	}

	private void DirectionChange(Vector2 vec)
	{
		this.animator.SetFloat("VectorX", vec.x);
		this.animator.SetFloat("VectorY", vec.y);
		return;
	}
}