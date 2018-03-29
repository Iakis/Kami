using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public Transform bridge;
    public bool isTriggered;
    public Vector3 originPosition;
    public bool isUp;
    public bool isDown;
    public Transform River;
    private float rangeMin, rangeMax;
	private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        isTriggered = false;
        originPosition = bridge.transform.position;
        isUp = false;
        isDown = true;
        //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }
	
	// Update is called once per frame
	void Update () {
        rb.WakeUp();
		if (isTriggered)
        {
            if (bridge.transform.position.y < originPosition.y+5f)
            {
                bridge.transform.Translate(Vector3.up * Time.deltaTime);
            } else
            {
                if (!isUp)
                {
                    //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
                    isUp = true;
                    isDown = false;
                }
            }
        }
        else
        {
            //if (bridge.transform.position.y > originPosition.y)
            //{
            //    bridge.transform.Translate(Vector3.down * Time.deltaTime);

            //} else
            //{
            //    if (!isDown)
            //    {
            //        //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
            //        isDown = true;
            //        isUp = false;
            //    }
            //}
        }
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == 12 || col.gameObject.layer == 13)
        {
            Debug.Log(string.Format("being stepped by {0}", col.gameObject.name));
            isTriggered = true;
            //transform.Translate(Vector3.down * 0.1f);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 12 || col.gameObject.layer == 13)
        {
            Debug.Log(string.Format("{0} just left", col.gameObject.name));
            isTriggered = false;
            //transform.Translate(Vector3.up * 0.01f);
        }
    }
}
