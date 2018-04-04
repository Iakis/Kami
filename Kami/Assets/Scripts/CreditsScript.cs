using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {

	public Text story;

	public Image fade;
	public Animator anim;

	public AudioSource source;
	public AudioClip start;

	public AudioClip GraveMusic;

	// Use this for initialization
	void Start () {
		AudioListener.pause = false;
		StartCoroutine (FadeEnd ());
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("StartButton"))
		{
			StartCoroutine (Fading ());
			StartCoroutine (FadeVolume ());
		}
	}

	IEnumerator FadeEnd(){
		yield return new WaitForSeconds(2f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("\"I'm sorry I couldn't save you...\""));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("\"But I'm glad we could share one more adventure together, goodbye\""));
		yield return new WaitForSeconds(7f);
		StartCoroutine (FadeVolume ());
		yield return new WaitForSeconds(3f);
		source.clip = GraveMusic;
		source.volume = 1;
		source.Play ();
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("This game was created as part of a Video Game Design Project"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("University of Toronto Students (Computer Science): "));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Justin Li"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Jiachen (Lorinda) He"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Meeral Qureshi"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("OCAD Students (Art): "));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Sachin Jayaram"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Joyce Ong"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Becky Wu"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("University of Toronto (Faculty of Music): "));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Keyan Emami"));
		yield return new WaitForSeconds(7f);
		StartCoroutine(story.GetComponent<CreditsScript> ().FadeText ("Kami: The Lost Soul"));
		yield return new WaitForSeconds(7f);
		SceneManager.LoadScene ("TitleScreen", LoadSceneMode.Single);
	}

	IEnumerator Fading(){
		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fade.color.a == 1);
		SceneManager.LoadScene ("TitleScreen", LoadSceneMode.Single);
	}

	IEnumerator FadeVolume(){
		float startVolume = source.volume;
		while (source.volume > 0) {
			source.volume -= startVolume * Time.deltaTime / 3.0f;

			yield return null;
		}

		source.Stop ();
	}

	public IEnumerator FadeTextToFullAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadeTextToZeroAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadePanelToZero(float t, Image i){
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0.9f);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadePanelToFullAlpha(float t, Image i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 0.9f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadeText(string storyText){
		GetComponent<Text>().text = storyText;
		Debug.Log("Fading story text");
		StartCoroutine(FadeTextToFullAlpha(2f, GetComponent<Text>()));
		yield return new WaitForSeconds(3);
		StartCoroutine (FadeTextToZeroAlpha(2f, GetComponent<Text>()));
	}
}
