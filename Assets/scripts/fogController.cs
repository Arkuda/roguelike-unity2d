using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class fogController : MonoBehaviour {


    public state FogState = state.notAdvented;
   

    public enum state
    {
        notAdvented,
        halfAdvented,
        Advented
    }

    private GameObject gamer;
	public float distance = 0;
	public Color myclr;

	void Update ()
	{
	    gamer = GameObject.FindGameObjectWithTag("Player");
	    GameObject[] lightingsObjects = GameObject.FindGameObjectsWithTag("LightingsObject");

		distance = Vector2.Distance(new Vector2(gamer.transform.position.x, gamer.transform.position.y), new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y)) ;

        
		if (distance > 2.5)
            FogState = state.notAdvented;
		if (distance <= 2.5 && distance > 1.5)
	        FogState = state.halfAdvented;
		if (distance <= 1.5)
            FogState = state.Advented;
	
        //now render

	

		SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
		if(FogState == state.Advented)
			sr.color = new Color(255,255,255,0);
		else if( FogState == state.halfAdvented)
			sr.color = myclr;
		else if(FogState == state.notAdvented)
			sr.color = new Color(255,255,255,255);
       
            
           
	   
    
    }
}
