using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danga : MonoBehaviour
{
    public float power = 100f;
    public GameObject cannonBall;
    //public Transform spawnPoint;
    public float interval = 10.0f;
    //public float deltatime = 2.0f;
    public static float ENEMY_DIR_RAD = 90.0f;         //éÂêlåˆÇÃå¸Ç´

    void Start()
    {
       
        InvokeRepeating("KnifeThrow", 0.1f, interval);
        Shoot();
    }

    

    void Shoot()
    {
        GameObject newBullet = Instantiate(cannonBall, transform.position, Quaternion.Euler(0, 0, -ENEMY_DIR_RAD + 90)) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * power);
    }
    public void KnifeThrow()
    {
        for (int i = 0; i < 90; i++) Instantiate(cannonBall, transform.position, Quaternion.Euler(0, 0, i * 8));
    }
}
