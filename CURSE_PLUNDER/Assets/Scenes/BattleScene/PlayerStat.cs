using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    // Start is called before the first frame update

    private string PlayerName;
    public static int HP, MaxHP;
    private int ATK, DefaultATK;
    private int DEF, DefaultDEF;
    private int CursePoint;
    private float HP_Percentage;

    public static int GotCursePoint = 0;

    [SerializeField] TextMeshProUGUI    PlayerName_String;
    [SerializeField] TextMeshProUGUI    HP_String;
    [SerializeField] TextMeshProUGUI    MaxHP_String;
    [SerializeField] TextMeshProUGUI    CursePoint_String;
    [SerializeField] GameObject         HP_Bar;

    [SerializeField] TextMeshProUGUI    GetCursedPointUI;

    void Awake()
    {
        PlayerName_String.text = PlayerPrefs.GetString("PlayerName");

        HP = PlayerPrefs.GetInt("HP");
        MaxHP = PlayerPrefs.GetInt("MaxHP");

        HP_String.text      = PlayerPrefs.GetInt("HP").ToString();
        MaxHP_String.text   = PlayerPrefs.GetInt("MaxHP").ToString();
        
        ATK         = PlayerPrefs.GetInt("ATK");
        DefaultATK  = PlayerPrefs.GetInt("DefaultATK");

        DEF         = PlayerPrefs.GetInt("DEF");
        DefaultDEF  = PlayerPrefs.GetInt("DefaultDEF");

        CursePoint  = PlayerPrefs.GetInt("CursePoint");
        CursePoint_String.text = CursePoint.ToString();

        HP_Percentage = (float)HP / (float)MaxHP;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HPバーの更新
        HP_Percentage = (float)HP / (float)MaxHP;
        HP_Bar.GetComponent<RectTransform>().anchorMax = new Vector2(HP_Percentage, 1);

        //獲得した呪いポイントを反映
        GetCursedPointUI.text = GotCursePoint.ToString();
    }

    public static void AddCursePoint(int cursepoint)
    {
        GotCursePoint += cursepoint;
    }
}
