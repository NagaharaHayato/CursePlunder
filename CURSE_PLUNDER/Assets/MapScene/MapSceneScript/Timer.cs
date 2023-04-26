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

    //�@�������ԁi���j
    [SerializeField]
    private int minute;
    //�@�������ԁi�b�j
    [SerializeField]
    private float seconds;
    //�@�O��Update���̕b��
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

            //�Đݒ�
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
