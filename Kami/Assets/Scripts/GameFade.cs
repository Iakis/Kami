using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFade : MonoBehaviour {

	public Image fade;
	public Animator anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FadeIn(){
		anim.SetBool ("Fade", false);
		yield return new WaitUntil (() => fade.color.a == 0);
	}

	IEnumerator FadeOut(){
		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fade.color.a == 1);
	}
}
