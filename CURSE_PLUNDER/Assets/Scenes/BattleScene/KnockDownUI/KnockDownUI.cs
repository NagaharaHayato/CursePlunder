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
        //アニメーションが終了したら選択操作を可能にする
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) KDUI_Control = true;

        //選択操作
        if (KDUI_Control){
            if (Input.GetKeyDown(KeyCode.UpArrow)) SelectCursol--;
            if (Input.GetKeyDown(KeyCode.DownArrow)) SelectCursol++;

            //セレクターが「0以下」もしくは「1以上」の場合はセレクターを戻す
            if (SelectCursol < 0) SelectCursol = 1;
            if (SelectCursol > 1) SelectCursol = 0;

            for(int i = 0; i < Selector.Length; i++)
            {
                if (i == SelectCursol){
                    //項目が選択されている状態であればパネルを赤色に変更
                    Selector[i].GetComponent<Image>().color = new Color(255, 0, 0, Selector[i].GetComponent<Image>().color.a);
                }else{
                    //項目が選択されていない状態であればパネルを黒色に変更
                    Selector[i].GetComponent<Image>().color = new Color(0, 0, 0, Selector[i].GetComponent<Image>().color.a);
                }
            }

            
        }
    }

    public void EndAnimation()
    {
        
    }
}
