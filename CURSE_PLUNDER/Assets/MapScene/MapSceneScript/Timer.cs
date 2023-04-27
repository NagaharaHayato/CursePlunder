using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    [SerializeField] GameObject DefeatUI;
    //public static float time=10;
    /// <summary>
    /// public static float time=4320;
    /// </summary>
    // Start is called before the first frame update

    public static int countdownMinu = 30;
    private static float countdownSecound = countdownMinu * 60;
    //　トータル制限時間
    private Text timeText;


    public bool isTimeUp;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        //if (time >= 1)
        //{

        //    time -= Time.deltaTime;
        //    int t = Mathf.FloorToInt(time);
        //    Text uiText = GetComponent<Text>();
        //    uiText.text = "Time:" + t;
        //}
        //else if (time <= 1)
        //{
        //    DefeatUI.SetActive(true);
        //    isTimeUp = true;
        //}
        if (countdownMinu >= 1)
        {
           
            countdownSecound -= Time.deltaTime;
            //int t = Mathf.FloorToInt(countdownMinu);
            timeText = GetComponent<Text>();
            //Text uiText = GetComponent<Text>();
            //uiText.text = "Time:" + t;
            var span = new TimeSpan(0, 0, (int)countdownSecound);
            timeText.text = span.ToString(@"mm\:ss");
        }
        if(countdownMinu<=1)
        {
                DefeatUI.SetActive(true);
                isTimeUp = true;
        }





    }
}
