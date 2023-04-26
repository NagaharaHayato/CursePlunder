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
    [SerializeField] GameObject CmdUIinvoke;
    [SerializeField] TextMeshProUGUI SkillName;

    [SerializeField] GameObject DefeatUI;
    [SerializeField] GameObject DefeatSelector;

    RectTransform CmdSelector_RECT;
    Vector2 CmdSelector_POS, CmdSelector_FP;
    Vector2 DefeatSelector_POS, DefeatSelector_FP;
    [SerializeField]int CmdSelect = 0;

    public static int GotExp = 0;

    //コントロールモード
    //0：プレイヤー操作モード（移動や通常攻撃などプレイヤーを操作するモード）
    //1：コマンド選択モード（コマンド選択にて操作するモード）
    //2：Victory時の操作モード
    //3：Defeat時の操作モード

    public static int ControlMode = 0;
    public static float SpeedAdjust = 1.0f;

    void Start()
    {
        //CmdSelector = GameObject.Find("Cmd_Selector");
        CmdSelector_POS = CmdSelector.GetComponent<Transform>().position;
        CmdSelector_RECT = CmdSelector.GetComponent<RectTransform>();
        CmdSelector_FP = CmdSelector_POS;

        DefeatSelector_POS = DefeatSelector.GetComponent<Transform>().position;
        DefeatSelector_FP = DefeatSelector_POS;
    }
    // Update is called once per frame
    void Update()
    {
        //敵を全滅させた時、「Victory」を表示
        EnemyCount.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();

        

        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0)
        {
            DefeatUI.SetActive(true);
            ControlMode = 3;
        }

        //プレイヤー操作中
        if (Input.GetKeyDown(KeyCode.D))
        {
            switch (ControlMode)
            {
                case 0:
                    ControlMode = 1;
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
            case 1:
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
                
                if (Input.GetKeyDown(KeyCode.F))
                {
                    CmdUIinvoke.SetActive(true);

                    CmdSelectUI.SetActive(false);
                    ControlMode = 0;

                    SkillName.text = "ナイフ弾幕";

                    GameObject PlayerObj = GameObject.Find("Player");
                    PlayerControl Plcon = PlayerObj.GetComponent<PlayerControl>();
                    Plcon.KnifeThrow();
                }
                break;
            case 3:
                //170-244
                if (Input.GetKeyDown(KeyCode.UpArrow)){
                    CmdSelect--;
                    DefeatSelector_POS.y += 74.0f;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow)){
                    CmdSelect++;
                    DefeatSelector_POS.y -= 74.0f;
                }

                if (CmdSelect < 0){
                    CmdSelect = 1;
                    DefeatSelector_POS.y = DefeatSelector_FP.y - 74.0f;
                }
                else if (CmdSelect >= 2){
                    CmdSelect = 0;
                    DefeatSelector_POS.y = DefeatSelector_FP.y;
                }
                DefeatSelector.transform.position = DefeatSelector_POS;
                break;
        }

        
    }
}
