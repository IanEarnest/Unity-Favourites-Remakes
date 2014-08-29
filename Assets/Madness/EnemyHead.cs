using UnityEngine;
using System.Collections;

public class EnemyHead : MonoBehaviour {

	int enemyHealth = 1;
		
	void OnCollisionEnter(Collision col){
		if(col.transform.name.Contains("Bullet")){
			enemyHealth--;
		}
		if(enemyHealth <= 0){
			Destroy(transform.parent.gameObject);
		}
	}
		
	void OnTriggerEnter(Collider other){
		if(other.transform.name.Contains("Bullet")){
			enemyHealth--;
		}
		if(enemyHealth <= 0){
			Destroy(transform.parent.gameObject);
		}
	}
}
