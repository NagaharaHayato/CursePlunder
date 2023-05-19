using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePatical : MonoBehaviour
{
    // 移動速度

    public float speed = 5.0f;
    public float deleteTime = 2.0f;

    // Rigidbody
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, deleteTime);

    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        move();

    }

    private void move()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.x);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    //横移動
    //    if ("Fire" == collision.gameObject.tag)
    //    {
    //        speed = speed*0;

    //    }
    //}

}
