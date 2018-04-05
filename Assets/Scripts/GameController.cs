using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public enum GameState {PLAY, LOSING, LOST, WINNING, WON_GAME, STARTING_LEVEL};
	public static int currentLevel = 0;
	public static int numLosses = 0;
	public static string[] levelNames = {"Level1", "Level2", "Level3", "Level4"};
	public static string[] introText = {
		"You are now on the fourth and highest floor of Klunk Kastle. In order to escape, you must avoid obstacles and evil Klunks while searching for the bottom floor. Good luck!",
		"Good job! You have made it through Floor Four… But what new horrors await on Floor Three?",
		"You are getting closer to the exit… And closer to your doom. Think of your family and your home, and it might be enough get you through Floor Two.",
		"So close, yet so far… You have reached the bottom floor, but there is one last obstacle standing in your way. The King of the Klunks! And he is not going to let you escape that easily."
	};

	public static GameState gameState = GameState.STARTING_LEVEL;
	public Text lvlText;
	public Text numLossesText;
	public static Text checkPointText;
	public GameObject storyPanel;

	public GameObject pauseMenuCanvas;
	public GameObject loseGameMenuCanvas;
	private GameObject winGameCanvas;

	public static Transform checkPoint;
	public string startingPointName = "StartingPoint";
	public Transform glorbiePosition;

	private static float checkPointTimestamp;

	void Awake(){
		DontDestroyOnLoad(GameObject.Find(startingPointName));
	}

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 4; i++) {
			if (levelNames[i] == SceneManager.GetActiveScene().name) {
				currentLevel = i;
			}
		}

		lvlText.text = "Floor: " + (4-currentLevel);
		updateNumLossesText();

		checkPointText = GameObject.Find("CheckpointText").GetComponent<Text>();
		if(checkPoint == null) {
			checkPoint = GameObject.Find(startingPointName).transform;
		}
		glorbiePosition.position = new Vector3(checkPoint.position.x, checkPoint.position.y, checkPoint.position.z);
		// glorbiePosition.eulerAngles = new Vector3(checkPoint.eulerAngles.x, checkPoint.eulerAngles.y, checkPoint.eulerAngles.z);

		winGameCanvas = GameObject.Find("WinGameCanvas");
		if(winGameCanvas != null) {
			winGameCanvas.GetComponent<Canvas>().enabled = false;
		}

		if(gameState == GameState.STARTING_LEVEL) {
			Time.timeScale = 0f;
			ToggleIntroText(true);
		}
		else {
			ToggleIntroText(false);
		}
	}

	// Update is called once per frame
	void Update () {

		if (gameState == GameState.LOSING){
			loseGame();
		}
		else if(gameState == GameState.WINNING) {
			winLevel();
		}
		else if(gameState == GameState.WON_GAME) {
			winGame();
		}
		else if (gameState == GameState.STARTING_LEVEL && Input.GetKeyUp(KeyCode.Return)) {
			gameState = GameState.PLAY;
			Time.timeScale = 1.0f;
			ToggleIntroText(false);
		}

		if(Input.GetKeyUp(KeyCode.Escape)) {
			TogglePauseGame();
		}


		if (checkPointText.text == "Checkpoint!"){
			if (Time.time - checkPointTimestamp > 3.0f){
				checkPointText.text = "";
			}
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
		Destroy (GameObject.Find(startingPointName));
		gameState = GameState.STARTING_LEVEL;
		SceneManager.LoadScene(levelNames[currentLevel]);
	}

	void winGame() {
		//set winning text visible
		//Show button to go to main menu
		Time.timeScale = 0f;
		winGameCanvas.GetComponent<Canvas>().enabled = true;
	}

	void loseGame(){
		numLosses++;
		updateNumLossesText();
		loseGameMenuCanvas.SetActive(true);
		gameState = GameState.LOST;
	}

	public void restartGame(){
		Time.timeScale = 1.0f;
		if (gameState == GameState.PLAY)
			numLosses++;
		gameState = GameState.PLAY;
		updateNumLossesText();
		SceneManager.LoadScene(levelNames[currentLevel]);
	}

	void updateNumLossesText() {
		numLossesText.text = "Losses: " + numLosses;
	}

	public static void setCheckpoint(Transform newCP) {
		checkPoint.position = new Vector3(newCP.position.x, newCP.position.y, newCP.position.z);
		checkPointText.text = "Checkpoint!";
		checkPointTimestamp = Time.time;
		// checkPoint.eulerAngles = new Vector3(newCP.eulerAngles.x, newCP.eulerAngles.y, newCP.eulerAngles.z);
	}

	public void TogglePauseGame() {
		if(pauseMenuCanvas.activeInHierarchy) {
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1.0f;
		}
		else {
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	public void LoadMainMenu() {
		Time.timeScale = 1.0f;
		Destroy (GameObject.Find(startingPointName));
		SceneManager.LoadScene("MainMenu");
		gameState = GameState.PLAY;
	}

	public void QuitGame() {
		Application.Quit();
	}

	void ToggleIntroText(bool toggle) {
		storyPanel.SetActive(toggle);
		if(toggle) {
			storyPanel.GetComponentInChildren<Text>().text = introText[currentLevel];
		}
	}
}
