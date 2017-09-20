using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {


	public float arrowDepth = 0.5f;
	private Rigidbody2D rb;
	public GameObject arrowChild;
	private GameObject player;
	private GameObject player2;
	private Player playerScript;
	private Player2 playerScript2;
	private BoxCollider2D bc;
	public AudioClip arrowShootSound;
	public AudioClip arrowPickUpSound;
	public AudioClip arrowHitSound;
	public float arrowShootVolume = 1.0f;
	public float arrowHitVolume = 0.1f;
	public float arrowPickUpVolume = 0.1f;


	
	// Use this for initialization
	void Start () {
		bc = gameObject.GetComponent<BoxCollider2D>();	//Getting references to components we need
		rb = gameObject.GetComponent<Rigidbody2D>();
		FindPlayers();									//Getting references to the players and their player scripts in the scene
		AudioSource.PlayClipAtPoint(arrowShootSound, gameObject.transform.position, arrowShootVolume);	//Playing the arrow shoot sound when this object is spawned
	}

	void FindPlayers()
	{
		player = GameObject.FindGameObjectWithTag("Player");	//Getting references to the players in the scene by first getting their gameObject and then the player script attached to the gameobject
		playerScript = player.GetComponent<Player>();
		player2 = GameObject.FindGameObjectWithTag("Player2");
		playerScript2 = player.GetComponent<Player2>();
	}

	void OnCollisionEnter2D(Collision2D coll) {		//This method is called when this gameobject collides with another 2D collider
		if (coll.gameObject.layer == 8)				//We check if the layer collided with is 8 which we have assigned to solids in the scene
		{
			AudioSource.PlayClipAtPoint(arrowHitSound, gameObject.transform.position, arrowHitVolume);	//We play the arrow hit sound 
			rb.isKinematic = true;		// We make the arrow kinematic which frees it of physics acting on its rigidbody, stopping it in place
			gameObject.tag = "Untagged";	//We untag the gameobject, removing the deadly tag, ensuring it does not kill the players when they collide with it
			transform.Translate(arrowDepth * Vector3.forward);	//We move the arrow slightly forward into the gamobject it hit, giving the illusion of penetrating the solid
		}
		if ((coll.gameObject.tag == "Player") && gameObject.tag == "Untagged")	//We check if the colliders tag is player and if this gameobjects tag is untagged
		{
				AudioSource.PlayClipAtPoint(arrowPickUpSound, gameObject.transform.position, arrowPickUpVolume);	//We play the arrow pick up sound 
				playerScript.currentArrowCount++;	//We increment the player's arrow count and remove the arrow from the scene
				Destroy(gameObject);
		}

		if ((coll.gameObject.tag == "Player2") && gameObject.tag == "Untagged")		// Same as the above code but for player 2
		{
				AudioSource.PlayClipAtPoint(arrowPickUpSound, gameObject.transform.position, arrowPickUpVolume);
				Player2 ps = coll.gameObject.GetComponent<Player2>();
				ps.currentArrowCount++;
				Destroy(gameObject);
		}
	}
		
	// Update is called once per frame
	void Update () {
		gameObject.transform.up = rb.velocity;	// We give the arrow a realistic trajectory making the arrow head rotate towards the arrows velocity
	}


}
