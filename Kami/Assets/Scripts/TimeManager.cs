using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float slowDownFactor = 0.05f;
	public float slowdownLength = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NormalSpeed(){
		Time.timeScale = 1f;
	}

	public void DoSlowMotion()
	{
		Time.timeScale = slowDownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
