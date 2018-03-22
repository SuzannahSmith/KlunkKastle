using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerController : MonoBehaviour {

	public float angleOffset;

	void OnTriggerEnter(Collider other) {
		CameraController[] camControllers = other.gameObject.transform.parent.GetComponentsInChildren<CameraController>();
		camControllers[0].ChangeCameraAngle(angleOffset);
	}
}
