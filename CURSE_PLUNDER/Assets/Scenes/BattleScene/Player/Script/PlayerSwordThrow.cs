using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSwordThrow : MonoBehaviour
{
    [SerializeField] float MOVE_SPEED = 50.0f;
    
    Rigidbody2D SwordRB;
    Vector2 Directions;
    Vector2 PlayerDir;

    float rad;
    void Start()
    {
        SwordRB = GetComponent<Rigidbody2D>();


        rad = PlayerControl.PLAYER_DIR_RAD * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        
        SwordRB.velocity = new Vector2((Mathf.Cos(rad) * MOVE_SPEED)*UIManage.SpeedAdjust, (-Mathf.Sin(rad) * MOVE_SPEED) * UIManage.SpeedAdjust);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
