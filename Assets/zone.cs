using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class zone : MonoBehaviour {

	public AK.Wwise.State zoneState;
	public AK.Wwise.State exitState;

	void OnCollisionEnter(Collision col){
		print ("player entered");
		if (col.gameObject.name == "PlayerCharacter") {
			print ("player entered");
			zoneState.SetValue ();
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.name == "PlayerCharacter") {
			print ("player exited");
			exitState.SetValue ();
		}
	}
}
