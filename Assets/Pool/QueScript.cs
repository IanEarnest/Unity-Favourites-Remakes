using UnityEngine;
using System.Collections;

public class QueScript : MonoBehaviour {

	public Transform whiteBall;
	public Camera camera2D;
	public Camera camera3D;

	public int shotPower;
	public int maxShotPower = 100;
	float rotationSpeed = .5f;
	bool ballMoving;

	Vector3 queVector3Direction;
	Ray ray;
	RaycastHit hit;

	Quaternion queRotation;
	Vector3 quePosition;
	Quaternion camRotation;
	Vector3 camPosition;

	void Start(){
		queRotation = transform.rotation;
		quePosition = transform.position;
		camRotation = camera3D.transform.rotation;
		camPosition = camera3D.transform.position;
	}

	
	void OnGUI(){
		// set on screen value to power value
		GUILayout.Box("Power: " + shotPower);
	}

	void Update () {
		//var myString = "hey"; // you can declare var instead of the type.

		// Find the Vector3 pointing from que to whiteBall.
		queVector3Direction = (whiteBall.position - transform.position).normalized;
		ray = new Ray(transform.position, queVector3Direction);


		camera3D.transform.LookAt(whiteBall.transform.position);

		// If white ball is not moving.
		if(whiteBall.rigidbody.velocity == Vector3.zero){
			// if mouse is holding click on que
			// move que x by mouse movement, restrict min and max
			// if mouse is let go set ball velocity to power value


			// put que next to ball
			if(ballMoving == true){
				/*
				Vector3 _vector3 = camera3D.transform.position;
				_vector3.y -= 3;
				_vector3.x += 7;
				transform.position = _vector3;
				*/
				transform.position = new Vector3(whiteBall.transform.position.x - 7, 0.7f, 0);
				transform.rotation = queRotation;

				camera3D.transform.position = new Vector3(whiteBall.transform.position.x - 14, 3.7f, 0);
				camera3D.transform.rotation = camRotation;

			}
			ballMoving = false;


			// Move que left.
			if(Input.GetKey(KeyCode.A)){

				transform.RotateAround(whiteBall.transform.position, new Vector3(0, 1, 0), rotationSpeed);
				camera3D.transform.RotateAround(whiteBall.transform.position, new Vector3(0, rotationSpeed, 0), rotationSpeed);
			}
			// Move que right.
			if(Input.GetKey(KeyCode.D)){
				transform.RotateAround(whiteBall.transform.position, new Vector3(0, -rotationSpeed, 0), rotationSpeed);
				camera3D.transform.RotateAround(whiteBall.transform.position, new Vector3(0, -rotationSpeed, 0), rotationSpeed);
			}


			// Move que forward.
			if(Input.GetKey(KeyCode.W) && shotPower > 0){
				transform.Translate(0, -0.075f, 0);
				shotPower--;
			}
			// Move que back.
			if(Input.GetKey(KeyCode.S) && shotPower < maxShotPower){
				transform.Translate(0, 0.075f, 0);
				shotPower++;
			}

			if(Input.GetKey(KeyCode.F)){
				transform.Translate(0, -0.075f, 0);
			}



			if (Physics.Raycast(ray, out hit, 50)){
				Debug.DrawLine(transform.position, whiteBall.transform.position, Color.red);
				// push que towards ball, power = distance
			}

			// Space to shoot.
			if(Input.GetKeyDown(KeyCode.Space)){
				//Vector3 _newPosition = new Vector3(-10 * camera3D.transform.position.x * shotPower, 0, -10 * camera3D.transform.position.z * shotPower);
				//whiteBall.rigidbody.AddForceAtPosition(_newPosition, transform.position);
				/*
				Ray ray2 = new Ray(transform.position, transform.position);
				RaycastHit hit2;
				if((Physics.Raycast(ray2, out hit2) )){
					whiteBall.rigidbody.AddForceAtPosition(10 * shotPower  * -transform.right, hit2.point);
				}
				*/

				whiteBall.rigidbody.AddForce(Vector3.right * 100 * shotPower);
				collider.enabled = true;
			}

			// Change camera.
			if(Input.GetKeyDown(KeyCode.Q)){
				camera2D.camera.enabled = !camera2D.camera.enabled;
				camera3D.camera.enabled = !camera3D.camera.enabled;
			}
		}
		// else if white ball is moving
		// move and set que to invisible
		else{
			ballMoving = true;
			collider.enabled = false;
		}
	}
}
