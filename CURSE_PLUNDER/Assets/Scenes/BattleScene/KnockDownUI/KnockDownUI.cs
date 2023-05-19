using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KnockDownUI : MonoBehaviour
{
    Animator animator; AnimatorStateInfo state;
    public static bool KDUI_Control = false;

    [SerializeField] GameObject PlayerObj;
    [SerializeField] GameObject[] Selector = new GameObject[2];
    [SerializeField] TextMeshProUGUI InfomationText;
    private int SelectCursol = 0;

    void Start()
    {
        animator    = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�A�j���[�V�������I��������I�𑀍���\�ɂ���
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) KDUI_Control = true;

        //�I�𑀍�
        if (KDUI_Control){
            if (Input.GetKeyDown(KeyCode.UpArrow)) SelectCursol--;
            if (Input.GetKeyDown(KeyCode.DownArrow)) SelectCursol++;

            //�Z���N�^�[���u0�ȉ��v�������́u1�ȏ�v�̏ꍇ�̓Z���N�^�[��߂�
            if (SelectCursol < 0) SelectCursol = 1;
            if (SelectCursol > 1) SelectCursol = 0;

            for(int i = 0; i < Selector.Length; i++)
            {
                if (i == SelectCursol){
                    //���ڂ��I������Ă����Ԃł���΃p�l����ԐF�ɕύX
                    Selector[i].GetComponent<Image>().color = new Color(255, 0, 0, Selector[i].GetComponent<Image>().color.a);
                }else{
                    //���ڂ��I������Ă��Ȃ���Ԃł���΃p�l�������F�ɕύX
                    Selector[i].GetComponent<Image>().color = new Color(0, 0, 0, Selector[i].GetComponent<Image>().color.a);
                }
            }

            switch (SelectCursol) {
                case 0:
                    if (PlayerStat.CursePoint >= PlayerStat.MaxHP){
                        //�J�[�X�|�C���g���ő�HP���������ꍇ
                        InfomationText.text = "�ێ����Ă���|�C���g(�c��" + PlayerStat.CursePoint + "Pt)��"+ PlayerStat.MaxHP + "Pt����ĕ���";

                    }else if(PlayerStat.CursePoint < PlayerStat.MaxHP && Timer.countdownSecound > (PlayerStat.MaxHP - PlayerStat.CursePoint)){
                        //�J�[�X�|�C���g���ő�HP�������Ȃ��A�c�莞�Ԃ��i�ő�̗͂ƃJ�[�X�|�C���g�̍����j�ȏ゠��ꍇ
                        InfomationText.text = "�ێ����Ă���|�C���g(" + PlayerStat.CursePoint + "Pt)�ƁA�c�莞�Ԃ�" + (PlayerStat.MaxHP - PlayerStat.CursePoint).ToString() + "�b������ĕ���";

					}else if(PlayerStat.CursePoint <= 0 && Timer.countdownSecound > PlayerStat.MaxHP){
                        //�J�[�X�|�C���g�������A�c�莞�Ԃ���������ꍇ
                        InfomationText.text = "�c�莞��(" + Timer.countdownSecound + "�b)����" + PlayerStat.MaxHP + "�b������ĕ���";
					}
                    break;
                case 1:
                    InfomationText.text = "�퓬����߂܂�";
                    break;
            }

            //����L�[�������ꂽ��I���ɉ����ď��������s
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (SelectCursol) {
                    case 0:     //REVIVE��I�������ꍇ
                        PlayerObj.SetActive(true);
						PlayerControl.Invisible = true;
                        PlayerControl.InvisibleTime = 100.0f;
                        PlayerStat.Revive();

                        //�Ō�ɂ���UI�����
                        this.gameObject.SetActive(false);
                        break;
                    case 1:     //RETIRE��I�������ꍇ

                        break;
                }

            }

        }
    }

    public void EndAnimation()
    {
        
    }
}
