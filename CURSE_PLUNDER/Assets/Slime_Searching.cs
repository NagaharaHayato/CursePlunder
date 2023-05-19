using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Searching : MonoBehaviour
{
	public Slime_Act slimeAct;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))slimeAct.AttackLaunch();
	}
}
