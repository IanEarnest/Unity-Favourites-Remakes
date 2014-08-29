using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Change borders to fit better.
	public int range = 30;

	// Update is called once per frame
	void Update () {
		// When bullets go out of range, destroy bullet.
		if(transform.position.x > range || 
		   transform.position.x < -range || 
		   transform.position.y > range || 
		   transform.position.y < -range){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		// On any collision, destroy bullet.
		//Destroy(gameObject); // Collision not used as bullet is now trigger.
	}

	void OnTriggerEnter(Collider other){
		if(other.transform.name.Contains("Enemy") || 
		   other.transform.name.Contains("Floor")){
			Destroy(gameObject);
		}
	}
}
