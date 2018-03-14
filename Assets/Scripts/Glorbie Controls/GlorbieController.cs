using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlorbieController : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		tag = collision.gameObject.tag;
		if (tag == "Enemy" || tag == "Obstacle"){
			GameController.handleFatalCollision(gameObject.transform.parent.gameObject);
		}
		else if (tag == "EndGoal") {
			GameController.handleLevelWin();
		}
	}
}
