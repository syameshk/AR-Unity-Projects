using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBEvents : MonoBehaviour, IVirtualButtonEventHandler{

	public System.Action OnButtonPressedEvent;
	public System.Action OnButtonReleasedEvent;

	// Use this for initialization
	void Start () {
		GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		Debug.Log ("OnButtonPressed");
		if(OnButtonPressedEvent!= null)
			OnButtonPressedEvent ();
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		Debug.Log ("OnButtonReleased");
		if(OnButtonReleasedEvent != null)
			OnButtonReleasedEvent ();
	}	
}
