using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Quaternion rotation;
    
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private Vector3 noY;

    static CameraFollow cam;

    CameraFollow()
    {
        cam = this;
    }

    public static CameraFollow Get()
    {
        return cam;
    }

    void Start () {
        //noY = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); 
	}

    void Awake()
    {
        rotation = transform.rotation;
    }


    // Update is called once per frame
    void Update () {
        transform.rotation = rotation;
        float y = target.transform.position.y - 34.25f;
        noY = new Vector3(target.position.x - 27 + offset.x + (1.1f * y), transform.position.y, target.position.z - 22 + offset.z + (1.3f * y));
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, noY, ref velocity, smoothSpeed);
        transform.position = smoothPosition;
		
	}

    public void setTarget(GameObject o)
    {
        target = o.transform;
    }
}
