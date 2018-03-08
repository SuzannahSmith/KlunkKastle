using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

	public List<KlunkController> klunkList;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		foreach (KlunkController klunk in klunkList){
			klunk.setAgentEnabled(true);
		}
	}
}
