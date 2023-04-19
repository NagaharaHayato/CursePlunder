using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BossUroboros : MonoBehaviour
{
    [SerializeField]GameObject BossHPbar;
    [SerializeField] GameObject DamageView;
    GameObject TargetObj;
    GameObject UIcanvas;
    
    public static int BossHP = 1000;
    int BossMaxHP;
    

    void Start()
    {
        TargetObj = GameObject.Find("Player");
        UIcanvas = GameObject.Find("UI");
        BossMaxHP = BossHP;
    }

    // Update is called once per frame
    void Update()
    {
        float HP_per = (float)BossHP / (float)BossMaxHP;
        BossHPbar.GetComponent<RectTransform>().anchorMax = new Vector2(-610.0f + (310.0f * HP_per) * 2, BossHPbar.GetComponent<RectTransform>().anchorMax.y);
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
        }
    }
}
