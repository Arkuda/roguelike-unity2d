using UnityEngine;
using System.Collections;

public class PlayerTeleporter : MonoBehaviour {

	public bool isTeleported = false;
	public bool isTPtoObj = true;
	public bool isTPToThisObj = true;
	public GameObject ObjWhoTP;
	public GameObject ObjPoint;
	public Vector3 CoordToTP; //OR


	// Update is called once per frame
	void Update () {
		if(isTeleported == false){
			ObjWhoTP = GameObject.Find("Player");
			if(isTPtoObj)
				if(isTPToThisObj) 
					ObjWhoTP.transform.position = this.transform.position;
				else
					ObjWhoTP.transform.position = ObjPoint.transform.position;

			else 
				ObjWhoTP.transform.position = CoordToTP;
			ObjWhoTP.transform.position -= new Vector3(0f,0f,3f);
			isTeleported = true;
		}
	}
}
