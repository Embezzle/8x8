using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class OSCManager : MonoBehaviour
{ //mcs
	public GameObject playerCharacter;

	private PlayerCharacter playerController;
	private CameraArea cameraArea;
	private OSCPacket _lastPacket = null;


	void Start() {
		OSCHandler.Instance.Init();

		AkSoundEngine.SetState ("Zone", "Temple");
		playerController = playerCharacter.GetComponent<PlayerCharacter> ();
		cameraArea = GameObject.Find ("CameraArea").GetComponent<CameraArea> ();
		OSCHandler.Instance.SendMessageToClient ("MaxMSP", "/LP/StartCC", 0);
	}

	void Update()
	{
		OSCHandler.Instance.UpdateLogs();

		if (OSCHandler.Instance.Servers["Unity"].packets.Count > 0) 
		{
			for (int i = 0; i < OSCHandler.Instance.Servers["Unity"].packets.Count; i++) 
			{
				receivedOSC (OSCHandler.Instance.Servers["Unity"].packets [i]);
				OSCHandler.Instance.Servers["Unity"].packets.RemoveAt (i);
				OSCHandler.Instance.Servers["Unity"].log.RemoveAt (i);
				i--;
			}

		}

	}

	public void receivedOSC(OSCPacket pckt)
	{
		if (pckt == null) { Debug.Log("Empty packet"); return; }
		if (pckt == _lastPacket)
			return;
		_lastPacket = pckt;

		string address = pckt.Address.Substring(1);

		int data0;
		int.TryParse (pckt.Data [0].ToString(), out data0);
		int data1;
		int.TryParse (pckt.Data [1].ToString(), out data1);
		int data2;
		int.TryParse (pckt.Data [2].ToString(), out data2);

		ReceiveMessage (address, data0, data1, data2);
	}

	public void ReceiveMessage(string address, int x, int y, int value) 
	{
		//print (address + " " + x + " " + y + " " + value);
		if (!playerController.isControlable)
			return;

		if ((address == "LP/cc") && (value == 127)) 
		{
			if (x == 1) {//Move Up
				playerController.Move (Vector3.up);
				Vector3 relativePos = playerController.transform.position - cameraArea.transform.position;
				if (relativePos.y > 5) 
				{
					cameraArea.MoveCamera (Vector3.up);
					return; //don't double draw camera
				}
			} 
			else if (x == 2) //Move Down
			{
				playerController.Move (Vector3.down);
				Vector3 relativePos = playerController.transform.position - cameraArea.transform.position;
				if (relativePos.y < 2) 
				{
					cameraArea.MoveCamera (Vector3.down);
					return; //don't double draw camera
				}
			}
			else if (x == 3) // Move Left
			{ 
				playerController.Move (Vector3.left);
				Vector3 relativePos = playerController.transform.position - cameraArea.transform.position;
				if (relativePos.x < 2) 
				{
					cameraArea.MoveCamera (Vector3.left);
					return; //don't double draw camera
				}
			} 
			else if (x == 4)// Move Right
			{
				playerController.Move (Vector3.right);
				Vector3 relativePos = playerController.transform.position - cameraArea.transform.position;
				if (relativePos.x > 5) 
				{
					cameraArea.MoveCamera (Vector3.right);
					return; //don't double draw camera
				}
			}
		}

		cameraArea.WritePositionsInCamera ();
	}

	public void SetPad (int x, int y, int value)
	{
		List<int> values = new List<int>{ x, y, value };
		OSCHandler.Instance.SendMessageToClient ("MaxMSP", "/LP/SetPad", values);
	}

	public void SetPadRGB (int x, int y, float r, float g, float b)
	{
		int rInt = (int)Mathf.Floor (r * 63f);
		int gInt = (int)Mathf.Floor (g * 63f);
		int bInt = (int)Mathf.Floor (b * 63f);
		List<float> values = new List<float>{ x, y, rInt, gInt, bInt };
		OSCHandler.Instance.SendMessageToClient ("MaxMSP", "/LP/SetPadRGB", values);
	}

	public void SetPadFlash (int x, int y, int value)
	{
		List<int> values = new List<int>{ x, y, value };
		OSCHandler.Instance.SendMessageToClient ("MaxMSP", "/LP/Flash", values);
	}
}