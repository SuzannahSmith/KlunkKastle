using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	// public Camera maincamera;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

	}

	// Each physics ..
	void FixedUpdate ()
	{
			// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
			float moveHorizontal = Input.GetAxis ("MovementHorizontal");
			float moveVertical = Input.GetAxis ("MovementVertical");

			Vector3 cameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
			Vector3 cameraRight = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up);
			
			Vector3 movementDirection = Vector3.zero;
			movementDirection += moveVertical*Vector3.Normalize(cameraForward);
			movementDirection += moveHorizontal*Vector3.Normalize(cameraRight);

			// Add a physical force to our Player rigidbody using our 'movement' Vector3 above,
			// multiplying it by 'speed' - our public player speed that appears in the inspector
			rb.AddForce (movementDirection * speed, ForceMode.Acceleration);
	}
}
