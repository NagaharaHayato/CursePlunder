using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillList", menuName = "Data/SkillData")]
public class SkillDataList : ScriptableObject
{
    public List<SkillData> Skill_List = new List<SkillData>();
}

public class SkillData {
    public string Skill_Name;
    public string Skill_Description;
    public int Skill_Cost;
    public GameObject Skill_Execute;
}
