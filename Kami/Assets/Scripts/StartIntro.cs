using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartIntro : MonoBehaviour {

	Text startGame;
	string blank = "";
	string flashing = "Press start to play";

	public Image fade;
	public Animator anim;

	public AudioSource source;
	public AudioClip start;

	// Use this for initialization
	void Start () {
		startGame = GetComponent<Text> ();
		StartCoroutine (BlinkText ());
	}
	//function to blink the text 
	public IEnumerator BlinkText(){
		//blink it forever. You can set a terminating condition depending upon your requirement
		while (true) {
			startGame.text = blank;
			yield return new WaitForSeconds (.5f);
			startGame.text = flashing;
			yield return new WaitForSeconds (.5f);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("StartButton"))
		{
			StartCoroutine (Fading ());
			StartCoroutine (FadeVolume ());
		}
	}

	IEnumerator Fading(){
		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fade.color.a == 1);
		SceneManager.LoadScene ("postCutscene", LoadSceneMode.Single);
	}

	IEnumerator FadeVolume(){
		float startVolume = source.volume;
		while (source.volume > 0) {
			source.volume -= startVolume * Time.deltaTime / 6.0f;

			yield return null;
		}

		source.Stop ();
	}
}
