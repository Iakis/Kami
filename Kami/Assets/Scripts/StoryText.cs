using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

	private float fadeTime = 2f;

	// Use this for initialization
	void Start () {
		//Story.color = new Color (255, 255, 255, 0);
		//Debug.Log (Story.color.a);
		StartCoroutine(FadeText("I have to find her..."));
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public IEnumerator FadeText(string storyText){
		GetComponent<Text>().text = storyText;
		Debug.Log("Fading story text");
		StartCoroutine(FadeTextToFullAlpha(2f, GetComponent<Text>()));
		yield return new WaitForSeconds(3);
		StartCoroutine (FadeTextToZeroAlpha(2f, GetComponent<Text>()));
	}
}
