using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfallCollider : MonoBehaviour {

    public bool isBroken;
    public ParticleSystem left, right;

	// Use this for initialization
	void Start () {
        isBroken = false;
        left = GameObject.Find("left").GetComponent<ParticleSystem>();
        right = GameObject.Find("right").GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (left == null && right == null)
        {
            gameObject.SetActive(false);
        }
    }
}
