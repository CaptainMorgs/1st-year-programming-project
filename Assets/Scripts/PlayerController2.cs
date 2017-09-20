using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	public Vector2 moving = new Vector2();
	
	// Use this for initialization
	void Start () {
		
	}
	
	// The same as the playercontroller script but for player 2, checking for different inputs for 2nd controller
	void Update () {
		
		moving.x = moving.y = 0;
		
		if (Input.GetKey ("right") || Input.GetAxis("PS4 Dpad Horizontal2") == 1) {
			moving.x = 1;
		} else if (Input.GetKey ("left") || Input.GetAxis("PS4 Dpad Horizontal2") == -1) {
			moving.x = -1;
		}
		
		if (Input.GetKey ("up") || Input.GetAxis("PS4 Dpad Vertical2")== 1) {
			moving.y = 1;
		} else if (Input.GetKey ("down") || Input.GetAxis("PS4 Dpad Vertical2")== -1) {
			moving.y = -1;
		}
		
	}
}
