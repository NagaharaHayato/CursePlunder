using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UISkill_Selector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SkillName;
    [SerializeField] TextMeshProUGUI CostString;

    [SerializeField] GameObject Skill_CTobj;
    [SerializeField] TextMeshProUGUI Skill_CTime;

    [SerializeField] GameObject CountLimit_UI;
    [SerializeField] TextMeshProUGUI GuardLimit_UI;

    public static int SelectPosition = 0;
    private string Skill_NameString = "";
    public static int Skill_Cost = 0;
    public static float Skill_CT = 0;

    public static int GuardLimit = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) SelectPosition--;
        if (Input.GetKeyDown(KeyCode.W)) SelectPosition++;

        if (SelectPosition < 0) SelectPosition = 4;
        if (SelectPosition > 5) SelectPosition = 0;

        GuardLimit_UI.text = GuardLimit.ToString();

        if (SelectPosition == 2) { CountLimit_UI.SetActive(true); } else { CountLimit_UI.SetActive(false); }
        if (GuardLimit == 0) GuardLimit_UI.color = new Color(1.0f, 0.0f, 0.0f);

        Skill_CTime.text = PlayerControl.CooldownTime[SelectPosition].ToString("N1");

        if (PlayerControl.CooldownTime[SelectPosition] > 0.0f){
            Skill_CTobj.SetActive(true);
            
        }else{
            Skill_CTobj.SetActive(false);
        }

        InfomationUpdate();
    }

    void InfomationUpdate()
    {
        switch (SelectPosition)
        {
            //ナイフの拡散発射
            case 0:
                Skill_NameString = "Diffusion";
                Skill_Cost = 100;
                Skill_CT = 30.0f;
                break;

            //ファイア
            case 1:
                Skill_NameString = "Flame Fire";
                Skill_Cost = 30;
                Skill_CT = 3.0f;
                break;

            //ガード
            case 2:
                Skill_NameString = "Protection";
                Skill_Cost = 50;
                Skill_CT = 30.0f;
                break;

            //ウォーター
            case 3:
                Skill_NameString = "Water Blast";
                Skill_Cost = 30;
                Skill_CT = 3.0f;
                break;

            //サイクロン
            case 4:
                Skill_NameString = "Cyclon";
                Skill_Cost = 30;
                Skill_CT = 3.0f;
                break;
        }

        SkillName.text = Skill_NameString;
        CostString.text = Skill_Cost.ToString();
    }

    public static int GetSkillID() { return SelectPosition; }
    public static int GetSkillCost() { return Skill_Cost; }

    
}
