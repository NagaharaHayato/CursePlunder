using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject VictoryUI;
    [SerializeField] GameObject KnockdownUI;
    [SerializeField] GameObject TimeoverUI;
    [SerializeField] GameObject CommandSelectUI;
    [SerializeField] GameObject TimeLimitUI;
    [SerializeField] GameObject BossDefeat_Fade;

    [SerializeField] TextMeshProUGUI TimeCount;

    Animator BDF_Animator;

    public static bool isWin = false;
    public static bool isTimeStop = false;
    public static int ControlMode = 0;
    public static float SpeedAdjust = 1.0f;
    public static GameObject HitEnemyObj;

    void Start()
    {
        BDF_Animator = BossDefeat_Fade.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        //���ׂĂ̓G��r�ł����珟����ʂ�\������
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0)
        {
            isTimeStop = true;              //�J�E���g�_�E�����~
            VictoryUI.SetActive(true);      //VictoryUI�̗L����

        //�v���C���[��HP���[���ɂȂ����ꍇ
        }else if (PlayerStat.HP <= 0){
            isTimeStop = true;              //�J�E���g�_�E�����~
            KnockdownUI.SetActive(true);    //KnockdownUI�̗L����
        }

        //�{�X�̗̑͂��[������Ȃ���Ԃ��A�X�g�b�v�t���O���I�t�̏ꍇ�̓J�E���g�_�E����i�߂�
        if (BossUroboros.BossHP > 0 && !isTimeStop) Timer.countdownSecound -= Time.deltaTime;

        //�{�X�̗̑͂��[���ɂȂ����ꍇ�̓t�F�[�h�����s
        if (BossUroboros.BossHP <= 0) BossDefeat_Fade.SetActive(true);
        
        
        var span = new TimeSpan(0, 0, (int)Timer.countdownSecound);
        TimeCount.text = span.ToString(@"mm\:ss");

        if (Timer.countdownSecound <= 0) TimeoverUI.SetActive(true);

        CommandSelectUI.SetActive(PlayerControl.cmdselect_dialog);

        if (BossDefeat_Fade.activeInHierarchy && BDF_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ClearScene");
        }

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
