using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSwordThrow : MonoBehaviour
{

    [SerializeField] Sprite[] Sword_IMG = new Sprite[4];
    [SerializeField] float MOVE_SPEED = 1000.0f;
    Rigidbody2D SwordRB;
    Vector2 Directions;
    
    void Start()
    {
        SwordRB = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
