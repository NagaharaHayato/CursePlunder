using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spaun : MonoBehaviour
{

    public GameObject[] obj;
    public float interval = 3.0f;
    public float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", time, interval);
    }

    // Update is called once per frame
    void SpawnObj()
    {
        int number = Random.Range(0, obj.Length);
        Instantiate(obj[number], transform.position, transform.rotation);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        
	}
}