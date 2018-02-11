using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperties : MonoBehaviour {

	public bool isSolid = true;
	public bool isMovable = false;
	public bool isBox = false;
	public bool isMultiBox = false;
	public bool isPipe = false;
	public bool flashing = false;
	public int flashColour;
	bool isUnderfoot = false;



	public bool GetMovedInto(Vector3 direction)
	{
		if (!isSolid) {
			SteppedOn ();
			return true;
			}

		if (isMovable) 
		{
			if (CheckIfCanMove(direction)) 
			{
				Move (direction);
				return true;
			}
		}

		return false;
	}

	public void Move(Vector3 direction)
	{
		if (isPipe) 
		{
			GetComponent<Pipe> ().Move (direction);
			return;
		}

		if (isMultiBox) 
		{
			GetComponent<Pipe> ().Move (direction);
			return;
		}

		if (CheckIfCanMove (direction)) 
		{
			AkSoundEngine.PostEvent ("StonePush", gameObject);
			this.transform.Translate (direction);
		}
	}

	public bool CheckIfCanMove (Vector3 direction)
	{
		if (isPipe) 
		{
			return GetComponent<Pipe> ().CheckIfCanMove (direction);
		}

		if (isMultiBox) 
		{
			return GetComponent<Pipe> ().CheckIfCanMove (direction);
		}

		RaycastHit hit = new RaycastHit ();
		Vector3 raycastPos = this.transform.position + direction;
		raycastPos += new Vector3 (0.5f, 0.5f, -0.5f);

		if (Physics.Raycast (raycastPos, Vector3.forward, out hit)) {
			TileProperties hitTile = hit.transform.gameObject.GetComponent<TileProperties>();
			if (hitTile == null) 
			{
				return true;
			}

			if (isBox) 
			{
				if (hitTile.gameObject.name == "underfootWater")

					return false;
			}

			if (hitTile.isMovable) 
			{

				if (hitTile.CheckIfCanMove (direction))
				{
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

			if (!isMultiBox)
				hitTile.SteppedOn ();
		}


		return true;
	}

	public void SteppedOn()
	{
		//print ("stepped on");
		isUnderfoot = true;
		SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer> ();
		renderer.enabled = false;

		SwitchProperties switchTile = this.gameObject.GetComponent<SwitchProperties> ();
		if (switchTile != null) 
		{
			switchTile.Press ();
		}
	}

	public void SteppedOff()
	{
		//print ("stepped off");
		isUnderfoot = false;
		SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer> ();
		renderer.enabled = true;

		SwitchProperties switchTile = this.gameObject.GetComponent<SwitchProperties> ();
		if (switchTile != null) 
		{
			switchTile.Release ();
		}
	}
}
