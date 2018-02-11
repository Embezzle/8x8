using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour {

	public void SwitchOn()
	{
		gameObject.SetActive (false);
	}

	public void SwitchOff()
	{
		gameObject.SetActive (true);
	}
}
