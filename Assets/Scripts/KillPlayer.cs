using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	void OnCollisionEnter(Collision c) {
		Transform glorbie = c.transform.parent;

		if(glorbie != null && glorbie.tag == "Player") {
			Transform restOfGlorbie = null;
			Transform[] children = glorbie.GetComponentsInChildren<Transform>();

			foreach (Transform child in children) {
				if(child.tag == "MainCamera") {
					// child.GetComponent<CameraController>().enabled = false;
				}
				else if (child.name == "GlorbieBody"){
					 child.GetComponent<GlorbieMovementController>().enabled = false;
				}
				else if(child.tag == "Light") {
					child.gameObject.SetActive(false);
				}
				else if(child.tag != "Player") {
					child.gameObject.AddComponent<BoxCollider>();
			    child.gameObject.AddComponent<Rigidbody>();

					if(child.name == "RestOfGlorbie") {
						child.GetComponent<FollowObject>().enabled = false;
						child.GetComponent<HeadPositionController>().enabled = false;
						restOfGlorbie = child;
					}
				}
			}
			if(restOfGlorbie != null) {
					restOfGlorbie.DetachChildren();
			}
			glorbie.DetachChildren();
		}
	}

}
