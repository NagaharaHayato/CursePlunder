using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHPBar_Manager : MonoBehaviour
{
    [SerializeField] GameObject BossHP_Bar;

    Animator anim;

    int BossHP, BossMaxHP;

    void Start()
    {
        BossHP = BossUroboros.BossHP;
        BossMaxHP = BossHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        //ボスのHPを更新
        BossHP = BossUroboros.BossHP;

        //ボスのHP割合を計算
        float BossHP_per = ((float)BossHP / (float)BossMaxHP);

        //HPバーの長さ調整
        BossHP_Bar.GetComponent<RectTransform>().anchorMax = new Vector2(BossHP_per, 1);

        //もしボスのHPがゼロの場合はオブジェクトを非表示に
        if (BossHP <= 0) this.gameObject.SetActive(false);
    }
}
