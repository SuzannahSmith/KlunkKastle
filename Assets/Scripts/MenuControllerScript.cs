using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour {

	public GameObject menuButtons;
	public GameObject selectLevelButtons;

	// Use this for initialization
	void Start () {
		BackToMainMenu();
	}

	// Update is called once per frame
	void Update () {

	}

	public void NewGame() {
		GameController.currentLevel = 0;
		GameController.numLosses = 0;
	 	SceneManager.LoadScene("Story");
	 }

	public void QuitGame() {
		Application.Quit();
	}

	public void ShowSelectLevelMenu() {
		menuButtons.SetActive(false);
		selectLevelButtons.SetActive(true);
	}

	public void SelectLevel(int lvl) {
		GameController.currentLevel = lvl;
		GameController.numLosses = 0;
		GameController.gameState = GameController.GameState.STARTING_LEVEL;
		SceneManager.LoadScene(GameController.levelNames[lvl]);
	}

	public void StartTutorial() {
		SceneManager.LoadScene("Tutorial");
	}

	public void BackToMainMenu() {
		menuButtons.SetActive(true);
		selectLevelButtons.SetActive(false);
	}


}
