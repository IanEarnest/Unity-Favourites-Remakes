using UnityEngine;
using System.Collections;

public class HandScript : MonoBehaviour {

	public GameObject character;
	public GameObject bullet;
	GameObject clone;
	Vector3 cloneDirection;

	int shotPower = 60;
	Vector3 prevMousePosition;
	float up;
	float right;
	float max = 2f;
	float speed = 0.1f;

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		transform.position = character.transform.position;
		prevMousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(characterTransform != characterTransform){
			transform.position = characterTransform.transform.position;
		}*/
		// Hand movement
		// Need to set max
		Vector3 newPos = transform.position;
		// Move up
		/*
		if(Input.mousePosition.y > prevMousePosition.y && 
		   transform.position.y < (characterTransform.position.y + 2)){
			newPos.y++;
		}
		*/

		if(Input.mousePosition.y > prevMousePosition.y && up < max){
			newPos.y += speed;
			up += speed;
		}
		// Move down
		if(Input.mousePosition.y < prevMousePosition.y && up > -max + .5f){
			newPos.y -= speed;
			up -= speed;
		}
		// Move left
		if(Input.mousePosition.x > prevMousePosition.x && right < max){
			newPos.x += speed;
			right += speed;
		}
		// Move right
		if(Input.mousePosition.x < prevMousePosition.x && right > -max){
			newPos.x -= speed;
			right -= speed;
		}
		transform.position = newPos;
		prevMousePosition = Input.mousePosition;


		Vector3 myVector = Vector3.zero;
		// Setting up aimer.
		Vector3 _transformOffset = transform.position;
		//_transformOffset.y = transform.position.y + 2;
		
		// Get mouse position.
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100)){
			// Draw line in debug only.
			Debug.DrawLine(_transformOffset, hit.point, Color.red);

			myVector = new Vector3(character.transform.position.x, character.transform.position.y + .2f, character.transform.position.z);
			Debug.DrawLine(myVector, transform.position, Color.black);

			// Try to draw line opposite of the other line?
			Vector3 anotherVector = new Vector3(/*~(int)*/myVector.x, myVector.y, myVector.z);
			Debug.DrawLine(transform.position, anotherVector, Color.yellow);
		}


		
		// Left click for shooting.
		if(Input.GetMouseButtonDown(0)){
			clone = Instantiate(bullet, _transformOffset, transform.rotation) as GameObject;
			cloneDirection = character.transform.position - transform.position;
			cloneDirection.Normalize();
		}
		
		// If clone exists move it.
		if(clone != null && clone.rigidbody.velocity == Vector3.zero){
			clone.rigidbody.AddForce(10 * (-cloneDirection * shotPower));
		}
	}
}
