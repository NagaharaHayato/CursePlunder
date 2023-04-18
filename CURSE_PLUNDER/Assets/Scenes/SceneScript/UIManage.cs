using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq.Expressions;

public class UIManage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI EnemyCount;
    [SerializeField] GameObject VictoryUI;
    

    public static int GotExp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();

        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0){
            VictoryUI.SetActive(true);
        }
    }
}
