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
        //HP�o�[�̍X�V
        HP_Percentage = (float)HP / (float)MaxHP;
        HP_Bar.GetComponent<RectTransform>().anchorMax = new Vector2(HP_Percentage, 1);

        HP_String.text = HP.ToString();

        //�l�������􂢃|�C���g�𔽉f
        CursePoint_String.text = CursePoint.ToString();

        //�ێ����Ă���J�[�X�|�C���g���ő�̗͈ȉ��̏ꍇ�͉��F�ɁA�[���̏ꍇ�͐ԐF
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
        //�_���[�W���󂯂��Ƃ��Ƀv���C���[�̃X�v���C�g�F���u�ԐF�v�f�v�݂̂ɂ���
        PlayerControl.DamageColorZero();

        //�_���[�W���󂯂����ƁA�A���Ń_���[�W���󂯂Ȃ��悤�Ɉ�莞�Ԗ��G��
        PlayerControl.Invisibled();

        if (HP > damage)
        {
            //�c��HP���_���[�W�ʂ̕������Ȃ��ꍇ�͂��̂܂܈���
            HP -= damage;
        }else if (HP <= damage)
        {
            //�c��HP���_���[�W�ʂ̕���������΋����I�Ƀ[����
            HP = 0;
        }
    }

    public static void Revive()
    {
      //�ێ����Ă�����͂��ő�̗͂�肠�邩
      if (CursePoint >= MaxHP)
        {
            //�ێ����Ă��镪����ő�̗͕����炷
            CursePoint -= MaxHP;

            //���S�ɉ񕜂�����
            HP = MaxHP;
        }else{
            //�c��J�[�X�|�C���g���������ő�̗͕����J�E���g���猸�炷
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
