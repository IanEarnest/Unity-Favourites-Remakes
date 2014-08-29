using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

	public int range = 30;

	// Update is called once per frame
	void Update () {
		// Change borders to fit better.
		if(transform.position.x > range || 
		   transform.position.x < -range || 
		   transform.position.y > range || 
		   transform.position.y < -range){
			Destroy(gameObject);
		}
	}
}
