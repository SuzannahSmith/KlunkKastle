using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public bool wasPressed;
	public GameObject button;
	public Light buttonLight;

	// Use this for initialization
	void Start () {
		wasPressed = false;
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag != "Obstacle") {
			button.GetComponent<Renderer>().material.color = Color.green;
			buttonLight.color = Color.green;

			//Play push button animation
			button.GetComponent<Animator>().SetBool("isPressed", true);

			wasPressed = true;
		}
	}
}
