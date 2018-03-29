using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgecol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SwitchScript.isUp)
        {
            this.GetComponent<MeshCollider>().enabled = false;
        } else
        {
            this.GetComponent<MeshCollider>().enabled = true;
        }
	}
}
