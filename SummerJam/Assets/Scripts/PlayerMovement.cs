using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float horizontalTurnSpeed = 1.5F;
	public float verticalTurnSpeed = 0.0F;
	public float speed = 9.0F;
	public float jumpSpeed = 8.0F; 
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public Transform playerTran;

	public bool playerIsClimbing;
    public Rigidbody playerRB;

	void Start()
    {
		playerIsClimbing = false;
        //this is where I get the rigidbody from the playerObject for later use
        playerRB = GetComponent<Rigidbody>();
    }

	void Update()
    {

		//looking around stuff
        {
			float h = horizontalTurnSpeed * Input.GetAxis ("Mouse X");
			float v = verticalTurnSpeed * Input.GetAxis ("Mouse Y");
			transform.Rotate (v, h, 0);

		}

		CharacterController controller = GetComponent<CharacterController>();
		// is the controller on the ground?
		if (controller.isGrounded)
        {
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;

		}

        if (playerIsClimbing == true)
        {
            gravity = 0.0F;
            playerRB.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            gravity = 20.0F;
        }
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);

	}
}
