﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TempEndingCollider : MonoBehaviour {

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
		StartCoroutine(story.GetComponent<StoryText> ().FadeText ("This is the way out!"));
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene ("End", LoadSceneMode.Single);
	}
}
