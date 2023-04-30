using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BossUroboros : MonoBehaviour
{
    [SerializeField]GameObject BossHPbar;
    [SerializeField] GameObject ExpOrb_Obj;
    [SerializeField] GameObject DamageView;

    GameObject FireBleath;

    GameObject TargetObj;
    GameObject UIcanvas;
    Animator BossAnim;
    [SerializeField] public int BossHP = 100;
    [SerializeField] float HP_per;
    int BossMaxHP;
    

    void Start()
    {
        TargetObj = GameObject.Find("Player");
        UIcanvas = GameObject.Find("UI");
        BossAnim = GetComponent<Animator>();

        BossMaxHP = BossHP;
    }

    // Update is called once per frame
    void Update()
    {
        HP_per = (float)BossHP / (float)BossMaxHP;
        BossHPbar.GetComponent<RectTransform>().anchorMax = new Vector2((0.5f * HP_per), BossHPbar.GetComponent<RectTransform>().anchorMax.y);

        BossAnim.SetFloat("Multiplier", UIManage.SpeedAdjust);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            BossHP--;
            GameObject _damageView = Instantiate(DamageView, this.transform.position, Quaternion.identity);
            _damageView.transform.SetParent(UIcanvas.transform, false);
            //_damageView.transform.position = transform.position;
            _damageView.GetComponent<TextMeshProUGUI>().text = "1";

            if (BossHP <= 0)
            {
                Instantiate(ExpOrb_Obj, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
