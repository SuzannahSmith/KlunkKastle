using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

	public enum GameState {PLAY, LOSING, LOST, WINNING};
	public static string[] levelNames = {"Level1", "Level2", "Level3", "Level4"};

	public static GameState gameState = GameState.PLAY;
	public GameObject pauseMenuCanvas;
	public GameObject loseGameMenuCanvas;
	public static Text checkPointText;
	public static Text tutorialText;

	public static Transform checkPoint;
	public string startingPointName = "StartingPoint";
	public Transform glorbiePosition;
	private static float checkPointTimestamp;
	private static string[] tutorialTextTooltips;

	void Awake(){
		DontDestroyOnLoad(GameObject.Find(startingPointName));
	}

	// Use this for initialization
	void Start () {
		if(checkPoint == null) {
			checkPoint = GameObject.Find(startingPointName).transform;
		}
		checkPointText = GameObject.Find("CheckpointText").GetComponent<Text>();
		tutorialText = GameObject.Find("TutorialText").GetComponent<Text>();
		glorbiePosition.position = new Vector3(checkPoint.position.x, checkPoint.position.y, checkPoint.position.z);
		tutorialTextTooltips = new string[]{"Welcome to Klunk Kastle! \nUse the W, A, S, and D keys to move. Press ESC at any time to pause.",
																				"Left click and drag the mouse to rotate the camera.",
																				"Reach the exit at the end of the hall to finish the tutorial, but watch out for the Klunk!"};
	}

	void Update () {

		if (gameState == GameState.LOSING){
			loseGame();
		}

		if(gameState == GameState.WINNING) {
			LoadMainMenu();
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

	void loseGame(){
		loseGameMenuCanvas.SetActive(true);
		gameState = GameState.LOST;
	}

	public void restartGame(){
		Time.timeScale = 1.0f;
		gameState = GameState.PLAY;
		SceneManager.LoadScene("Tutorial");
	}

	public static void setCheckpoint(Transform newCP) {
		checkPoint.position = new Vector3(newCP.position.x, newCP.position.y, newCP.position.z);
		checkPointText.text = "Checkpoint!";
		checkPointTimestamp = Time.time;
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
	}

	public void QuitGame() {
		Application.Quit();
	}

	public static void setTutorialText(int index){
		tutorialText.text = tutorialTextTooltips[index];
	}
}
