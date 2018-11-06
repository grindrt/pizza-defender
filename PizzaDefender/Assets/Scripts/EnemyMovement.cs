using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement:MonoBehaviour{

	public EnemyController enemyController;

	private float horizontalMove = 0f;

	public float runSpeed = 40f;

	private bool jump;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {        
		this.horizontalMove = 1 * runSpeed;

		// jump = Input.GetButtonDown("Jump");
    }

/// <summary>
/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
/// </summary>
void FixedUpdate()
{
		this.enemyController.Move(this.horizontalMove * Time.fixedDeltaTime, jump);

		jump = false;
    
}
}