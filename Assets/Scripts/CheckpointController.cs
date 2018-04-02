using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointController : MonoBehaviour {

	public bool active = true;

	void OnTriggerEnter(Collider other){
		if (active){
			if (SceneManager.GetActiveScene().name == "Tutorial")
				TutorialController.setCheckpoint(this.transform);
			else{
				GameController.setCheckpoint(this.transform);
			}
			active = false;
		}
	}
}
