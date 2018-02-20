using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TipBackHead : MonoBehaviour {

	public Rigidbody bodyRb;

	private float tipAngle = -50.0f;

	// Each physics step..
	void FixedUpdate ()
	{

			float moveHorizontal = Math.Abs(Input.GetAxis ("MovementHorizontal"));
			float moveVertical = Math.Abs(Input.GetAxis ("MovementVertical"));

			float movement = (moveVertical + moveHorizontal)/2;

			Quaternion lookRotation;
			if(bodyRb.velocity != Vector3.zero) {
				 lookRotation = Quaternion.LookRotation(bodyRb.velocity);
			}
			else {
				Vector3 cameraAngle = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
				 lookRotation = Quaternion.LookRotation(cameraAngle);
			}
			// lookRotation = Quaternion.LookRotation(cameraAngle);

			Quaternion tipRotation = Quaternion.AngleAxis(tipAngle*movement, Vector3.right);

			transform.rotation = lookRotation*tipRotation;
	}
}
