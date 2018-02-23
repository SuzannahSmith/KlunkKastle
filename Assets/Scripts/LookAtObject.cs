using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour {

	public Transform lookAtObject;

	void Update () {
		transform.LookAt(lookAtObject.position);
	}
}
