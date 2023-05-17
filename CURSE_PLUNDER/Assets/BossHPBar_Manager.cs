using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHPBar_Manager : MonoBehaviour
{
    [SerializeField] GameObject BossHP_Bar;

    Animator anim;

    int BossHP, BossMaxHP;

    void Start()
    {
        BossHP = BossUroboros.BossHP;
        BossMaxHP = BossHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        //�{�X��HP���X�V
        BossHP = BossUroboros.BossHP;

        //�{�X��HP�������v�Z
        float BossHP_per = ((float)BossHP / (float)BossMaxHP);

        //HP�o�[�̒�������
        BossHP_Bar.GetComponent<RectTransform>().anchorMax = new Vector2(BossHP_per, 1);

        //�����{�X��HP���[���̏ꍇ�̓I�u�W�F�N�g���\����
        if (BossHP <= 0) this.gameObject.SetActive(false);
    }
}
