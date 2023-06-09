using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{

    GameObject PlayerObj;
    Rigidbody2D OrbRB;
    Vector2 PlayerPos;
    float MOVE_SPEED = 0.1f;
    float MOVE_ANGLE;
    int MOVE_PHASE = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("ItemGetter");
        OrbRB = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = PlayerObj.GetComponent<Transform>().position;

        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, (MOVE_SPEED * Time.deltaTime)*UIManage.SpeedAdjust);
        MOVE_SPEED += 0.5f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemGetter"))
        {
            UIManage.GotExp++;
            Destroy(this.gameObject);
        }
    }
}
