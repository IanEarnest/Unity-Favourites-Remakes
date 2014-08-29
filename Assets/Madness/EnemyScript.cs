using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	Transform characterTransform;
	int enemyHealth = 3;

	// Use this for initialization
	void Start () {
		characterTransform = GameObject.FindWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if(characterTransform.position.x > transform.position.x){
			transform.position += transform.right * 1f * Time.deltaTime;
		}else{
			transform.position -= transform.right * 1f * Time.deltaTime;
		}

		// Enemy appearance depending on health.
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
		// Temp solution to fix bullet damaging armour and enemy.
		if(transform.childCount > 0){
			if(transform.FindChild("EnemyArmour")){
				enemyHealth = 3;
			}
		}
		print ("hit enemy");
		if(enemyHealth <= 0){
			Destroy(gameObject);
		}
	}
}
