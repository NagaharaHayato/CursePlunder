using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI StaffRoll_Text;
    [SerializeField] TextAsset texts;
    Animator anim;

    string[] StaffRolls;

    float NextBorderTime = 1.0f;
    int StaffRoll_phase = 0;
    int RowLength = 0;


    void Awake()
    {
        
        string TextLines = texts.text;

        StaffRolls = TextLines.Split("\n");
        RowLength = StaffRolls.Length - 1;
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
        }else if (RowLength <= StaffRoll_phase){
            SceneManager.LoadScene("Title");
        }


    }
}
