using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] GameObject DefeatUI;
    //public static float time=10;
    public static float time;
    // Start is called before the first frame update

    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    private Text timerText;

    public bool isTimeUp;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (time >= 1)
        {
            time = minute * 60 + seconds;
            time -= Time.deltaTime;

            //再設定
            minute = (int)time / 60;
            seconds = time - minute * 60;

            if((int)seconds!=(int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            oldSeconds = seconds;
            int t = Mathf.FloorToInt(time);
            Text uiText = GetComponent<Text>();
            uiText.text = "Time:" + t;
        }
        else if(time<=1)
        {
            //DefeatUI.SetActive(true);
            //isTimeUp = true;
        }
    }
}
