using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield_Management : MonoBehaviour
{
    public static Shield_Management Instance;

    [SerializeField] public GameObject Shield_HPobj;
    [SerializeField] public CircleCollider2D cCollider;

    public static bool  IsShield             = false;      //�V�[���h�̗L���t���O
    public static bool  IsShieldInvisible    = false;
    public static int   Shield_HP           = 0;          //�V�[���h�̑ϋv�l
    public static int   Shield_MaxHP        = 0;          //�V�[���h�̍ő�ϋv�l
    public static int   Shield_LV           = 0;          //�V�[���h�̃��x��

    void Start()
    {

        //�V�[���h�̃��x�����擾
        Shield_LV = PlayerPrefs.GetInt("Shield_Lv");

        //�V�[���h�̑ϋv�l�ݒ�
        Shield_MaxHP = 500 * Shield_LV;

        
    }

    // Update is called once per frame
    void Update()
    {
        Shield_HPobj.SetActive(IsShield);
        cCollider.enabled = IsShield;
    }

    public static void Awake_Shield(){
        //�V�[���h�������Ɩ����̏�Ԃł���ꍇ�̂݃V�[���h�𔭓�
        if (!IsShield){
            //�V�[���h��L����
            IsShield = true;

            //�v���C���[��HP����ɃV�[���h�̑ϋv�l��ݒ�
            Shield_HP = Shield_MaxHP;
        }
    }
    void Shield_Damage(int Shield_DMG)
    {
        if (IsShield && Shield_HP>=0){
            Shield_HP -= Shield_DMG;
            if (Shield_HP <= 0){
                IsShield = false;
                Shield_HPobj.SetActive(false);
            }
        }
    }

    public int GetShield_HP() { return (Shield_HP); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�X���C���̍U���t���O�������Ă���ꍇ�̓V�[���h�̑ϋv�l�����炷
        if (Slime_Act.IsAttack && collision.gameObject.CompareTag("Enemy")) Shield_Damage(50);
        Debug.Log("Shield HP" + Shield_HP);

    }
}
