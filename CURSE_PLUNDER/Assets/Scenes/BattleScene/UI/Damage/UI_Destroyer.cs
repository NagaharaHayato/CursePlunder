using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Destroyer : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo aniInfo;

    float AnimLen;
    float AnimTime;
    void Start()
    {
        anim = GetComponent<Animator>();
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
            GameObject.Destroy(gameObject);
        }
    }
}
