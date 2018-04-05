using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryTextController : MonoBehaviour {

	private string[] storyTextList;
	private int currentScene;

	public Text storyText;
	public Transform[] cameraPositionList;
	public Transform cameraPosition;

	// Use this for initialization
	void Start () {
		storyTextList = new string[] {
			"Glorbie, a little Glorb child, lives a happy life in Glorbland. He is the heir to the Glorb throne, and his parents King Glorbster and Queen Glorbella love him very much. Everything is perfect….",
			 "Until the day that the Klunks attack.",
			 "The Klunks are jealous of the riches of that the Glorbs have gathered by making gum balls. The Klunks can only make black licorice, which nobody likes. So, they came up with a plan to steal the Glorbs' gum balls: by kidnapping innocent little Glorbie and holding him for ransom!",
			 "In the dead of the night, a group of Klunks snuck into Glorbland and snatched Glorbie out of his bed. They took him back to Klunk Kastle, and hid him away on the highest floor of the Kastle. There he will stay, until the Glorbs pay a ransom for him, of one billion gum balls.",
			 "But still, Glorbie has no intention of waiting for his parents to rescue him. He isn't going to let anyone take his precious gum balls away! He sets out to escape the Kastle himself… Despite the danger.",
			 "Klunk Kastle is a very scary place. Almost everything in it is designed to kill any Glorbs who dare enter it! He will need a lot of help to make it out alive.",
			 "Help Glorbie escape Klunk Kastle!"
		};

		currentScene = 0;
		DisplayNextScene();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Return)) {
			DisplayNextScene();
		}
	}

	void DisplayNextScene() {
		if(currentScene >= storyTextList.Length) {
			SceneManager.LoadScene("Level1");
		}
		else {
			storyText.text = storyTextList[currentScene];
			cameraPosition.position = new Vector3(cameraPositionList[currentScene].position.x, cameraPositionList[currentScene].position.y, cameraPositionList[currentScene].position.z);
			currentScene++;
		}
	}

}
