using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{

	public BodyPart bodyPart;
	public int totalParts;
	private GameObject player;
	private Player playerScript;
	public Canvas canvas;
	public GameObject spawnLocation;
	private GameObject gameController;
	private GameController gameControllerScript;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");	//Getting the references we need
		playerScript = player.GetComponent<Player> ();
		gameController = GameObject.Find ("GameController");
		gameControllerScript = gameController.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D target)	//This method is called when the object this script is attached collides with another collider
	{	
		if (target.gameObject.tag == "Deadly") {	//We check to see if the arrow is tagged as deadly and if so we destroy the player, we do this so the arrows kill 
													//the players when they are in the air, but they can be picked up after shooting them
			if (gameObject.tag == "Player") {
				gameControllerScript.player2Kills++;	//incrementing the players kill count
			} else {
				gameControllerScript.player1Kills++;
			}
			OnExplode ();		//call the onExplode method 
		}
	}

	public void OnExplode ()	//This method is responsible for the player death "animation", its not really an animation though
	{
		SpawnPlayer ();		//We spawn a new player
		Destroy (gameObject);	//We delete the killed player from the scene

		var t = transform;

		for (int i = 0; i < totalParts; i++) {	//We loop through for every body part we want to use and spawn them and apply a random force to them, creating a nice effect
			BodyPart clone = Instantiate (bodyPart, t.position, Quaternion.identity) as BodyPart;
			clone.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * (Random.Range (-50, 50)));
			clone.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * Random.Range (100, 400));
		}
	}

	void SpawnPlayer ()	//We spawn the player at the empty gameobject spawnLocation's tranform
	{
		Instantiate (gameObject, spawnLocation.transform.position, Quaternion.identity);
	}







}
