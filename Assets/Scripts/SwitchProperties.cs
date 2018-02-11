using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchProperties : MonoBehaviour {

	public GameObject[] partner;
	public bool permanentSwitch = false;
	bool pushed = false;

	void Start()
	{
		TileProperties tileProp = this.gameObject.GetComponent<TileProperties>();
		tileProp.isSolid = false;
		tileProp.isMovable = false;
	}

	public void Press()
	{
		if (!pushed)
			AkSoundEngine.PostEvent ("switchDown", gameObject);
		pushed = true;
		foreach (GameObject target in partner)
			target.gameObject.GetComponent<Switchable> ().SwitchOn ();

		if (GetComponent<TileProperties> ().flashing && permanentSwitch)
			GetComponent<TileProperties> ().flashing = false;
		//partner.gameObject.SetActive (false);
	}

	public void Release()
	{
		if (!permanentSwitch) 
		{
			AkSoundEngine.PostEvent ("switchUp", gameObject);
			pushed = false;
			foreach (GameObject target in partner)
				target.gameObject.GetComponent<Switchable> ().SwitchOff ();
			//partner.gameObject.SetActive (true);
		}
	}
}
