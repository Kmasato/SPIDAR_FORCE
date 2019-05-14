using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fromEPS : MonoBehaviour {

	public SerialMaster SerialHandler;
	public MovePoint mv;

	// Use this for initialization
	void Start () {
		SerialHandler.OnDataReceived += OnDataReceived;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDataReceived(string message){
		try{
			string[] pos = message.Split(',');
			Debug.Log(pos[0]);
		}
		catch(System.Exception e){
			Debug.LogWarning(e.Message);
		}
	}
}
