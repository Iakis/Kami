using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneStart : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			SceneManager.LoadScene ("cutscene", LoadSceneMode.Single);
		}
	}
}
