using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArea : MonoBehaviour {
	private float xPos;
	private float yPos;
	private GameObject level;
	private OSCManager oscManager;

	// Use this for initialization
	void Start () {
		xPos = Mathf.Floor(this.transform.position.x);
		yPos = Mathf.Floor(this.transform.position.y);

		level = GameObject.Find ("Level");
		oscManager = GameObject.Find ("OSCManager").GetComponent<OSCManager> ();

		WritePositionsInCamera ();
	}

	public void MoveCamera (Vector3 direction) {
		this.transform.Translate (direction);
		xPos = Mathf.Floor(this.transform.position.x);
		yPos = Mathf.Floor(this.transform.position.y);

		WritePositionsInCamera ();
	}

	void WriteToPad (int x, int y, int value) {
		oscManager.SetPad (x, y, value);
	}

	void WriteToPadRGB (int x, int y, Color colour){
		oscManager.SetPadRGB (x, y, colour.r, colour.g, colour.b);
	}

	void WriteToPadFlash (int x, int y, int value){
		oscManager.SetPadFlash (x, y, value);
	}

	public void WritePositionsInCamera ()
	{
		RaycastHit hit = new RaycastHit ();

		for (int xCamera = 0; xCamera < 8; xCamera++) 
		{
			for (int yCamera = 0; yCamera < 8; yCamera++) 
			{
				float xToTry = xPos + xCamera + 0.5f;
				float yToTry = yPos + yCamera + 0.5f;

				Vector3 vectorToTry = new Vector3 (xToTry, yToTry, -1f);

				if (Physics.Raycast (vectorToTry, Vector3.forward, out hit)) {
					//print ("hit " + hit.transform.gameObject.name);
					Color colour = hit.transform.GetComponent<SpriteRenderer> ().color;
					WriteToPadRGB (xCamera + 1, yCamera + 1, colour);

					if ((hit.transform.GetComponent<TileProperties> () != null)
					&& hit.transform.GetComponent<TileProperties> ().flashing) {
						WriteToPadFlash (xCamera + 1, yCamera + 1, hit.transform.GetComponent<TileProperties> ().flashColour);
					}
				} else {
					WriteToPad (xCamera + 1, yCamera + 1, 0);
				}
			}
		}	
	}
}
