using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlorbieController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		tag = collision.gameObject.tag;
		if (tag == "Enemy" || tag == "Obstacle"){
			GameController.handleFatalCollision(gameObject.transform.parent.gameObject);
		}
	}
}
