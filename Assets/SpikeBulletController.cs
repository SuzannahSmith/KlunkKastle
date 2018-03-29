using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBulletController : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		Transform parent = collision.gameObject.transform.parent;

		if(parent == null) {
			Destroy(gameObject);
		}
		else if(parent.tag != "Player") {
			Destroy(gameObject);
		}
	}
}
