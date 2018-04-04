using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag != "Obstacle")
			GameController.gameState = GameController.GameState.WON_GAME;
	}
}
