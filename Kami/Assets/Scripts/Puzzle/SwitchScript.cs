using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public Transform bridge;
    public bool isTriggered;
    public Vector3 originPosition;
    public static bool isUp;
    public Transform River;
    private float rangeMin, rangeMax;
	private Rigidbody rb;

    private Vector3 up;
    private Vector3 down;
    private Vector3 lerp;
    private float t;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        isTriggered = false;
        originPosition = bridge.transform.position;
        isUp = false;
        up = new Vector3(3, 0.4f, 3);
        down = new Vector3(3, 0.1f, 3);
        //UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }
	
	// Update is called once per frame
	void Update () {
        rb.WakeUp();
		if (isTriggered)
        {
            t += 0.01f * Time.deltaTime;
            lerp = Vector3.Lerp(this.transform.localScale, down, t);
            this.transform.localScale = lerp;
            if (bridge.transform.position.y < originPosition.y+2.5f)
            {
                bridge.transform.Translate(Vector3.up * Time.deltaTime);
            } else
            {
                if (!isUp)
                {
                    isUp = true;
                }
            }
        }
        else
        {
            t += 0.1f * Time.deltaTime;
            lerp = Vector3.Lerp(this.transform.localScale, up, t);
            this.transform.localScale = lerp;
            if (bridge.transform.position.y >= originPosition.y)
            {
                bridge.transform.Translate(Vector3.down * Time.deltaTime);
            }

            isUp = false;
        }
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.layer == 10 && col.gameObject.tag != "Enemy")
        {
            Debug.Log(string.Format("being stepped by {0}", col.gameObject.name));
            isTriggered = true;
            //transform.Translate(Vector3.down * 0.1f);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.layer == 10 && col.gameObject.tag != "Enemy")
        {
            Debug.Log(string.Format("{0} just left", col.gameObject.name));
            isTriggered = false;
            //transform.Translate(Vector3.up * 0.01f);
        }
    }
}
