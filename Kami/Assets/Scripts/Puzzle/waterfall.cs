using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterfall : MonoBehaviour {

    public ParticleSystem top,left,right;
    public bool isFreezed;
    public bool freezing;
    public float breakSpeed = 10f;

    float t;
    float lerpedspeed;
    Color lerpedcolor;

    public static waterfall w;
    public CanvasGroup flashWhite;
    private bool flash = false;
    //private CanvasRenderer flashPanel;

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
        flashWhite = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
        //flashPanel = GameObject.Find("Panel").GetComponent<CanvasRenderer>();
        //flashPanel.SetAlpha(200);
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
        if (flash)
        {
            flashWhite.alpha = flashWhite.alpha - Time.deltaTime*0.5f;
            if (flashWhite.alpha <= 0)
            {
                flashWhite.alpha = 0;
                flash = false;
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
        if (left != null && right != null)
        {
            flash = true;
            flashWhite.alpha = 1;
        }
        Destroy(left);
        Destroy(right);
    }
}
