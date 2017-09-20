using UnityEngine;
using System.Collections;

public class Joystick2 : MonoBehaviour {
	//The same as the joystick script but for player 2
	private GameObject player;
	private SpriteRenderer spriteRenderer;
	public Vector3 offSet = new Vector3(1,1,0);
	public GameObject arrow;
	public ArrowBehavior arrowBehaviourScript;
	public Vector3 arrowDirection;
	public float arrowSpeed = 5f;
	Vector3 analog;
	public float arrowDeadlyDelay = 1.0f;
	public Vector2 arrowVelocityDeadlyThreshold = new Vector2(1.0f,1.0f);
	public Player2 playerScript;
	
	// Use this for initialization
	void Start () {
		FindPlayer();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	public void FindPlayer()
	{
		player = GameObject.FindGameObjectWithTag("Player2");
		playerScript = player.GetComponent<Player2>();
	}

	// Update is called once per frame
	void Update () {
		
		Vector3 analog = new Vector3(Input.GetAxis("PS4 RightAnologue Horizontal2"),Input.GetAxis ("PS4 RightAnologue Vertical2"),0);
		if (analog.magnitude > 0) 
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
		
		if(Input.GetButtonDown("PS4 X2"))
		{
			shootArrow();
			
		}
	}
	
	void shootArrow()
	{
		if(spriteRenderer.enabled == true && playerScript.currentArrowCount > 0)
		{
			Vector3 analogAtPress =  new Vector3(Input.GetAxis("PS4 RightAnologue Horizontal2"),Input.GetAxis ("PS4 RightAnologue Vertical2"),0);
			Debug.Log ("x is pressed");
			GameObject arrowInstance = (GameObject)Instantiate(arrow,transform.position,transform.rotation);
			Rigidbody2D rb = arrowInstance.GetComponent<Rigidbody2D>();
			rb.AddForce(analogAtPress * arrowSpeed);
			playerScript.currentArrowCount--;
		}
		
	}

}
