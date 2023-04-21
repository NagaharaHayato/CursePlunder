using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Disable : MonoBehaviour
{
    [SerializeField] GameObject[] target = new GameObject[2];
    Animator anim;
    AnimatorStateInfo aniInfo;

    float AnimLen;
    float AnimTime;
    void Start()
    {
        anim = target[0].GetComponent<Animator>();
        aniInfo = anim.GetCurrentAnimatorStateInfo(0);
        AnimLen = aniInfo.length;
        AnimTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AnimTime += Time.deltaTime;
        if (AnimTime > AnimLen)
        {
            for(int i = 0; i < target.Length; i++)
            {
                target[i].SetActive(false);
            }
        }
    }
}
