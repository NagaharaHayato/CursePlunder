using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaun2 : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��������GameObject")]
    //private GameObject createPrefab;
    public GameObject createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;
    ////// HP


    int BossHP, BossMaxHP;
    
    ////// �o�ߎ���
    private float time;

    //int number = Random.Range(0, createPrefab.Length);
    void Start()
    {
        
        BossHP = BossUroboros.BossHP;
    }

    // Update is called once per frame

    void Update()
    {
        //�{�X��HP���X�V
        BossHP = BossUroboros.BossHP;

        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;

        // Boss��HP50�C�J�Ŕ���
        if (time > 5.0f)
        {
            if (BossHP <= 50)
            {
                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                //rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(rangeA.position.y, rangeB.position.y);
                //rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                //GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

                // �o�ߎ��ԃ��Z�b�g
                time = 0f;

            }

        }

    }
}