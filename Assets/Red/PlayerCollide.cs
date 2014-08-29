using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if(col.transform.name.Contains("Enemy")){
			Destroy(col.gameObject);
			GameGUI.lives--;
		}
	}
}
