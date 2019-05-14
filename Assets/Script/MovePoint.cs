using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour {

	public SerialMaster SerialHandler;
	//public byte[] data = {1,2,3,4};
	public Vector3 force;

	// Use this for initialization
	void Start () {
		SerialHandler.OnDataReceived += OnDataReceived;
		force = new Vector3();
		force = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		short fx = (short)(force.x*10), fy = (short)(force.y*10);
		byte[] data= {(byte)(fx >> 8), (byte)(fx & 0xFF),(byte)(fy >> 8), (byte)(fy & 0xFF)};
		SerialHandler.WriteBuffer(data);
	}

	private void OnCollisionEnter(Collision collision){
		foreach(ContactPoint contact in collision.contacts){
			if(contact.thisCollider.name == name){
				//Debug.Log(contact.normal);
				force = contact.normal;
				Debug.Log(force);
			}
		}
	}

	private void OnCollisionExit(Collision collision){
		force = Vector3.zero;
		Debug.Log(force);
	}

	void OnDataReceived(string message){
		try{
			//Debug.Log(message);
			string[] pos = message.Split(',');
			this.transform.position = new Vector3(float.Parse(pos[0])/10, float.Parse(pos[1])/10,0);
		}
		catch(System.Exception e){
			Debug.LogWarning(e.Message);
		}
	}
}
