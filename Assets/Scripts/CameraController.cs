using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

	public Transform glorbieBody;
	public Rigidbody glorbieRb;
	public Transform glorbieHead;
	private Vector3 offset;

	private float ANGLE_LIMIT = 50.0f;
	private float MOUSE_LIMIT = 0.2f;
	public int speed = 50;

	private float verticalAngle;
	private float horizontalAngle;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Confined;

		offset = glorbieBody.position - transform.position;
		verticalAngle = 0;
		horizontalAngle = 0;
	}

	// Update is called once per frame
	void Update () {
		transform.position = glorbieBody.position - offset;

		Vector3 mousePos = Input.mousePosition;
		float turnHorizontal  = (mousePos.x/Screen.width*2)-1;
		float turnVertical  = -1*((mousePos.y/Screen.height*2)-1);
		// float turnHorizontal = Input.GetAxis ("CameraHorizontal");
		// float turnVertical = Input.GetAxis ("CameraVertical");

		//Rotate Camera around glorbie, so that he can turn and see in every direction
		if(Math.Abs(turnHorizontal) > MOUSE_LIMIT) {
			horizontalAngle += speed * Time.deltaTime * turnHorizontal;
			transform.RotateAround(glorbieBody.position, Vector3.up, speed * Time.deltaTime * turnHorizontal);
		}
		if(Math.Abs(turnVertical) > MOUSE_LIMIT && CheckValidAngle(verticalAngle, turnVertical)) {
			verticalAngle += speed * Time.deltaTime * turnVertical;
			transform.RotateAround(glorbieBody.position, transform.right, speed * Time.deltaTime * turnVertical);
		}

		// SnapCameraBack();

		offset = glorbieBody.position - transform.position;
	}

	private void SnapCameraBack() {

		float turnHorizontal = Input.GetAxis ("CameraHorizontal");
		float turnVertical = Input.GetAxis ("CameraVertical");

		// if(turnHorizontal == 0) {
		// 	float step = 20*Time.deltaTime;
		//
		// 	//Get angle between direction that Glorbie is facing, and direction of camera.
		// 	Vector3 headAngle = Vector3.ProjectOnPlane(glorbieHead.forward, Vector3.up);
		// 	Vector3 cameraAngle = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
		// 	float glorbieAngle = Vector3.SignedAngle(headAngle, cameraAngle, Vector3.up);
		//
		// 	if(Math.Abs(glorbieAngle) - step < 0) {
		// 		glorbieAngle = 0;
		// 	}
		// 	else if (horizontalAngle > 0) {
		// 		transform.RotateAround(glorbieBody.position, transform.up, -step);
		// 		glorbieAngle -= step;
		// 	}
		// 	else {
		// 		transform.RotateAround(glorbieBody.position, transform.up, step);
		// 		glorbieAngle += step;
		// 	}
		// }

		//If user lets go of up or down button, the camera angle will return to normal.
		if(turnVertical == 0) {
			float step = speed*Time.deltaTime;
			if(Math.Abs(verticalAngle) - step < 0) {
				verticalAngle = 0;
			}
			else if(verticalAngle < 0) {
				transform.RotateAround(glorbieBody.position, transform.right, step);
				verticalAngle += step;
			}
			else {
				transform.RotateAround(glorbieBody.position, transform.right, -step);
				verticalAngle -= step;
			}
		}

	}

	private bool CheckValidAngle(float angle, float direction) {
		return ((angle < ANGLE_LIMIT) && (angle > -1*ANGLE_LIMIT))
				|| ((angle <= -1*ANGLE_LIMIT) && direction > 0)
				|| ((angle >= ANGLE_LIMIT) && direction < 0);
	}

}
