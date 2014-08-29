using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemy;
	GameObject clone;
	
	int enemyCount = 0;
	int maxEnemyCount = 3;


	void SpawnEnemy(){
		clone = Instantiate(enemy, new Vector3(Random.Range(-10,10), 9, 0), enemy.transform.rotation) as GameObject;
		int r = Random.Range(1, 12);
		clone.transform.localScale = new Vector3(r, r, r);
		clone.rigidbody.mass = r * 7;
		if(enemyCount < maxEnemyCount-1){
			Invoke("SpawnEnemy", 2);
		}
	}

	// Update is called once per frame
	void Update () {
		// Count enemies in scene;
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

		// Enemy spawn, position and destroy.
		if(enemyCount < maxEnemyCount){
			if(!IsInvoking("SpawnEnemy")){
				Invoke("SpawnEnemy", 2);
			}
		}

		// Spawn multiple enemies.

		// Set up a wave system based on time.

		// if enemy hits or goes past player, lose a life.
	}
}
