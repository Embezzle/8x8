using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class PlayerCharacter : MonoBehaviour {

	public bool isControlable = true;
	public AK.Wwise.Event fsEvent;

	public void Move(Vector3 direction)
	{
		if (CheckIfCanMove (direction)) 
		{
			this.transform.Translate (direction);

			//check if we've stepped off anything
			RaycastHit hit = new RaycastHit ();
			Vector3 raycastPos = this.transform.position - direction;
			raycastPos += new Vector3 (0.5f, 0.5f, -0.5f);

			if (Physics.Raycast (raycastPos, Vector3.forward, out hit)) {
				TileProperties hitTile = hit.transform.gameObject.GetComponent<TileProperties> ();
				if (hitTile == null) {
					fsEvent.Post (gameObject);
					return;
				}
				//switch material
				fsEvent.Post (gameObject);
				print (hitTile.name);
				hitTile.SteppedOff ();
			} else {
				fsEvent.Post (gameObject);
			}


			if (transform.position.y > 11) {
				AkSoundEngine.SetState ("Zone", "Cave");
			} else if (transform.position.y < -2) {
				AkSoundEngine.SetState ("Zone", "Grass");
			} else if (transform.position.x > 8) {
				AkSoundEngine.SetState ("Zone", "Factory");
			} else {
				AkSoundEngine.SetState ("Zone", "Temple");
			}
		}
	}

	public bool CheckIfCanMove (Vector3 direction)
	{
		AkSoundEngine.SetSwitch ("fs_material", "Stone", gameObject);
		RaycastHit hit = new RaycastHit ();
		Vector3 raycastPos = this.transform.position + direction;
		raycastPos += new Vector3 (0.5f, 0.5f, -0.5f);

		if (Physics.Raycast (raycastPos, Vector3.forward, out hit)) {
			TileProperties hitTile = hit.transform.gameObject.GetComponent<TileProperties>();
			if (hitTile == null) 
			{
				AkSoundEngine.SetSwitch ("fs_material", "Stone", gameObject);
				return true;
			}

			if (hitTile.isMovable) 
			{
				if (hitTile.CheckIfCanMove (direction))
				{
					AkSoundEngine.SetSwitch ("fs_material", "Empty", gameObject);
					hitTile.Move (direction);
					return true;
				} 
				else
				{
					return false;
				}
			}
			if (hitTile.isSolid) //but not movable
			{
				return false;
			}

			hitTile.SteppedOn ();
			print (hitTile.name);

			if (hitTile.name == "Switch") 
			{
				AkSoundEngine.SetSwitch ("fs_material", "Empty", gameObject);
				return true;
			}

			AkSoundEngine.SetSwitch ("fs_material", hitTile.name, gameObject);
		}


		return true;
	}

	public void MakeUncontrolable()
	{
		isControlable = false;
		OSCHandler.Instance.SendMessageToClient ("MaxMSP", "/LP/StopCC", 0);
	}

	public void MakeControlable()
	{
		isControlable = true;
		OSCHandler.Instance.SendMessageToClient ("MaxMSP", "/LP/StartCC", 0);
	}
}
