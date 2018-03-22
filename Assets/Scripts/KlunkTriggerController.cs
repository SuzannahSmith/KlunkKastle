using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlunkTriggerController : MonoBehaviour {

	public List<KlunkController> klunkList;
	public bool enableKlunks;

	void OnTriggerEnter(Collider other){
		foreach (KlunkController klunk in klunkList){
			klunk.setAgentEnabled(enableKlunks);
		}
	}
}
