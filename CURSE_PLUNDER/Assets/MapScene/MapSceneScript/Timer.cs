using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] GameObject DefeatUI;
    //public static float time=10;
    public static float time = 4320;
    // Start is called before the first frame update

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
            time -= Time.deltaTime;

            int t = Mathf.FloorToInt(time);
            Text uiText = GetComponent<Text>();
            uiText.text = "Time:" + t;
        }
        else if(time<=1)
        {
            DefeatUI.SetActive(true);
            isTimeUp = true;
        }
    }
}
