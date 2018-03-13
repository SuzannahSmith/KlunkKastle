using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public enum GameState {PLAY, LOSING, LOST};
	public int currentLevel = 0;

	public static GameState gameState = GameState.PLAY;
	public Text loseText;

	private string[] levelNames = {"Level1", "Level2", "Level3", "Level4"};

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (gameState == GameController.GameState.LOSING){
			loseGame();
		}

		if (Input.GetKeyUp(KeyCode.R)){
			restartGame();
		}
	}

	public static void handleFatalCollision(GameObject glorbie){
		//Detach main camera from Glorbie so that it isn't disabled when player dies.
		GameObject mainCamera = GameObject.FindWithTag("MainCamera");
		mainCamera.transform.parent = null;

		glorbie.SetActive(false);

		gameState = GameController.GameState.LOSING;
	}

	void loseGame(){
		loseText.text = "You lose! Press 'R' to restart!";
		gameState = GameController.GameState.LOST;
	}

	void restartGame(){
		gameState = GameController.GameState.PLAY;
		SceneManager.LoadScene(levelNames[currentLevel]);
		loseText.enabled = false;
	}

}
