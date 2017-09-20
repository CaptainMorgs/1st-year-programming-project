using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//We check every frame whether the controller is used and what keys are pressed
	//We then store which direction the player should be moved into the moving vector
	//The player scripts then use this info to move the player
		moving.x = moving.y = 0;

		if (Input.GetKey ("right") || Input.GetAxis("PS4 Dpad Horizontal") == 1) {
			moving.x = 1;
		} else if (Input.GetKey ("left") || Input.GetAxis("PS4 Dpad Horizontal") == -1) {
			moving.x = -1;
		}

		if (Input.GetKey ("up") || Input.GetAxis("PS4 Dpad Vertical")== 1) {
			moving.y = 1;
		} else if (Input.GetKey ("down") || Input.GetAxis("PS4 Dpad Vertical")== -1) {
			moving.y = -1;
		}

	}
}
