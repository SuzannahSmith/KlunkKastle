using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingKlunkTriggerController : MonoBehaviour {

	public KingKlunkController kingKlunk;
	public bool enablesKing;
	public bool triggerActive = true;

	void OnTriggerEnter(Collider other){
		if (triggerActive && enablesKing){
			kingKlunk.beginFiring();
			triggerActive = false;
		}
		else if (enablesKing == false){
				kingKlunk.firingEnabled = false;
		}
	}
}
