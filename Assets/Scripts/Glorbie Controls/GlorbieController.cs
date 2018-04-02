using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlorbieController : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		tag = collision.gameObject.tag;
		if (tag == "Enemy" || tag == "Obstacle"){
			if (SceneManager.GetActiveScene().name == "Tutorial")
				TutorialController.handleFatalCollision(gameObject.transform.parent.gameObject);
			else
				GameController.handleFatalCollision(gameObject.transform.parent.gameObject);
		}
		else if (tag == "EndGoal") {
			if (SceneManager.GetActiveScene().name == "Tutorial"){
				TutorialController.handleLevelWin();
			}
			else{
				GameController.handleLevelWin();
			}
		}
	}
}
