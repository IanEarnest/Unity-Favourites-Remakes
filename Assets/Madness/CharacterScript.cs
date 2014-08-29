using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {


	//Need to move enemy stuff into enemyscript or gamescript.
	public GameObject enemy;
	public GameObject enemyOther;
	GameObject enemyClone;
	
	int enemyCount = 0;
	int maxEnemyCount = 3;
	Vector3 enemyPos;
	public float movespeed = 1f;	
	
	void SpawnEnemy(){
		// Left or right spawn.
		int r = Random.Range(1, 3);
		if(r == 1){	enemyPos = new Vector3(5, -2.4f, 0); }
		else if(r == 2){ enemyPos = new Vector3(-5, -2.4f, 0); }

		r = Random.Range(1, 3);
		if(r == 1){
			enemyClone = Instantiate(enemy, enemyPos, enemy.transform.rotation) as GameObject;
		}
		else if(r == 2){ 
			enemyClone = Instantiate(enemyOther, enemyPos, enemyOther.transform.rotation) as GameObject;
		}


		// If auto-spawn enemy is on
		if(enemyCount < maxEnemyCount-1){
			//Invoke("SpawnEnemy", 2);
		}
	}
		
		

	// Update is called once per frame
	void Update () {
		// Count enemies in scene;
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		// Enemy spawn, position and destroy.
		if(enemyCount < maxEnemyCount){
			if(!IsInvoking("SpawnEnemy")){
				//Invoke("SpawnEnemy", 2);
			}
		}

		// Spawn enemy
		if(Input.GetKeyDown(KeyCode.Space)){
			SpawnEnemy();
		}


		// Movement WASD

		// Press W to Jump.
		if(Input.GetKey("w"))
			rigidbody.MovePosition(new Vector3(rigidbody.position.x
			                                   ,rigidbody.position.y+movespeed/5
			                                   ,rigidbody.position.z));
		// Press A to go Left.
		if(Input.GetKey("a"))
			rigidbody.MovePosition(new Vector3(rigidbody.position.x-movespeed/5
			                                   ,rigidbody.position.y
			                                   ,rigidbody.position.z));
		// Press S to go Down.
		if(Input.GetKey("s"))
			rigidbody.MovePosition(new Vector3(rigidbody.position.x
			                                   ,rigidbody.position.y-movespeed/5
			                                   ,rigidbody.position.z));
		// Press D to go Right.
		if(Input.GetKey("d"))
			rigidbody.MovePosition(new Vector3(rigidbody.position.x+movespeed/5
			                                   ,rigidbody.position.y
			                                   ,rigidbody.position.z));
	}

	void OnCollisionEnter(Collision col){		
		if(col.transform.name.Contains("Enemy")){
			//take away health for now until enemy can shoot.
		}
	}
}
