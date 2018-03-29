using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public bool isActivated;
	public GameObject lightObject;
	Light light;
    private GameObject[] respawns;

	// Use this for initialization
	void Start () {
        isActivated = false;
		light = lightObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isActivated = true;
			light.enabled = true;
            respawns = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (GameObject respawn in respawns)
            {
                if (respawn.GetComponent<Respawn>().isActivated && respawn.name != this.name)
                {
                    respawn.GetComponent<Respawn>().isActivated = false;
                }
            }
        }
    }
}
