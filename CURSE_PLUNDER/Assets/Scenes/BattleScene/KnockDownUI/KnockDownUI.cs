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

            switch (SelectCursol) {
                case 0:
                    if (PlayerStat.CursePoint >= PlayerStat.MaxHP){
                        //カースポイントが最大HPよりも多い場合
                        InfomationText.text = "保持しているポイント(残り" + PlayerStat.CursePoint + "Pt)を"+ PlayerStat.MaxHP + "Pt消費して復活";

                    }else if(PlayerStat.CursePoint < PlayerStat.MaxHP && Timer.countdownSecound > (PlayerStat.MaxHP - PlayerStat.CursePoint)){
                        //カースポイントが最大HPよりも少なく、残り時間が（最大体力とカースポイントの差分）以上ある場合
                        InfomationText.text = "保持しているポイント(" + PlayerStat.CursePoint + "Pt)と、残り時間の" + (PlayerStat.MaxHP - PlayerStat.CursePoint).ToString() + "秒を消費して復活";

					}else if(PlayerStat.CursePoint <= 0 && Timer.countdownSecound > PlayerStat.MaxHP){
                        //カースポイントが無く、残り時間だけがある場合
                        InfomationText.text = "残り時間(" + Timer.countdownSecound + "秒)から" + PlayerStat.MaxHP + "秒を消費して復活";
					}
                    break;
                case 1:
                    InfomationText.text = "戦闘を諦めます";
                    break;
            }

            //決定キーが押されたら選択に応じて処理を実行
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (SelectCursol) {
                    case 0:     //REVIVEを選択した場合
                        PlayerObj.SetActive(true);
						PlayerControl.Invisible = true;
                        PlayerControl.InvisibleTime = 100.0f;
                        PlayerStat.Revive();

                        //最後にこのUIを閉じる
                        this.gameObject.SetActive(false);
                        break;
                    case 1:     //RETIREを選択した場合

                        break;
                }

            }

        }
    }

    public void EndAnimation()
    {
        
    }
}
