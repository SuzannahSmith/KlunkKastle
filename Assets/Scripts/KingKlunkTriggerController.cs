using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingKlunkTriggerController : MonoBehaviour {

	public Light directionalLight;
	public KingKlunkController kingKlunk;

	public bool enablesKing;
	public bool triggerActive = true;

	void Start() {
		directionalLight.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag != "Obstacle") {
			if (triggerActive && enablesKing){
				kingKlunk.beginFiring();
				triggerActive = false;
			}
			else if (enablesKing == false){
					kingKlunk.firingEnabled = false;
					directionalLight.enabled = true;
			}
		}
	}
}
