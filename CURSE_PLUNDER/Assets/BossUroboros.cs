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
    public static int BossHP = 100;
    public static int BossMaxHP;
    private float HP_per;

    private Vector3 targetpos;
   
    

    void Start()
    {
        TargetObj = GameObject.Find("Player");
        UIcanvas = GameObject.Find("UI");
        BossAnim = GetComponent<Animator>();

        targetpos = transform.position;

        BossMaxHP = BossHP;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 10.0f + targetpos.x, targetpos.y, targetpos.z);
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
