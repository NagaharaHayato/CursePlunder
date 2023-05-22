using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    //4public static VictoryUI instance;

    Animator animator;
    void Start()
    {
        PlayerControl.ControlMode = 1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //コントロールモードを通常モードに変更しておく（他モードだとマップ画面で操作ができない）
                PlayerControl.ControlMode = 0;
                
                //獲得したカースポイントを追加しておく
                PlayerStat.CursePoint += PlayerStat.GotCursePoint;
                PlayerStat.GotCursePoint = 0;

                //マップシーンへ戻る
                SceneManager.LoadScene("CaveScene");
            }
        }
    }
}
