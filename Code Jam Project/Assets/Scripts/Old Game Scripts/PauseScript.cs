using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject menu;
	bool isPaused = true;




	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Escape)) {
		if (isPaused) {
				menu.SetActive(false);
					Time.timeScale = 1f;
				isPaused = !isPaused;
			}
			else{
				menu.SetActive(true);
					Time.timeScale = 0f;
				isPaused = !isPaused;


		}
		}

	}

	public void PauseGame(bool paused){
		isPaused = paused;
		if(isPaused){
			menu.SetActive(false);
			Time.timeScale = 1f;
			isPaused = !isPaused;
		}
		else{
			menu.SetActive(true);
			Time.timeScale = 0f;
		}
	}

}
