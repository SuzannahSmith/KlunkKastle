using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivated : MonoBehaviour {

	public ButtonController[] buttons;
	private bool openDoor;

	void Start() {
		openDoor = false;
	}

	// Update is called once per frame
	void Update () {
		if(openDoor == false) {
			openDoor = true;
			
			foreach(ButtonController button in buttons) {
				if(!button.wasPressed)
					openDoor = false;
			}

			if(openDoor) {
				GetComponent<Animator>().SetBool("openDoor", true);
			}
		}
	}
}
