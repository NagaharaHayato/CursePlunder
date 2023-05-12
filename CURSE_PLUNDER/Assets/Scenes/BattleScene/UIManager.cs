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

    [SerializeField] TextMeshProUGUI TimeCount;

    public static bool isWin = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)) {
            
            //VictoryUI.SetActive(true);
            //isWin = true;
        }
		Timer.countdownSecound -= Time.deltaTime;
		var span = new TimeSpan(0, 0, (int)Timer.countdownSecound);
        TimeCount.text = span.ToString(@"mm\:ss");

        if (Timer.countdownSecound <= 0) TimeoverUI.SetActive(true);

        CommandSelectUI.SetActive(PlayerControl.cmdselect_dialog);
    }
}
