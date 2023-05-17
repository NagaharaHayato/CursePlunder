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
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0)
        {
            VictoryUI.SetActive(true);
        }

        if (BossUroboros.BossHP > 0) Timer.countdownSecound -= Time.deltaTime;
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
