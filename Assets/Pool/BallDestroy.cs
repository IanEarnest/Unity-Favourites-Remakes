using UnityEngine;
using System.Collections;

public class BallDestroy : MonoBehaviour {
	
	void Update () {
		// Ball goes off edge, gets destryoed.
		if(transform.position.y < -0.5){
			if(name != "White Ball"){
				Destroy(transform.gameObject);
			}
			else{
				transform.position = new Vector3(-7.6f,0,0);
			}
		}
	}
}
