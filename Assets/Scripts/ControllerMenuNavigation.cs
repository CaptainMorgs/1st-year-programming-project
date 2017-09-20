using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerMenuNavigation : MonoBehaviour {

	public Button playGameButton;
	public Button quitGameButton;
	bool playGameHighlighted = true;
	EventSystem eventSystem;

	// This script isn't used in the game currently but we dont wan't to delete it as we will keep working on this game
	void Start () {
		eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		eventSystem.SetSelectedGameObject(playGameButton.gameObject, new BaseEventData(eventSystem));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetAxis("PS4 Dpad Vertical") == 1 || Input.GetAxis("PS4 Dpad Vertical") == -1)
		{
			if(playGameHighlighted == true)
			{
			//	eventSystem.SetSelectedGameObject(quitGameButton.gameObject, new BaseEventData(eventSystem));
				eventSystem.SetSelectedGameObject(quitGameButton.gameObject);
				playGameHighlighted = false;
			}
			else 
			{
				//	eventSystem.SetSelectedGameObject(playGameButton.gameObject, new BaseEventData(eventSystem));
				eventSystem.SetSelectedGameObject(playGameButton.gameObject);
				playGameHighlighted = true;
			}

		}

			
		}
	}

