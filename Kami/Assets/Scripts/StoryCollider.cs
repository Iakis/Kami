using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryCollider : MonoBehaviour {

	bool storyActivated;
	public Text story;
	private GameObject[] stories;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col)
	{
		Debug.Log ("Collided");
		if (col.CompareTag ("Player")) 
		{
			Debug.Log ("Collided");
			Debug.Log (this.gameObject.name);
			storyActivated = true;
			stories = GameObject.FindGameObjectsWithTag("story");
			foreach (GameObject storyPoint in stories)
			{
				if (storyPoint.GetComponent<StoryCollider>().storyActivated)
				{
					if(storyPoint.gameObject.name == "StoryCollider1"){
						Debug.Log ("Fading Text");
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("She can't be gone, I have to get her back"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider2"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("This can't be happening"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider3"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I'll get you out of here, I promise"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider4"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Don't try to stop us!"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name== "StoryCollider5"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Let us out!"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider6"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I'll do anything, just let us go!"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider7"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("We'll make it through, whatever the cost"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider8"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I promise I'll never let anything happen to you ever again"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider9"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("No don't go!"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name== "StoryCollider10"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I need you"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider11"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I can't live without you"));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider12"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I could've saved you..."));
						storyActivated = true;
					}
					if(storyPoint.gameObject.name == "StoryCollider13"){
						StartCoroutine(story.GetComponent<StoryText> ().FadeText ("It was all for nothing"));
						storyActivated = true;
					}
				}
			}
		}
	}
}
