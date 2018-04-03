using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;

	public GameObject pauseMenu;
	public GameObject Restart;
	public GameObject Nagi;
	Movement NagiScript;

	public Image fade;
	public Animator anim;

	GameObject eventSystem;
	GameObject selected;
	private AudioSource selectSound;
	// Update is called once per frame

	void Start(){
		eventSystem = GameObject.Find("EventSystem");
		NagiScript = Nagi.GetComponent<Movement> ();
		selectSound = GameObject.Find("TaikoDrumSound").GetComponent<AudioSource>();

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
		if (isPaused) {
			if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().currentSelectedGameObject != selected) {
				selected = eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().currentSelectedGameObject;
				selectSound.Play ();
			}
		}
	}

	void Resume(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		GameObject.Find ("StartingMusic").GetComponent<AudioSource> ().Play ();
		Debug.Log (Time.timeScale);
		isPaused = false;
		eventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
	}

	void Pause(){
		pauseMenu.SetActive (true);
		eventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Restart);
		Time.timeScale = 0f;
		isPaused = true;
		GameObject.Find ("StartingMusic").GetComponent<AudioSource> ().Pause ();
		Debug.Log (Time.timeScale);
	}

	public void RestartGame(){
		Debug.Log ("Restarting Game");
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		StartCoroutine (FadeRestart ());
		isPaused = false;
		//SceneManager.LoadScene ("test", LoadSceneMode.Single);
	}

	public void QuitGame(){
		Debug.Log ("Quitting game");
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		StartCoroutine (FadeQuit ());
		isPaused = false;
		//SceneManager.LoadScene ("TitleScreen", LoadSceneMode.Single);
	}

	public void LastSpawn(){
		Debug.Log ("Loading from last spawn");
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		StartCoroutine (NagiScript.Respawn());
		GameObject.Find ("StartingMusic").GetComponent<AudioSource> ().Play ();
		isPaused = false;
	}

	IEnumerator FadeRestart(){
		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fade.color.a == 1);
		SceneManager.LoadScene ("test", LoadSceneMode.Single);
	}

	IEnumerator FadeQuit(){
		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fade.color.a == 1);
		SceneManager.LoadScene ("TitleScreen", LoadSceneMode.Single);
	}
}
