using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject VictoryUI;
    [SerializeField] GameObject KnockdownUI;
    [SerializeField] GameObject TimeoverUI;
    [SerializeField] GameObject TimeLimitUI;
    //[SerializeField] GameObject BossDefeat_Fade;
    [SerializeField] GameObject Skill_SelectUI;

    [SerializeField] TextMeshProUGUI TimeCount;

    Animator BDF_Animator;

    public static bool isWin = false;
    public static bool isTimeStop = false;
    public static int ControlMode = 0;
    public static float SpeedAdjust = 1.0f;

    public static int Stages = 0;

    public static GameObject HitEnemyObj;

    void Start()
    {
        //BDF_Animator = BossDefeat_Fade.GetComponent<Animator>();
        isTimeStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //すべての敵を殲滅したら勝利画面を表示する
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0)
        {
            isTimeStop = true;              //カウントダウンを停止
            VictoryUI.SetActive(true);      //VictoryUIの有効化
            Skill_SelectUI.SetActive(false);

        //プレイヤーのHPがゼロになった場合
        }else if (PlayerStat.HP <= 0){
            isTimeStop = true;              //カウントダウンを停止
            KnockdownUI.SetActive(true);    //KnockdownUIの有効化
        }

        //ボスの体力がゼロじゃない状態かつ、ストップフラグがオフの場合はカウントダウンを進める
        if (BossUroboros.BossHP > 0 && !isTimeStop) Timer.countdownSecound -= Time.deltaTime;

        //ボスの体力がゼロになった場合はフェードを実行
       // if (BossUroboros.BossHP <= 0) BossDefeat_Fade.SetActive(true);
        
        
        var span = new TimeSpan(0, 0, (int)Timer.countdownSecound);
        TimeCount.text = span.ToString(@"mm\:ss");

       // if (Timer.countdownSecound <= 0) TimeoverUI.SetActive(true);


        //if (BossDefeat_Fade.activeInHierarchy && BDF_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene("ClearScene");
        //}

        //if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0)
        //{
        //    VictoryUI.SetActive(true);
        //    if (VictoryUI.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && Input.GetKeyDown(KeyCode.F))
        //    {
        //        UnityEngine.SceneManagement.SceneManager.LoadScene("CaveScene");
        //    }
        //}

    }
}
