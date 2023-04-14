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
    float MOVE_SPEED = 10.0f;
    float MOVE_ANGLE;
    int MOVE_PHASE = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        OrbRB = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = PlayerObj.GetComponent<Transform>().position;

        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, MOVE_SPEED * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
