using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QuitGame();	//when this script is enabled it will quit the game
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void QuitGame()	//We quit the application
	{
		Application.Quit();
	}
}
