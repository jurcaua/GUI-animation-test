using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Animator))]
public class PauseManager : MonoBehaviour {

	public float waitTime = 2f;   // how long to wait after the animation to go back to the play sprite
	public Text promptText;      // reference to the prompt text

	private Animator anim;            // to talk to the animator
	private float timeToWaitFor;     // used for timing
	private bool isPlaying = false; // keeps track of whether the animation is playing or not

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); // get the animator component

		promptText.text = "Press Play to See an Animation!"; // starting text to prompt user
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaying) { // if the animation is playing...
			if (Mathf.Abs (Time.time - timeToWaitFor) < 0.1) {  // check if the animation needs to end...
				anim.SetTrigger ("DoneWait");  // back to main animation state

				isPlaying = false; // no longer playing

				promptText.text = "Press Play Again to See the Animation!";  // prompt user to press again
			}
		}
	}

	// this gets called when the play button gets clicked
	public void Pressed(){
		if (!isPlaying) {  // if not current playing...
			anim.SetTrigger ("Pressed");  // go to main animation

			isPlaying = true;  // animation is playing now

			timeToWaitFor = Time.time + waitTime;  // set the time to end the animation

			promptText.text = "The animation is playing now...";  // prompt the user so they dont click again
		}
	}
}
