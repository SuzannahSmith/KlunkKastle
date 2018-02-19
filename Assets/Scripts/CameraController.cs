using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform glorbie;
	private Vector3 offset;
	private Vector3 initialOffset;

	public int speed;

	private float verticalAngle;
	private float horizontalAngle;

	// Use this for initialization
	void Start () {
		speed = 50;
		offset = glorbie.position - transform.position;
		initialOffset = offset;
	}

	// Update is called once per frame
	void Update () {
		// offset = glorbie.position - transform.position;
		transform.position = glorbie.position - offset;

		float turnHorizontal = Input.GetAxis ("CameraHorizontal");
		float turnVertical = Input.GetAxis ("CameraVertical");


		if(!(turnVertical == 0 && turnHorizontal == 0)) {
			verticalAngle += speed * Time.deltaTime * turnVertical;
			horizontalAngle += speed * Time.deltaTime * turnHorizontal;
			transform.RotateAround(glorbie.position, transform.up, speed * Time.deltaTime * turnHorizontal);
			transform.RotateAround(glorbie.position, transform.right, speed * Time.deltaTime * turnVertical);
		}

		// if(turnHorizontal == 0) {
		// 	transform.RotateAround(glorbie.position, transform.up, -horizontalAngle);
		// 	horizontalAngle = 0;
		// }
		if(turnVertical == 0) {
			transform.RotateAround(glorbie.position, transform.right, -verticalAngle);
			verticalAngle = 0;
		}

		offset = glorbie.position - transform.position;
	}

}
