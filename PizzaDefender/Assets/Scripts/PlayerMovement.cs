using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public PlayerController playerController;

	private float horizontalMove = 0f;

	public float runSpeed = 40f;

	private bool jump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		jump = Input.GetButtonDown("Jump");
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		this.playerController.Move(this.horizontalMove * Time.fixedDeltaTime, jump);

		jump = false;
	}
}
