using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePatical4 : MonoBehaviour
{
    // ˆÚ“®‘¬“x

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
        // ˆÚ“®
        move();

    }

    private void move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.x);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    //‰¡ˆÚ“®
    //    if ("Fire" == collision.gameObject.tag)
    //    {
    //        speed = speed*0;

    //    }
    //}
}
