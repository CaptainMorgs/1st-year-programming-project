using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private Color start;
	private Color end;
	private float t = 0.0f;

	//We set the start and end colour we need for the unity linear interpolation method
	void Start () {	
		spriteRenderer = GetComponent<SpriteRenderer> ();	
		start = spriteRenderer.color;
		end = new Color (start.r, start.g, start.b, 0.0f);
	}
	
	//We store the amount of time passed in the float t and then use the built in unity lerp method to fade the bodyparts gradually
	void Update () {
		t += Time.deltaTime;
		GetComponent<Renderer>().material.color = Color.Lerp (start, end, t / 2);
		if (GetComponent<Renderer>().material.color.a <= 0.0)
			Destroy (gameObject);	//We destroy the bodypart after its been faded 
	}
}
