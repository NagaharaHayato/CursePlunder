using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	Animator animator;
	Rigidbody2D PlayerRB;

	Vector2 lastmove = new Vector2(0,0);

	float MOVE_SPEED = 60.0f;
	// Start is called before the first frame update
	void Start()
	{
		this.animator = GetComponent<Animator>();
		this.PlayerRB = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 moveact = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		

		if (moveact != Vector2.zero)
		{
			this.animator.SetBool("Walk", true);
			this.animator.SetFloat("VectorX", moveact.x);
			this.animator.SetFloat("VectorY", moveact.y);

			PlayerRB.velocity = moveact.normalized * MOVE_SPEED;
			lastmove = moveact;
		}
		else
		{
			this.animator.SetBool("Walk", false);
		}



	}
}