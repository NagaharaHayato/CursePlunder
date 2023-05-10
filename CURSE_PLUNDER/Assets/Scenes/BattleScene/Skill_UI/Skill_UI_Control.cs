using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TerrainUtils;

public class Skill_UI_Control : MonoBehaviour
{
    [SerializeField] GameObject SelectCursol; Vector2 SCPos; private int Select = 0;
    [SerializeField] Image Icon;

    [SerializeField] GameObject UI_List;
    [SerializeField] GameObject UIText_NotSkill;
    [SerializeField] GameObject RestHP;

    [SerializeField] List<SkillDataList>[] skilldata;

    private int Skill_Index;
    //45
    void Start()
    {
        SCPos = SelectCursol.GetComponent<RectTransform>().anchoredPosition;
        
    }

    void Update()
    {
        Skill_Index = GameObject.FindGameObjectsWithTag("UI_SKILL").Length;

        if (Skill_Index <= 0) {
            UI_List.SetActive(false);
            UIText_NotSkill.SetActive(true);
        }
        else
        {
            UI_List.SetActive(true);
            UIText_NotSkill.SetActive(false);
            if (gameObject.activeInHierarchy)
            {
               
                if (Input.GetKeyDown(KeyCode.UpArrow)) Select--;
                if (Input.GetKeyDown(KeyCode.DownArrow)) Select++;

                if (Select < 0) Select = (Skill_Index-1);
                if (Select > --Skill_Index) Select = 0;

                SelectCursol.GetComponent<RectTransform>().anchoredPosition = new Vector2(SCPos.x, SCPos.y - (Select * 45.0f));

                RestHP.GetComponent<TextMeshProUGUI>().text = "/" + PlayerStat.HP.ToString();
            }
        }
    }
}
