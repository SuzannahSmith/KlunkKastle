using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

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
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			// Debug.Log(movement);

			// Add a physical force to our Player rigidbody using our 'movement' Vector3 above,
			// multiplying it by 'speed' - our public player speed that appears in the inspector
			rb.AddForce (movement * speed, ForceMode.Acceleration);
	}
}
