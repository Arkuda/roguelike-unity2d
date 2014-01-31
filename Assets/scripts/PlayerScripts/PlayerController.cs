using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public GameObject Player;
	public float Speed = 1.5f;

	
	// Update is called once per frame
	void Update (){

		if (Input.GetKey (KeyCode.A) == true) {
			Player.transform.position -= new Vector3(Speed * Time.deltaTime,0f);
		}

		if (Input.GetKey (KeyCode.D) == true) {
			Player.transform.position += new Vector3(Speed * Time.deltaTime,0f);
		}
		if (Input.GetKey (KeyCode.W) == true) {
			Player.transform.position += new Vector3(0f,Speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S) == true) {
			Player.transform.position -= new Vector3(0f,Speed * Time.deltaTime);
		}


	}
}
