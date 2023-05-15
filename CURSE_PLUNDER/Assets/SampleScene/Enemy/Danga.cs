using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danga : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float MOVE_SPEED = 10.0f;
    Rigidbody2D SwordRB;
    Vector2 Directions;
    Vector2 PlayerDir;

    float rad;

    public float deltaTime = 2.0f;

    void Start()
    {
        SwordRB = GetComponent<Rigidbody2D>();


        rad = (EnemyDemon.ENEMY_DIR_RAD * Mathf.Deg2Rad) + transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {

        SwordRB.velocity = new Vector2((Mathf.Cos(rad) * MOVE_SPEED) * UIManage.SpeedAdjust, (-Mathf.Sin(rad) * MOVE_SPEED) * UIManage.SpeedAdjust);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        

            Destroy(this.gameObject,deltaTime);
        
    }
}
