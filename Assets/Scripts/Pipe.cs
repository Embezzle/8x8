using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	public GameObject[] segments;
	private TileProperties tileProp;
	private PlayerCharacter playerChar;
	private CameraArea cameraArea;
	public bool movesLeftRight = false;
	public bool isSegment = false;
	public bool isLongBox;
	public bool longBoxLong;	
	private bool landingInWater = false;

	// Use this for initialization
	void Start () {
		tileProp = gameObject.GetComponent<TileProperties> ();
		playerChar = GameObject.Find ("PlayerCharacter").GetComponent<PlayerCharacter> ();
		cameraArea = GameObject.Find ("CameraArea").GetComponent<CameraArea> ();
		if (transform.parent.name == "pipe")
			isSegment = true;
	}
	
	public void Move(Vector3 direction)
	{
		if (isSegment) 
		{
			transform.parent.GetComponent<Pipe> ().Move (direction);
			//GetComponentInParent<Pipe> ().Move (direction);
			return;
		}

		foreach (Transform child in transform) 
		{
			Pipe childPipe = child.GetComponent<Pipe> ();
			if (!childPipe.CheckIfCanMove (direction))
				return;
		}


		if (isLongBox) {
			AkSoundEngine.PostEvent ("LogPush", gameObject);
			transform.Translate (direction);
			return;
		}
		playerChar.MakeUncontrolable ();
		//cameraArea.WritePositionsInCamera ();

		AkSoundEngine.PostEvent ("PipeRoll", gameObject);
		StartCoroutine ("MovementLoop", direction);
	}

	public bool CheckIfCanMove (Vector3 direction)
	{
			if (movesLeftRight) {
				if (direction.y != 0)
					return false;
			}
			if (!movesLeftRight) {
				if (direction.x != 0)
					return false;
			}

		GameObject parentGO;
		if (isSegment) {
			parentGO = transform.parent.gameObject;
		} 
		else 
		{
			parentGO = this.gameObject;
		}



		foreach (Transform child in parentGO.transform) 
		{
			RaycastHit hit = new RaycastHit ();
			Vector3 raycastPos = child.position + direction;
			raycastPos += new Vector3 (0.5f, 0.5f, -0.5f);



			if (Physics.Raycast (raycastPos, Vector3.forward, out hit)) {
				TileProperties hitTile = hit.transform.gameObject.GetComponent<TileProperties>();
				if (hitTile == null) 
				{
					//return true;
				}

				if (hitTile.name == "WaterTile") 
				{
					print ("hit water");
					DisableWater (direction);
					landingInWater = true;

					foreach (Transform childAgain in parentGO.transform) {
						TileProperties tileProp = childAgain.GetComponent<TileProperties> ();
						tileProp.isPipe = false;
						tileProp.isMovable = false;
						tileProp.isSolid = false;
					}

					TileProperties parentProp = parentGO.GetComponent<TileProperties> ();
					parentProp.isPipe = false;
					parentProp.isMovable = false;
					parentProp.isSolid = false;

					return true;
				}

				if (hitTile.name == "underfootWater") 
				{
					return false;
				}

				if (hitTile.CheckIfCanMove (direction))
				{
					if(isLongBox)
						hitTile.Move (direction);
					//return true;
				} 
				else
				{
					return false;
				}


				if (hitTile.isSolid && !hitTile.isMovable) //but not movable
				{
					return false;
				}

				if (hitTile.isSolid && hitTile.isPipe)
				{
					return false;
				}

				//hitTile.SteppedOn ();
			}



		}
		return true;
	}

	IEnumerator MovementLoop(Vector3 direction)
	{
		//print ("movement loop");
		transform.Translate (direction);
		cameraArea.WritePositionsInCamera ();

		if (landingInWater) {
			print ("disabling pipe collision");
			AkSoundEngine.PostEvent ("PipeRoll_landinWater", gameObject);
			playerChar.MakeControlable ();
			Transform pipeParent;
			if (isSegment) {
				pipeParent = transform.parent;
			} else {
				pipeParent = transform;
			}
				
			foreach (Transform child in pipeParent) {
				TileProperties tileProp = child.GetComponent<TileProperties> ();
				tileProp.isPipe = false;
				tileProp.isMovable = false;
				tileProp.isSolid = false;
			}

			TileProperties parentProp = pipeParent.GetComponent<TileProperties> ();
			parentProp.isPipe = false;
			parentProp.isMovable = false;
			parentProp.isSolid = false;

			yield break;
		}

		yield return new WaitForSeconds (.333f);
		if (CheckIfCanMove (direction)) 
		{
			StartCoroutine("MovementLoop", direction);
		} 
		else 
		{	
			AkSoundEngine.PostEvent ("PipeRoll_Stop", gameObject);
			playerChar.MakeControlable ();
		}
	}

	public void DisableWater(Vector3 direction)
	{
		GameObject parentGO;
		if (isSegment) {
			parentGO = transform.parent.gameObject;
		} 
		else 
		{
			parentGO = this.gameObject;
		}



		foreach (Transform child in parentGO.transform) {


			RaycastHit hit = new RaycastHit ();
			Vector3 raycastPos = child.position + direction;
			raycastPos += new Vector3 (0.5f, 0.5f, -0.5f);



			if (Physics.Raycast (raycastPos, Vector3.forward, out hit)) {
				TileProperties hitTile = hit.transform.gameObject.GetComponent<TileProperties> ();
				if (hitTile == null) {
					return;
				}

				if (hitTile.name == "WaterTile")
					hitTile.gameObject.SetActive (false);
			}
		}

		RaycastHit parentHit = new RaycastHit ();
		Vector3 parentRaycastPos = parentGO.transform.position + direction;
		parentRaycastPos += new Vector3 (0.5f, 0.5f, -0.5f);



		if (Physics.Raycast (parentRaycastPos, Vector3.forward, out parentHit)) {
			TileProperties hitTile = parentHit.transform.gameObject.GetComponent<TileProperties> ();
			if (hitTile == null) {
				return;
			}

			if (hitTile.name == "WaterTile")
				hitTile.gameObject.SetActive (false);
		}
	}
}
