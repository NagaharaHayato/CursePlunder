using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq.Expressions;
using Unity.VisualScripting;

public class UIManage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI EnemyCount;
    [SerializeField] GameObject VictoryUI;

    [SerializeField] GameObject CmdSelectUI;
    [SerializeField] GameObject CmdSelector;
    RectTransform CmdSelector_RECT;
    Vector2 CmdSelector_POS;
    Vector2 CmdSelector_FP;
    [SerializeField]int CmdSelect = 0;

    public static int GotExp = 0;
    
    //コントロールモード
    //0：プレイヤー操作モード（移動や通常攻撃などプレイヤーを操作するモード）
    //1：コマンド選択モード（コマンド選択にて操作するモード）
    //2：Victory/Defeat時の操作モード

    public static int ControlMode = 0;
    public static float SpeedAdjust = 1.0f;
    void Start()
    {
        //CmdSelector = GameObject.Find("Cmd_Selector");
        CmdSelector_POS = CmdSelector.GetComponent<Transform>().position;
        CmdSelector_RECT = CmdSelector.GetComponent<RectTransform>();
        CmdSelector_FP = CmdSelector_POS;
    }

    // Update is called once per frame
    void Update()
    {
        //敵を全滅させた時、「Victory」を表示
        EnemyCount.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();

        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0)
        {
            VictoryUI.SetActive(true);
            ControlMode = 2;
        }

        //プレイヤー操作中
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (ControlMode)
            {
                case 0:
                    ControlMode = 2;
                    CmdSelectUI.SetActive(true);
                    break;
                case 2:
                    ControlMode = 0;
                    CmdSelectUI.SetActive(false);
                    break;
            }

        }
        
        switch (ControlMode)
        {
            case 0:
                SpeedAdjust = 1.0f;
                break;
            case 2:
                SpeedAdjust = 0.3f;

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    CmdSelect--;
                    CmdSelector_POS.y += 43.0f;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    CmdSelect++;
                    CmdSelector_POS.y -= 43.0f;
                }

                if (CmdSelect < 0)
                {
                    CmdSelector_POS.y = CmdSelector_FP.y - (43.0f * 4);
                    CmdSelect = 4;
                }
                if (CmdSelect > 4)
                {
                    CmdSelector_POS.y = CmdSelector_FP.y;
                    CmdSelect = 0;
                }

                CmdSelector.transform.position = new Vector2(CmdSelector_POS.x, CmdSelector_POS.y);
                break;
        }
    }
}
