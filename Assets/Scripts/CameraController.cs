using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

	public Transform glorbieBody;
	private Vector3 offset;

	private float VERTICLE_UPPER_ANGLE_LIMIT = 40.0f;
	private float VERTICLE_LOWER_ANGLE_LIMIT = -20.0f;
	private float VERTICLE_MOUSE_LIMIT = 0.4f;
	private float HORIZONTAL_MOUSE_LIMIT = 0.2f;
	public float resetSpeed = 40f;

	private float verticalAngle;
	private float horizontalAngle;
	private float turnSpeed = 20f;

	private static float permanentOffsetCameraAngle;
	private static float offsetToGo;
	private static bool offsetNow;

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

		float turnHorizontal  = Input.GetAxis("Mouse X");
		float turnVertical  = Input.GetAxis("Mouse Y");

		//Rotate Camera around glorbie, so that he can turn and see in every direction
		if(Math.Abs(turnHorizontal) > HORIZONTAL_MOUSE_LIMIT &&
			Input.GetMouseButton(0)) {
			float step = turnHorizontal*turnSpeed*Time.deltaTime;
			horizontalAngle += step;
			transform.RotateAround(glorbieBody.position, Vector3.up, step);
		}
		if(Math.Abs(turnVertical) > VERTICLE_MOUSE_LIMIT &&
			CheckValidAngle(verticalAngle, turnVertical) &&
			 Input.GetMouseButton(0)) {

			float step = turnVertical*turnSpeed*Time.deltaTime;
			verticalAngle += step;
			transform.RotateAround(glorbieBody.position, transform.right, step);
		}

		SnapCameraBack();

		PermanentlyChangeCameraAngle ();

		offset = glorbieBody.position - transform.position;
	}

	private void SnapCameraBack() {

		//If user lets go of up or down button, the camera angle will return to normal.
		if(!Input.GetMouseButton(0)) {
			float step = resetSpeed*Time.deltaTime;
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
		return ((angle > VERTICLE_LOWER_ANGLE_LIMIT) && (angle < VERTICLE_UPPER_ANGLE_LIMIT))
				|| ((angle >= VERTICLE_UPPER_ANGLE_LIMIT) && direction < 0)
				|| ((angle <= VERTICLE_LOWER_ANGLE_LIMIT) && direction > 0);
	}

//	private float GetHorizontalMouseAxis() {
//		return (Input.mousePosition.x/Screen.width*2) -1;
//	}
//
//	private float GetVerticalMouseAxis() {
//		return (Input.mousePosition.y/Screen.height*2) -1;
//	}
//
	public static void InitAngleChange(float angle) {
		permanentOffsetCameraAngle = angle;
		offsetToGo = angle;
		offsetNow = true;
	}

	public void PermanentlyChangeCameraAngle () {
		if (offsetNow) {
			float step = permanentOffsetCameraAngle * Time.deltaTime;
			transform.RotateAround (glorbieBody.position, transform.right, step);

			offsetToGo -= step;
			if (Math.Abs(offsetToGo) < 1.5f) {
				offsetNow = false;
				permanentOffsetCameraAngle = 0f;
				offsetToGo = 0;
			}
		}
	}
}
