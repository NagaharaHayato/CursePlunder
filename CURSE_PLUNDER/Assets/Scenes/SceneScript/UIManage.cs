using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //�R���g���[�����[�h
    //0�F�v���C���[���샂�[�h�i�ړ���ʏ�U���Ȃǃv���C���[�𑀍삷�郂�[�h�j
    //1�F�R�}���h�I�����[�h�i�R�}���h�I���ɂđ��삷�郂�[�h�j
    //2�FVictory���̑��샂�[�h
    //3�FDefeat���̑��샂�[�h

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
        //�G��S�ł��������A�uVictory�v��\��
        EnemyCount.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();

        

        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) <= 0)
        {
            VictoryUI.SetActive(true);
            ControlMode = 2;
        }

        //�v���C���[���쒆
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
            //�v���C���[���샂�[�h--------------------------------------------------------------------------------------------------------------------------//
            case 0:
                SpeedAdjust = 1.0f;                                     //�Q�[���S�̂̑��x��ʏ�ɖ߂�
                break;

            //�R�}���h�I�����[�h�̏ꍇ----------------------------------------------------------------------------------------------------------------------//
            case 1:
                //�Q�[���S�̂̑��x��0.3�{���ɐݒ�
                SpeedAdjust = 0.3f;

                //�㉺�L�[�ŃR�}���h�̑I��
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

                //�Z���N�g�ʒu��0�ȉ���������4�ȏ�ɂȂ����ꍇ�A�Z���N�g�ʒu�ƍ��W��߂�
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

                //�Z���N�g�ʒu��\���p�l���̈ʒu���X�V
                CmdSelector.transform.position = new Vector2(CmdSelector_POS.x, CmdSelector_POS.y);
                
                //����L�[[F]�ŃR�}���h�̎��s
                if (Input.GetKeyDown(KeyCode.F))
                {
                    CmdUIinvoke.SetActive(true);

                    CmdSelectUI.SetActive(false);
                    ControlMode = 0;

                    SkillName.text = "�i�C�t����";

                    GameObject PlayerObj = GameObject.Find("Player");
                    PlayerControl Plcon = PlayerObj.GetComponent<PlayerControl>();
                    Plcon.KnifeThrow();
                }
                break;
            
            //������----------------------------------------------------------------------------------------------------------------------------------------//
            case 2:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ControlMode = 0;

                    SceneManager.LoadScene("CaveScene2");
                }
                break;
            //�s�k���́uContinue�v���uRetire�v��I�����郂�[�h�̏ꍇ----------------------------------------------------------------------------------------//
            case 3:
                //�R�}���h�I���������I�ɕ���
                CmdUIinvoke.SetActive(false);
                CmdSelectUI.SetActive(false);


                //�㉺�L�[�őI��
                if (Input.GetKeyDown(KeyCode.UpArrow)){
                    CmdSelect--;
                    DefeatSelector_POS.y += 74.0f;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow)){
                    CmdSelect++;
                    DefeatSelector_POS.y -= 74.0f;
                }
                

                //�Z���N�g�ʒu���u0�ȉ��v�������́u4�ȏ�v�������ꍇ�͍��W�ƃZ���N�g�ʒu�̍Đݒ�
				if (CmdSelect < 0){
                    CmdSelect = 1;
                    DefeatSelector_POS.y = DefeatSelector_FP.y - 74.0f;
                }
                else if (CmdSelect >= 2){
                    CmdSelect = 0;
                    DefeatSelector_POS.y = DefeatSelector_FP.y;
                }

                //�Z���N�g�ʒu��\���p�l���̈ʒu���X�V
                DefeatSelector.transform.position = DefeatSelector_POS;

                //����L�[�������ꂽ����
                //CONTINUE(CmdSelect��0�j��I�����Ă���ꍇ�͂��̃V�[����ǂݒ���
                //RETIRE(CmdSelect��1�j��I�����Ă���ꍇ�́uTITLE�v�֍s����
                if (Input.GetKeyDown(KeyCode.F))
                {
                    switch (CmdSelect)
                    {
                        case 0:
                            CmdSelect = 0;
                            ControlMode = 0;

                            //��U�A�o�g���V�[����������x�ǂݒ���
                            SceneManager.LoadScene("BattleScene");
                            break;
                        case 1:
                            //�^�C�g���V�[���֖߂�
                            SceneManager.LoadScene("Title");
                            break;
                    }

                }
                break;
        }

        
    }
}
