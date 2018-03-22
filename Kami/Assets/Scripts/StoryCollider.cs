using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryCollider : MonoBehaviour {

	bool storyActivated;
	public Text story;
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
			// Check if story activated
			if(!storyActivated){
				// Call story point text depending on name
				if(this.gameObject.name == "StoryCollider1"){
					Debug.Log ("Fading Text");
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("She's nearby, I can feel it"));
					storyActivated = true;
				}
				if(this.gameObject.name == "StoryCollider2"){
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I see a house over there"));
					storyActivated = true;
				}
				if(this.gameObject.name == "StoryCollider3"){
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Is that her over there?"));
					storyActivated = true;
				}
				if(this.gameObject.name == "StoryCollider4"){
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I'll get you out of here, I promise"));
					storyActivated = true;
				}
			}
		}
	}
}
