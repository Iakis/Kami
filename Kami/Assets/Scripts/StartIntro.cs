using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartIntro : MonoBehaviour {

	Text startGame;
	string blank = "";
	string flashing = "Press start to play";

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
			SceneManager.LoadScene ("IntroVideo", LoadSceneMode.Single);
		}
	}
}
