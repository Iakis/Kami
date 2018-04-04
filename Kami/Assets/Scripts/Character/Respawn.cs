using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public bool isActivated;
	public GameObject lightObject;
	private AudioSource respawnSound;
	bool lit;
	Light light;
    private GameObject[] respawns;

	// Use this for initialization
	void Start () {
        isActivated = false;
		light = lightObject.GetComponent<Light>();
		respawnSound = GameObject.Find("RespawnSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {	
            isActivated = true;
            StartCoroutine("lightlamp");
			if (!lit) {
				respawnSound.Play();
				lit = true;
			}
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

    IEnumerator lightlamp()
    {
        light.enabled = true;
        while (light.intensity < 11.78)
        {
            light.intensity += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
