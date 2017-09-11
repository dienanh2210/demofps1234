using UnityEngine;
using System.Collections;

//using System.IO.Ports;
[RequireComponent(typeof(CharacterController))]

public class Unit : MonoBehaviour {



	protected CharacterController control;
	protected Vector3 move = Vector3.zero;
	protected Vector3 gravity = Vector3.zero;


	public float walkSpeed= 1f;
	public float runSpeed= 5f;
	public float turnSpeed= 90f;

	public float jumpSpeed=5f;

	protected bool jump;
	protected bool running;
	// Use this for initialization
	public virtual void Start () {
		control = GetComponent<CharacterController> ();
		if (!control) {
			print ("ok");

			enabled = false;
			
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		// dich chuyen theo toc do


		if (running)
				move *= runSpeed;
		else
				move *= walkSpeed;

		if (!control.isGrounded) {// contrl khong cham dat
				
			gravity +=Physics.gravity * Time.deltaTime;//keo control cham dat
		
			} else {

			gravity = Vector3.zero;
			if(jump)
			{
				gravity.y=jumpSpeed;
				jump=false;
			}
		}

		move += gravity;
		//control.SimpleMove (move * moveSpeed);
		control.Move (move  * Time.deltaTime);
	}
}
