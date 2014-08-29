using UnityEngine;
using System.Collections;

public class EnemyArmour : MonoBehaviour {

	int enemyHealth = 4;
		
	void Update () {
		// Enemy appearance depending on health..
		if(enemyHealth == 4){
			gameObject.renderer.material.color = Color.green;
		}
		if(enemyHealth == 4){
			gameObject.renderer.material.color = Color.blue;
		}
		if(enemyHealth == 3){
			gameObject.renderer.material.color = Color.red;
		}
		if(enemyHealth == 2){
			gameObject.renderer.material.color = Color.yellow;
		}
		else if(enemyHealth == 1){
			gameObject.renderer.material.color = Color.white;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.transform.name.Contains("Bullet")){
			enemyHealth--;

		}
		print ("hit armour");
		if(enemyHealth <= 0){
			// Allow parent to get damaged after armour is broken.
			transform.parent.collider.isTrigger = false;
			Destroy(gameObject);
		}
	}
}
