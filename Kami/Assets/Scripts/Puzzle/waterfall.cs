using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall : MonoBehaviour {

    ParticleSystem water;
    ParticleSystem splash;
    ParticleSystem icebreak;
    public bool isFreezed;
    public float breakSpeed = 10f;

    // Use this for initialization
    void Start () {
        water = GameObject.Find("PSWater").GetComponent<ParticleSystem>();
        splash = GameObject.Find("splashes").GetComponent<ParticleSystem>();
        icebreak = GameObject.Find("iceBreak").GetComponent<ParticleSystem>();
        isFreezed = water.isPaused;
        icebreak.playbackSpeed = breakSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (water != null)
        {
            isFreezed = water.isPaused;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("ice"))
        {
            water.Pause();
            splash.Pause();
        }
        if (other.name == "Axe")
        {
            if (isFreezed)
            {
                Destroy(water);
                Destroy(splash);
                icebreak.Play();
            }
        }
    }
}
