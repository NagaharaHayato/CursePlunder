using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time=4320;
    // Start is called before the first frame update
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        int t = Mathf.FloorToInt(time);
        Text uiText = GetComponent<Text>();
        uiText.text = "Time:" + t;
    }
}
