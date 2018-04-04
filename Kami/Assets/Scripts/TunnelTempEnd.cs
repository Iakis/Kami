using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TunnelTempEnd : MonoBehaviour {

	public Text story;

	public Image fade;
	public Animator anim;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			AudioListener.pause = true;
			StartCoroutine (FadeEnd ());
		}
	}

	IEnumerator FadeEnd(){
		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fade.color.a == 1);
		StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("Wait where are you?"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("What do you mean you can't come back?"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("Don't leave me!"));
		yield return new WaitForSeconds(7f);
		SceneManager.LoadScene ("credits", LoadSceneMode.Single);
	}
}
