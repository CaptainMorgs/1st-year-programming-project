using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float roundTime = 90;
	public Canvas canvas;
	public Text text;
	private GameObject player;
	private GameObject player2;
	private Player playerScript;
	private Player2 playerScript2;
	public int player1Kills = 0;
	public int player2Kills = 0;
	private bool isPaused = false;
	public Text text2;
	private Highscore highscoreScript;
	bool isOver;




	// We get references and change the isOver bool to false and set the timer text ui 
	void Start () {
		isOver = false;
		highscoreScript = gameObject.GetComponent<Highscore>();
		text.text = roundTime.ToString();
		text2.enabled = false;
	}

	void FindPlayers()	//We made getting the players references into a function for ease of use
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<Player>();
		player2 = GameObject.FindGameObjectWithTag("Player2");
		playerScript2 = player.GetComponent<Player2>();
	}

	void Timer()	//We subtract time.delta time (the amount of time passed since game start) from the round time and display it as an int
	{
		roundTime -= Time.deltaTime;	
		int roundTimeInt = (int)roundTime;
		text.text = roundTimeInt.ToString();
	}
	
	// We check to see if the options button has been pressed and if so we pause the game
	void Update () {
		if(Input.GetButtonDown("PS4 Options"))
		{
			if(isPaused)
			{
				UnPauseGame();
			}
			else
			{
				PauseGame();
			}
		}
		if(roundTime > 0)
		{
			Timer();

		}
		else
		{
			GameOver();		//We call this method when roundTime is less than 0
		}




	}

	void GameOver()	//we enable the gameover text and display the highscore
	{
		isOver = true;
		FindPlayers();
		Debug.Log("Game over called");
		canvas.enabled = true;
		text.text = "Game Over Press Any Button To Restart " +
			"Player 1 Kills: " + player1Kills + " Player 2 Kills: " + player2Kills;
		highscoreScript.DisplayHighscore();

		if(Input.anyKeyDown)	//we reload the level if any key is pressed
		{
			Application.LoadLevel(1);
		}
	}

	void PauseGame()	//we make sure the game isn't over and then set the timescale to 0 to pause the game and display the pause text
	{
		if(isOver == false){
			text2.enabled = true;
			Time.timeScale = 0;
			isPaused = true;
		}
			

	}

	void UnPauseGame()	//we revert the timescale to 1 and disable the pause text
	{
		if(isOver == false){
			text2.enabled = false;
			Time.timeScale = 1;
			isPaused = false;
		}
	}
}
