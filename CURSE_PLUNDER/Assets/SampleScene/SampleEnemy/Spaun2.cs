using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaun2 : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    //private GameObject createPrefab;
    public GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;
    ////// HP


    int BossHP, BossMaxHP;
    
    ////// 経過時間
    private float time;

    //int number = Random.Range(0, createPrefab.Length);
    void Start()
    {
        
        BossHP = BossUroboros.BossHP;
    }

    // Update is called once per frame

    void Update()
    {
        //ボスのHPを更新
        BossHP = BossUroboros.BossHP;

        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;

        // BossのHP50イカで発動
        if (time > 5.0f)
        {
            if (BossHP <= 50)
            {
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                //rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y = Random.Range(rangeA.position.y, rangeB.position.y);
                //rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                //GameObjectを上記で決まったランダムな場所に生成
                Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

                // 経過時間リセット
                time = 0f;

            }

        }

    }
}