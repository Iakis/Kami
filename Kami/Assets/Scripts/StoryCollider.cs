using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryCollider : MonoBehaviour {

	bool storyActivated;
	public Text story;
	// Use this for initialization
	void Start () {
		AudioListener.pause = false;
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
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("She can't be gone, I have to get her back"));
				}
				if(this.gameObject.name == "StoryCollider2"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Is that really her?"));
					//StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Is that her?"));
				}
				if(this.gameObject.name == "StoryCollider3"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I'll get you out of here, I promise"));
				}
				if(this.gameObject.name == "StoryCollider4"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Hide, I'll come get you after"));
				}
				if(this.gameObject.name == "StoryCollider5"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("You're not tired at all?"));
				}
				if(this.gameObject.name == "StoryColliderSwitch"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("A switch? Is there something we can put on it?"));
				}
				if(this.gameObject.name == "StoryCollider6"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Please, just let us go!"));
				}if(this.gameObject.name == "StoryColliderForceField"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("My sword isn't strong enough to break through..."));
				}if(this.gameObject.name == "StoryColliderAfterShock"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("Are you hurt?"));
				}
				if(this.gameObject.name == "StoryColliderCold"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("It's so cold...can you feel it?"));
				}
				if(this.gameObject.name == "StoryCollider7"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("We'll make it through, whatever the cost"));
				}
				if(this.gameObject.name == "StoryCollider8"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("I promise I'll never let anything happen to you ever again"));
				}
				if(this.gameObject.name == "StoryColliderWaterFall"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryText> ().FadeText ("The water is moving too fast for us to pass"));
				}
				if(this.gameObject.name == "StoryCollider9"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("I think I see a light!"));
				}
				if(this.gameObject.name == "StoryCollider10"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("We're almost home!"));
				}
				if(this.gameObject.name == "StoryCollider11"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("Wait...you're disappearing"));
				}
				if(this.gameObject.name == "StoryCollider12"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("No don't leave me!"));
				}
				if(this.gameObject.name == "StoryCollider13"){
					storyActivated = true;
					StartCoroutine(story.GetComponent<StoryScriptTunnel> ().FadeText ("This can't be for nothing!"));
				}
			}
		}
	}
}
