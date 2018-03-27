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
    static Movement nagi;
    new public Camera camera;
    float y, y2;

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
        nagi = Movement.Get();
        //noY = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); 
        
        y2 = nagi.gameObject.transform.position.y;
    }

    void Awake()
    {
        rotation = transform.rotation;
    }


    // Update is called once per frame
    void Update () {
        y = target.transform.position.y - 34.25f;
        transform.rotation = rotation;
        noY = new Vector3(target.position.x - 27 + offset.x + (1.1f * y), transform.position.y, target.position.z - 22 + offset.z + (1.3f * y));
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, noY, ref velocity, smoothSpeed);
        transform.position = smoothPosition;

        if (nagi.transform.position.y < 60) {
            camera.nearClipPlane = y2 - nagi.transform.position.y + 20;
        } else if (nagi.transform.position.y > 80)
        {
            camera.nearClipPlane = -120;
        } else
        {
            camera.nearClipPlane = -60;
        }
            
		
	}

    public void setTarget(GameObject o)
    {
        target = o.transform;
    }
}
