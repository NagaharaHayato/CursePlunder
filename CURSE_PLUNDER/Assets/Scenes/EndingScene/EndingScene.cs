using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI StaffRoll_Text;
    Animator anim;

    public string[] StaffRolls;

    float NextBorderTime = 1.0f;
    int StaffRoll_phase = 0;
    int RowLength = 0;

    bool Waiting = false;

    private void Awake()
    {
        TextAsset TAsset = new TextAsset();
        TAsset = Resources.Load("StaffRoll_data", typeof(TextAsset)) as TextAsset;
        string TextLines = TAsset.text;

        StaffRolls = TextLines.Split("\n");
        RowLength = StaffRolls.Length;
    }

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float AnimTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (AnimTime >= NextBorderTime) 
        {
            
            
            TextChange();
        }
    }

    private void TextChange()
    {
        NextBorderTime += 1.0f;
        StaffRoll_phase++;
        if (RowLength > StaffRoll_phase)
        {
            StaffRoll_Text.text = StaffRolls[StaffRoll_phase];
        }else{
            this.gameObject.SetActive(false);
        }


    }
}
