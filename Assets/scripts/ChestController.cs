using System;
using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour {


	public int state = 0; // 0 - not opened, 1 - opened;
	public Collision2D collis;
	void Start () {
		
	}
	
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll){
        Debug.Log("IsCollide");
	    state = 1;
	    try
	    {
            this.GetComponent<Animator>().Play("ChestOpening");
	    }
	    catch (NullReferenceException exception)
	    {
	       
	    }
	}
}
