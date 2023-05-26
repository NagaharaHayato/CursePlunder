using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    //4public static VictoryUI instance;

    Animator animator;
    void Start()
    {
        PlayerControl.ControlMode = 1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //�R���g���[�����[�h��ʏ탂�[�h�ɕύX���Ă����i�����[�h���ƃ}�b�v��ʂő��삪�ł��Ȃ��j
                PlayerControl.ControlMode = 0;
                
                //�l�������J�[�X�|�C���g��ǉ����Ă���
                PlayerStat.CursePoint += PlayerStat.GotCursePoint;
                PlayerStat.GotCursePoint = 0;

                //�}�b�v�V�[���֖߂�
                if (SceneManager.GetActiveScene().name == "BattleScene"){
                    SceneManager.LoadScene("CaveScene2");
                }else if (SceneManager.GetActiveScene().name == "BattleScene2"){
                    SceneManager.LoadScene("CaveScene4");
                }else if (SceneManager.GetActiveScene().name == "BattleScene3"){
                    SceneManager.LoadScene("CaveScene3");
                }else if (SceneManager.GetActiveScene().name == "BossFight"){
                    
                }
                UIManager.Stages++;
            }
        }
    }
}