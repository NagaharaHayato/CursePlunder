using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    // Start is called before the first frame update

    public string PlayerName;
    public static int HP, MaxHP;
    private int ATK, DefaultATK;
    private int DEF, DefaultDEF;
    public static int CursePoint;
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
        
        ATK         = PlayerPrefs.GetInt("Attack");
        DefaultATK  = PlayerPrefs.GetInt("MaxAttack");

        DEF         = PlayerPrefs.GetInt("Defence");
        DefaultDEF  = PlayerPrefs.GetInt("MaxDefence");

        CursePoint  = PlayerPrefs.GetInt("CursePoint");
        CursePoint_String.text = CursePoint.ToString();

        HP_Percentage = (float)HP / (float)MaxHP;
    }


    void Start()
    {

        //DontDestroyOnLoad();
    }

    // Update is called once per frame
    void Update()
    {
        //HPバーの更新
        HP_Percentage = (float)HP / (float)MaxHP;
        HP_Bar.GetComponent<RectTransform>().anchorMax = new Vector2(HP_Percentage, 1);

        HP_String.text = HP.ToString();

        //獲得した呪いポイントを反映
        CursePoint_String.text = CursePoint.ToString();

        //保持しているカースポイントが最大体力以下の場合は黄色に、ゼロの場合は赤色
        if (CursePoint <= MaxHP && CursePoint > 0){
            CursePoint_String.color = Color.yellow;
        }else if (CursePoint <= 0){
            CursePoint_String.color = Color.red;
        }else{
            CursePoint_String.color = Color.white;
        }
    }

    public static void AddCursePoint(int cursepoint)
    {
        GotCursePoint += cursepoint;
    }

    public static void GiveDamage(int damage)
    {
        //ダメージを受けたときにプレイヤーのスプライト色を「赤色要素」のみにする
        PlayerControl.DamageColorZero();

        //ダメージを受けたあと、連続でダメージを受けないように一定時間無敵に
        PlayerControl.Invisibled();

        if (HP > damage)
        {
            //残りHPよりダメージ量の方が少ない場合はそのまま引く
            HP -= damage;
        }else if (HP <= damage)
        {
            //残りHPよりダメージ量の方が多ければ強制的にゼロに
            HP = 0;
        }
    }

    public static void Revive()
    {
      //保持している呪力が最大体力よりあるか
      if (CursePoint >= MaxHP)
        {
            //保持している分から最大体力分減らす
            CursePoint -= MaxHP;

            //完全に回復させる
            HP = MaxHP;
        }else{
            //残りカースポイントを引いた最大体力分をカウントから減らす
            float RestSecond = Timer.countdownSecound;

			Timer.countdownSecound -= MaxHP - CursePoint;

            CursePoint = 0;
        }
    }

    public static void CostPay(int costpay)
    {
        if (HP > costpay) HP -= costpay;
    }
}
