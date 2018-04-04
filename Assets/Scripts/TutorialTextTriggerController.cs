using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextTriggerController : MonoBehaviour {

	public int id;

	void OnTriggerEnter(Collider other){
		TutorialController.setTutorialText(id);
	}
}
