using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class LeopardAnimation : MonoBehaviour, ITrackableEventHandler {


	public TrackableBehaviour imageTarget;
	public VBEvents vButton;

	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator> ();

		if (vButton == null) {
			vButton = GameObject.FindObjectOfType<VBEvents> ();
		}

		if (vButton == null) {
			Debug.LogWarning ("Virtual Button not found!");
		}
			
		if (imageTarget) {
			imageTarget.RegisterTrackableEventHandler (this);
		} else {
			Debug.LogWarning ("Image target is not initialized");
		}

	}


	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus){
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			//Tracking found
			//Start animation

			Debug.Log ("Play entry anim");
			PlayEntryAnimation ();
		}
		else
		{
			//Tracking lost reset everything
			Debug.Log ("Stop everything");
		}
	}

	// Use this for initialization
	void OnEnable () {
		vButton.OnButtonPressedEvent += ButtonPressed;
	}

	void OnDisable () {
		vButton.OnButtonPressedEvent -= ButtonPressed;
	}

	void ButtonPressed ()
	{
		//Play animation
		Debug.Log("Replay animation here");

		PlayEntryAnimation ();
	}

	private void PlayEntryAnimation(){
		animator.Play ("Entry",-1,0);
	}

}
