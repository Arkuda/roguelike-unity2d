using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public GameObject Player;
	public float Speed = 1.5f;
    public sides PlayerRotation = sides.right;

    public GameObject[] pointners;

    public enum  sides
    {
        up,
        down,
        left,
        right
    }

	
	// Update is called once per frame
	void Update (){

		if (Input.GetKey (KeyCode.A) == true) {
			Player.transform.position -= new Vector3(Speed * Time.deltaTime,0f);
            PlayerRotation = sides.left;
            showPointner();
		}

		if (Input.GetKey (KeyCode.D) == true) {
			Player.transform.position += new Vector3(Speed * Time.deltaTime,0f);
            PlayerRotation = sides.right;
            showPointner();
		}
		if (Input.GetKey (KeyCode.W) == true) {
			Player.transform.position += new Vector3(0f,Speed * Time.deltaTime);
            PlayerRotation = sides.up;
            showPointner();
		}
		if (Input.GetKey (KeyCode.S) == true) {
			Player.transform.position -= new Vector3(0f,Speed * Time.deltaTime);
            PlayerRotation = sides.down;
            showPointner();
		}


	}


    void showPointner()
    {
        SpriteRenderer sr0 = pointners[0].GetComponent<SpriteRenderer>();
        SpriteRenderer sr1 = pointners[1].GetComponent<SpriteRenderer>();
        SpriteRenderer sr2 = pointners[2].GetComponent<SpriteRenderer>();
        SpriteRenderer sr3 = pointners[3].GetComponent<SpriteRenderer>();
        switch (PlayerRotation)
        {
            case sides.up:
                sr0.renderer.enabled = true;
                sr1.renderer.enabled = false;
                sr2.renderer.enabled = false;
                sr3.renderer.enabled = false;
                break;
            case sides.down:
                sr0.renderer.enabled = false;
                sr1.renderer.enabled = true;
                sr2.renderer.enabled = false;
                sr3.renderer.enabled = false;
                break;
            case sides.left:
                sr0.renderer.enabled = false;
                sr1.renderer.enabled = false;
                sr2.renderer.enabled = true;
                sr3.renderer.enabled = false;
                break;
            case sides.right:
                sr0.renderer.enabled = false;
                sr1.renderer.enabled = false;
                sr2.renderer.enabled = false;
                sr3.renderer.enabled = true;
                break;

        }
    }
}
