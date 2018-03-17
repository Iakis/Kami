﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampPrompt : MonoBehaviour {

	[SerializeField] private Image currentPrompt;
	public Sprite prompt;
	public GameObject Oni;
	private OniAI oniScript;
	public GameObject Sphere;

	void Start(){
		currentPrompt.enabled = false;
		oniScript = Oni.GetComponent<OniAI> ();
	}
		
	 private bool IsInView(GameObject toCheck)
     {
		Vector3 pointOnScreen = Camera.main.WorldToScreenPoint(toCheck.GetComponentInChildren<Renderer>().bounds.center);
 
         //Is in front
         if (pointOnScreen.z < 0)
         {
             return false;
         }
 
         //Is in FOV
         if ((pointOnScreen.x < 0) || (pointOnScreen.x > Screen.width) ||
                 (pointOnScreen.y < 0) || (pointOnScreen.y > Screen.height))
         {
             return false;
         }
 
         RaycastHit hit;
         Vector3 heading = toCheck.transform.position;
         Vector3 direction = heading.normalized;// / heading.magnitude;
         
		if (Physics.Linecast(Camera.main.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, out hit))
         {
             if (hit.transform.name != toCheck.name)
             {
                 /* -->
                 Debug.DrawLine(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, Color.red);
                 Debug.LogError(toCheck.name + " occluded by " + hit.transform.name);
                 */
                 return false;
             }
         }
         return true;
     }
     
	void Update(){
		// If Oni is visible and alive, show prompt
		Debug.Log(IsInView(Oni));
		Debug.Log (oniScript.health);
		if (IsInView(Oni) && oniScript.health > 0) {
			Debug.Log ("Is in view and Oni health > 0");
			currentPrompt.enabled = true;
			currentPrompt.sprite = prompt;
			Vector3 PromptPos = Camera.main.WorldToScreenPoint (this.transform.position);
			currentPrompt.GetComponent<RectTransform> ().position = PromptPos;
		} else {
			currentPrompt.enabled = false;
		}
	}
}
