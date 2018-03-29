using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall : MonoBehaviour {

    ParticleSystem water;
    ParticleSystem splash;
    ParticleSystem icebreak;
    public bool isFreezed;
    public bool freezing;
    public float breakSpeed = 10f;

    float t;
    float lerpedspeed;

    // Use this for initialization
    void Start () {
        water = GameObject.Find("PSWater").GetComponent<ParticleSystem>();
        icebreak = GameObject.Find("iceBreak").GetComponent<ParticleSystem>();
        isFreezed = water.isPaused;
        icebreak.playbackSpeed = breakSpeed;
        freezing = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (water != null)
        {
            isFreezed = water.isPaused;
        }
        if (freezing && water.playbackSpeed > 0.1)
        {
            freeze();
        } else if (water.playbackSpeed <= 0.1)
        {
            isFreezed = true;
            water.Pause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ice")
        {
            freezing = true;
        }
    }

    void freeze()
    {
        t += Time.deltaTime * 0.5f;
        lerpedspeed = Mathf.Lerp(1, 0.01f, t);
        water.playbackSpeed = lerpedspeed;
    }

    void smash()
    {
        Destroy(water);
        Destroy(splash);
        icebreak.Play();
    }
}
