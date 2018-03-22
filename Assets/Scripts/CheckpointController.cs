using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		GameController.setCheckpoint(this.transform);
	}
}
