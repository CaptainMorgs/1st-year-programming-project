using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {


	private GameObject player;
	private SpriteRenderer spriteRenderer;
	public Vector3 offSet = new Vector3(1,1,0);
	public GameObject arrow;
	public ArrowBehavior arrowBehaviourScript;
	public Vector3 arrowDirection;
	public float arrowSpeed = 5f;
	Vector3 analog;
	public float arrowDeadlyDelay = 0.1f;
	public Vector2 arrowVelocityDeadlyThreshold = new Vector2(1.0f,1.0f);
	public Player playerScript;
	public GameObject centerOfGravityPosition;

	// We get the references we need
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<Player>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	public void FindPlayer()	//We made getting the player refences into a function for ease of use as they are spawning a lot
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		//We store the analog sticks position into a vector
		Vector3 analog = new Vector3(Input.GetAxis("PS4 RightAnologue Horizontal"),Input.GetAxis ("PS4 RightAnologue Vertical"),0);
		if (analog.magnitude > 0) 	// if the stick is moved we enable the pointer sprite and set its rotation to that of the analog sticks
			{
			if (player != null)
			{
				//	RotatePointer();
				spriteRenderer.enabled = true;
				transform.rotation = Quaternion.LookRotation(Vector3.forward, analog);
				offSet = -1*(analog);
				transform.position = player.transform.position - offSet;
			}
			else
			{
				Debug.Log("player = null");
				FindPlayer();
			}
			}
		else
			{
				spriteRenderer.enabled = false;
			}

		if(Input.GetButtonDown("PS4 X"))	//We call the shoot arrow method if the x button is pressed
		{
			shootArrow();
			
		}
	}

	void shootArrow()	// we check to see if the pointer sprite is enabled and if the player has any arrows
						// We get the analog position at the press and spawn an arrow with the position and rotation of the pointer and add force to it
						// We also reduce the players arrow count
	{
			if(spriteRenderer.enabled == true && playerScript.currentArrowCount > 0)
			{
				Vector3 analogAtPress =  new Vector3(Input.GetAxis("PS4 RightAnologue Horizontal"),Input.GetAxis ("PS4 RightAnologue Vertical"),0);
				Debug.Log ("x is pressed");
				GameObject arrowInstance = (GameObject)Instantiate(arrow,transform.position,transform.rotation);
				Rigidbody2D rb = arrowInstance.GetComponent<Rigidbody2D>();
				rb.AddForce(analogAtPress * arrowSpeed);
				playerScript.currentArrowCount--;
				
					
					
			}

	}


}
