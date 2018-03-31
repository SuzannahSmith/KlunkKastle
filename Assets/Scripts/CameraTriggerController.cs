using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerController : MonoBehaviour {

	public float angleOffset;
	public bool active = true;

	void OnTriggerEnter(Collider other) {
		if (active && other.gameObject.transform.parent.tag == "Player") {
			CameraController.InitAngleChange (angleOffset);
			active = false;
		}
	}
}
