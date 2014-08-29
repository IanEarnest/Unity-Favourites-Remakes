using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public static bool isPaused;
	public static int lives = 5;

	// Update is called once per frame
	void Update () {
		// Pause button.
		if(Input.GetKeyDown(KeyCode.P)){
			isPaused = !isPaused;
		}
		// Pausing gameplay.
		if(isPaused == true){
			Time.timeScale = 0;
		}
		else{
			Time.timeScale = 1;
		}
	}

	void OnGUI(){
		if(isPaused == false){
			if(GUILayout.Button("Pause(P)")){
				isPaused = !isPaused;
			}
		}
		else{
			if(GUILayout.Button("Unpause(P)")){
				isPaused = !isPaused;
			}
		}
		GUILayout.Box("Lives: " + lives);
		GUILayout.Box("Time survived: " + (int)Time.timeSinceLevelLoad);

	}
}
