using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

#pragma warning disable CS0618

public class PlayerDemoMap : MonoBehaviour
{
    Rigidbody2D PlayerRB;   //主人公の移動で使用するリジッドボディ

    //最後の入力された方向を覚えておくためベクター
    Vector2 lastmove = new Vector2(0, 0);

    [SerializeField]
    private float MOVE_SPEED = 60.0f;   //主人公の移動速度

    void Start()
    {
        //リジッドボディの関連付け
        this.PlayerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //方向キーの入力状態を取得
        Vector2 moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //方向キーが入力されていた場合
        if (moveact != Vector2.zero)
        {

            //主人公の移動処理と最後の入力を覚えておく
            PlayerRB.velocity = moveact.normalized * MOVE_SPEED;

            lastmove = moveact;
        }
        else
        {
            //何も入力されていない場合は「Walk」状態から「Wait」へ
            //※フラグで管理する形にしているので「Walk」をfalseにすると
            //自動的に「待機状態(Wait)」に状態が変わるようになって
            PlayerRB.velocity = Vector2.zero;
        }


    }
}