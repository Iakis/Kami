using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall : MonoBehaviour {

    public ParticleSystem top,left,right;
    public bool isFreezed;
    public bool freezing;
    public float breakSpeed = 10f;

    float t;
    float lerpedspeed;
    Color lerpedcolor;

    public static waterfall w;

    public static waterfall Get()
    {
        return w;
    }

    waterfall()
    {
        w = this;
    }

    // Use this for initialization
    void Start () {
        isFreezed = top.isPaused;
        freezing = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (top != null)
        {
            isFreezed = top.isPaused;
        }
        if (freezing && top.playbackSpeed > 0.1)
        {
            freeze();
        } else if (top.playbackSpeed <= 0.1)
        {
            if (!isFreezed)
            {
                isFreezed = true;
                top.Pause();
                left.Pause();
                right.Pause();
                left.tag = "fall";
                right.tag = "fall";
            }
            
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
        lerpedcolor = Color.Lerp(top.startColor, Color.white, t);
        top.playbackSpeed = lerpedspeed;
        left.playbackSpeed = lerpedspeed;
        right.playbackSpeed = lerpedspeed;

        top.startColor = lerpedcolor;
        left.startColor = lerpedcolor;
        right.startColor = lerpedcolor;
    }

    public void smash()
    {
        Destroy(left);
        Destroy(right);
    }
}
