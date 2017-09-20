using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;
	public AudioClip leftFootSound;
	public AudioClip rightFootSound;
	public AudioClip thudSound;
	public AudioClip rocketSound;
	public int startArrowCount = 3;
	public int currentArrowCount;
	public int kills = 0;
	public int deaths = 0;
	public float feetSoundVolume = 0.1f;
	public float rocketSoundVolume = 0.05f;
	public float thudSoundVolume = 0.1f;
	
	
	private Animator animator;
	private PlayerController controller;
	
	void Start(){
		controller = GetComponent<PlayerController> ();	//Getting references to components we need
		animator = GetComponent<Animator> ();
		currentArrowCount = startArrowCount;	//We set the current arrow count to the start arrow count at the start of the game
	}
	
	void PlayLeftFootSound(){	//We play these sounds when the player is walking
		if (leftFootSound)
			AudioSource.PlayClipAtPoint (leftFootSound, transform.position, feetSoundVolume);
	}
	
	void PlayRightFootSound(){
		if (rightFootSound)
			AudioSource.PlayClipAtPoint (rightFootSound, transform.position, feetSoundVolume);
	}
	
	void PlayRocketSound(){		//We play these sounds when the player is moving up
		if (!rocketSound || GameObject.Find ("RocketSound"))
			return;
		
		GameObject go = new GameObject ("RocketSound");		//We make a new gameobject and add the rocket sound to it and play it
		AudioSource aSrc = go.AddComponent<AudioSource> ();
		aSrc.clip = rocketSound;
		aSrc.volume = rocketSoundVolume;
		aSrc.Play ();
		
		Destroy (go, rocketSound.length);	//We destroy the gameobject removing the sound after the time 
		
	}
	
	void OnCollisionEnter2D(Collision2D target){	//This is called when the player collides with another collider.In this case, the ground
		if (!standing) {	//We check to see if the player isn't standing 
			var absVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);	//We get the x and y velocity of the player
			var absVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);
			
			if(absVelX <= .1f || absVelY <= .1f){	//If the players velocity is 0 or near 0 we play the thud sound 
				if(thudSound)
					AudioSource.PlayClipAtPoint(thudSound, transform.position, thudSoundVolume);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;
		
		var absVelX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		var absVelY = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.y);
		
		if (absVelY < .2f) {	// if the players absolute y velocity is below 0.2 we say the player is standing, otherwise we say he is not.
			standing = true;
		} else {
			standing = false;
		}

		if (controller.moving.x != 0) {		// controller is the reference to the playerController script and if the dpad is pressed moving.x will equal 1 or -1
			if (absVelX < maxVelocity.x) {	// if the player's velocity is less than the max velocity we declared we change the  force.
				
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);	// we change the force which depends on the speed variable and if the player isn't standing we reduce the force depending on the air speed multiplier
				
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);		// We adjust the local scale of the player so that it flips when you change direction
			}
			animator.SetInteger ("AnimState", 1);		//We let the animator know to play the walking animation
		} else {
			animator.SetInteger ("AnimState", 0);		//When the dpad isn't pressed we tell the animator the state is 0 or idle
		}
		
		if (controller.moving.y > 0) {		//Here we make the player move up if up on the dpad is pressed, checking again for max velocity and playing the right sounds and displaying the right animations
			PlayRocketSound();
			if (absVelY < maxVelocity.y)
				forceY = jetSpeed * controller.moving.y;
			
			animator.SetInteger ("AnimState", 2);
		} else if (absVelY > 0) {
			animator.SetInteger("AnimState", 3);
		}
		
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX, forceY));	//We add the force that was decided based on the code above
		
		Debug.Log(currentArrowCount);
	}
}