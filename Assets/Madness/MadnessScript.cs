using UnityEngine;
using System.Collections;

public class MadnessScript : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Start () {
		character = Instantiate(character, Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
