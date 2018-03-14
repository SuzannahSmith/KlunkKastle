using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public enum GameState {PLAY, LOSING, LOST, WINNING};
	public static int currentLevel = 0;
	public static int numLosses = 0;

	public static GameState gameState = GameState.PLAY;
	public Text loseText;
	public Text lvlText;
	public Text numLossesText;

	private string[] levelNames = {"Level1", "Level2", "Level3", "Level4"};

	// Use this for initialization
	void Start () {
		lvlText.text = "Level: " + (currentLevel + 1);
		updateNumLossesText();
	}

	// Update is called once per frame
	void Update () {

		if (gameState == GameState.LOSING){
			loseGame();
		}

		if(gameState == GameState.WINNING) {
			winLevel();
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

		gameState = GameState.LOSING;
	}

	public static void handleLevelWin() {
		gameState = GameState.WINNING;
	}

	void winLevel() {
		currentLevel++;
		gameState = GameState.PLAY;
		SceneManager.LoadScene(levelNames[currentLevel]);
	}

	void loseGame(){
		numLosses++;
		updateNumLossesText();
		loseText.text = "You lose! Press 'R' to restart!";
		gameState = GameState.LOST;
	}

	void restartGame(){
		gameState = GameState.PLAY;
		SceneManager.LoadScene(levelNames[currentLevel]);
		loseText.enabled = false;
	}

	void updateNumLossesText() {
		numLossesText.text = "# losses: " + numLosses;
	}

}
