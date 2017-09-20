using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartGame();	//When this script is enabled it will start the game
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartGame()
	{
		Application.LoadLevel(1);	//We load level 1 of the game which is assigned in the project build settings
	}
}
