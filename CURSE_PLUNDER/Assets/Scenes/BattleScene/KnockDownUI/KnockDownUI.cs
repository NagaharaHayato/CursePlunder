using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnockDownUI : MonoBehaviour
{
    Animator animator; AnimatorStateInfo state;
    public static bool KDUI_Control = false;

    [SerializeField] GameObject[] Selector = new GameObject[2];
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

            
        }
    }

    public void EndAnimation()
    {
        
    }
}
