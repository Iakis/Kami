using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;

	public GameObject pauseMenu;
	public GameObject Restart;
	public GameObject Quit;
	GameObject eventSystem;
	// Update is called once per frame

	void Start(){
		eventSystem = GameObject.Find("EventSystem");
	}
	void Update () {
		if(Input.GetButtonUp("StartButton")) {
			if(isPaused){
				Resume();
			}
			else{
				Pause();
			}
		}
	}

	void Resume(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		AudioListener.pause = false;
		Debug.Log (Time.timeScale);
		isPaused = false;
		eventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
	}

	void Pause(){
		pauseMenu.SetActive (true);
		eventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Restart);
		Time.timeScale = 0f;
		isPaused = true;
		AudioListener.pause = true;
		Debug.Log (Time.timeScale);
	}

	public void RestartGame(){
		Debug.Log ("Restarting Game");
	}

	public void QuitGame(){
		Debug.Log ("Quitting game");
	}

	public void LastSpawn(){
		Debug.Log ("Loading from last spawn");
	}
}
