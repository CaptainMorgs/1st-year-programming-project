using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

	public int score = 0;
	public int highScore = 0;
	string highScoreKey = "HighScore";
	private GameObject gameController;
	private GameController gameControllerScript;
	public Text text;
	
	void Start(){	//Get our references
		gameController = GameObject.Find("GameController");
		gameControllerScript = gameController.GetComponent<GameController>();



		//Get the highScore from player prefs if it is there, 0 otherwise.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);    
	}
	
	void Update(){
	}
	
	void OnDisable()	//called when the game ends and this script is disabled
	{
		
		//If our score is greter than highscore, set new higscore and save.

			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();

	}
	//We set the score to the player with the most kills 
	public void DisplayHighscore()
	{
		if(gameControllerScript.player1Kills>gameControllerScript.player2Kills)
		{
			score = gameControllerScript.player1Kills;
		}
		else
		{
			score = gameControllerScript.player2Kills;
		}

		if(score>highScore)	//if the score is greater than the highscore, we set that score to the highscore and display it
		{
			highScore = score;
		}
		text.text = "Highscore: " + highScore;
	}
}
