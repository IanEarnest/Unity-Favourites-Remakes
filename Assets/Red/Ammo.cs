using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public TextMesh ammoText;

	public static float ammoValue = 10;
	float maxAmmo = 10;
	float reloadAmount;
	int smallBulletCost = 1;
	int bigBulletCost = 3;

	// Use this for initialization
	void Start () {
		// Calculation for reload amount.
		reloadAmount = 1 * Time.deltaTime * 2;
	}
	
	// Update is called once per frame
	void Update () {
		// Update ammo value on screen.
		ammoText.text = "";
		for(float i = 0; i < ammoValue; i++){
			ammoText.text += "|";//"" + (int)ammo;
		}

		// Keep ammo stocked up.
		if(ammoValue < maxAmmo){
			ammoValue += reloadAmount;
		}
	}

	public bool canFireBullet(string bulletType){
		// Firing small bullet
		if (bulletType == "small") {
			if (ammoValue > smallBulletCost) {
				ammoValue -= smallBulletCost;
				return true;
			}
		}
		// Firing big bullet
		if (bulletType == "big") {
			if (ammoValue > bigBulletCost) {	
				ammoValue -= bigBulletCost;
				return true;
			}
		}

		// Not enough ammo
		print ("cannot fire");
		return false;
	}
}
