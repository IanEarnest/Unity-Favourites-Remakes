using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject player;
	public GameObject bulletSmall;
	public GameObject bulletBig;
	public TextMesh aimer;

	public Ammo ammo;

	GameObject clone;
	Vector3 cloneDirection;
	int shotPower = 600;
	Ray ray;
	RaycastHit hit;

	void Update () {
		// UI aimer
		aimer.transform.position = hit.point;

		// Drawing line from infront of player
		Vector3 playerFrontPos = player.transform.position;
		playerFrontPos.y = player.transform.position.y + 2;

		// Get mouse position.
		ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100)){
			// Draw line in debug only.
			Debug.DrawLine(playerFrontPos, hit.point, Color.red);
		}

		
		// Left click for small bullet.
		if(Input.GetMouseButtonDown(0) && GameGUI.isPaused == false){
			if(ammo.canFireBullet("small")){
				clone = Instantiate(bulletSmall, playerFrontPos, player.transform.rotation) as GameObject;
				cloneDirection = clone.transform.position - hit.point;
				cloneDirection.Normalize();
			}
		}
		// Press space or right click for big bullet.
		if(Input.GetKeyDown(KeyCode.Space) && GameGUI.isPaused == false ||
		   Input.GetMouseButtonDown(1) && GameGUI.isPaused == false){
			if(ammo.canFireBullet("big")){				
				clone = Instantiate(bulletBig, playerFrontPos, player.transform.rotation) as GameObject;
				cloneDirection = clone.transform.position - hit.point;
				cloneDirection.Normalize();
			}
		}
		
		// If clone exists move it.
		if(clone != null && clone.rigidbody.velocity == Vector3.zero){
			Vector3 force = new Vector3();

			//// Shooting test
			// Get difference between mouse position Y to player position Y, that is shot power.
			int p = ~(int)player.transform.position.y;
			int m = (int)Input.mousePosition.y;
			int pwr = m-p;
			//pwr *= shotPower;
			print("Power: " + pwr);
			////

			if(clone.name.Contains("Bullet Small")){
				//force.y = pwr;
				//Vector3 playerPos = new Vector3();
				//Vector3 mousePos = new Vector3();
				//playerPos = player.transform.position;
				//mousePos = Input.mousePosition;

				//playerPos.y += 2;
				//mousePos.x = 0;
				//mousePos.y = 0;
				//mousePos.z = 0;
				//clone.transform.position = Vector3.MoveTowards(playerPos, mousePos, pwr * Time.deltaTime);

				//clone.transform.LookAt(Input.mousePosition);

				//clone.transform.position = Vector3.MoveTowards(clone.transform.position, Input.mousePosition, 1.5f * Time.deltaTime);

				//force.Set(0f, 10f * (-cloneDirection.y * shotPower), 0f);
				//force = new Vector3(0f, 10f * (-cloneDirection * shotPower), 0f);
				clone.rigidbody.AddForce(10 * (-cloneDirection * shotPower));
			}
			else if(clone.name.Contains("Bullet Big")){
				clone.rigidbody.AddForce(10 * (-cloneDirection * (shotPower*5)));
				//force.Set(0f, 10f * (-cloneDirection.y * (shotPower * 5)), 0f);
				//force.y = pwr*5;
			}
			//clone.rigidbody.AddForce(force);			
		}
	}
}
