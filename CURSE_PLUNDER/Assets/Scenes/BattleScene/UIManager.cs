using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    void Start()
    {
        BDF_Animator = BossDefeat_Fade.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
