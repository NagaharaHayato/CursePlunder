using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_UIManager : MonoBehaviour
{
    [SerializeField] GameObject VictoryUI;
    [SerializeField] GameObject KnockdownUI;
    [SerializeField] GameObject TimeoverUI;
    [SerializeField] GameObject TimeLimitUI;
    [SerializeField] GameObject BossDefeat_Fade;
    [SerializeField] GameObject Skill_SelectUI;
    [SerializeField] AudioSource ASource;

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
        BDF_Animator = BossDefeat_Fade.GetComponent<Animator>();
        isTimeStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStat.HP <= 0){
            isTimeStop = true;              //�J�E���g�_�E�����~
            KnockdownUI.SetActive(true);    //KnockdownUI�̗L����
        }

        //�{�X�̗̑͂��[������Ȃ���Ԃ��A�X�g�b�v�t���O���I�t�̏ꍇ�̓J�E���g�_�E����i�߂�
        if (BossUroboros.BossHP > 0 && !isTimeStop) Timer.countdownSecound -= Time.deltaTime;

        //�{�X�̗̑͂��[���ɂȂ����ꍇ�̓t�F�[�h�����s
        if (BossUroboros.BossHP <= 0) BossDefeat_Fade.SetActive(true);
        if (BossDefeat_Fade.activeInHierarchy && ASource.volume > 0.0f) ASource.volume = -0.15f;
        if (BDF_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (ASource.volume <= 0.0f) SceneManager.LoadScene("EndingScene");
        }
        
        
        var span = new TimeSpan(0, 0, (int)Timer.countdownSecound);
        TimeCount.text = span.ToString(@"mm\:ss");


    }
}