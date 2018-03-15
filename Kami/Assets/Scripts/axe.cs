using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour {

    Transform parent;
    OniAI oni;
    BoxCollider col;
    static axe s_axe;

    axe()
    {
        s_axe = this;
    }

    public static axe Get()
    {
        return s_axe;
    }

    void Start () {
        parent = transform.root;
        oni = parent.GetComponent<OniAI>();
        oni.setAxe(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && oni.currentBaseState.fullPathHash == OniAI.attackState)
        {
            col.gameObject.GetComponent<Movement>().die();
        }
    }
}
