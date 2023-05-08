using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class TimeOverUI : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
            if (Input.GetKeyDown(KeyCode.F))
            {
                //ƒ^ƒCƒgƒ‹‚Ö–ß‚éˆ—
            }
        }
    }
}
