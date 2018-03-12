using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {

    public GameObject target;
    GameObject slash;
    Vector3 pos;
    
    Quaternion rot;
    [SerializeField]
    float x, z;
    float dist;

    Transform obj;
    ParticleSystem ps;
	void Start()
    {
        obj = transform.GetChild(0);
        ps = obj.gameObject.GetComponent<ParticleSystem>();
        
    }
	// Update is called once per frame
	void Update () {
        targets(gameObject.transform.position, 7);
        if (target != null)
        {
            dist = Vector3.Distance(target.transform.position, transform.position);
            if (dist <= 6)
            {
                if (Input.GetButtonUp("XButton"))
                {
                    attack();
                }
            }
        }
	}

    void attack()
    {
        target.GetComponent<OniAI>().damage();
        ps.Emit(1);
        var heading = target.transform.position - gameObject.transform.position;
        heading.y = 0;
        var rot = Quaternion.LookRotation(heading);
        transform.rotation = rot;
        pos = target.transform.position + (gameObject.transform.position - target.transform.position) / 1.5f;
        Vector3 pos2 = new Vector3(pos.x, transform.position.y + 3f, pos.z);
        int a = Random.Range(0, 3);
        if (a == 0)
        {
            slash1(pos2);
            return;
        } else if (a == 1) 
        {
            slash2(pos2);
            return;
        } else if (a == 2)
        {
            slash3(pos2);
            return;
        }    
    }

    void targets(Vector3 center, float radius)
    {
        int layerMask = 1 << 9;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, layerMask);
        int i = 0;
        float mindist = 99;
        float dis = 0;
        while (i < hitColliders.Length)
        {
            dis = Vector3.Distance(gameObject.transform.position, hitColliders[i].gameObject.transform.position);
            if (dis < mindist)
            {
                target = hitColliders[i].gameObject;
            }
            return;
        }
    }

    void slash1(Vector3 pos)
    {
        Vector3 heading = Vector3.Normalize(target.transform.position - gameObject.transform.position);
        rot = Quaternion.LookRotation(heading);
        Quaternion rott = Quaternion.Euler(new Vector3(90, rot.eulerAngles.y, 0));

        GameObject go = (GameObject)Instantiate(Resources.Load("slash", typeof(GameObject)), pos, rott);
        Destroy(go, 0.5f);
    }

    void slash2(Vector3 pos)
    {
        Vector3 heading = Vector3.Normalize(target.transform.position - gameObject.transform.position);
        rot = Quaternion.LookRotation(heading);
        Quaternion rott = Quaternion.Euler(new Vector3(-50, rot.eulerAngles.y, 180));

        GameObject go = (GameObject)Instantiate(Resources.Load("slash", typeof(GameObject)), pos, rott);
        Destroy(go, 0.5f);
    }

    void slash3(Vector3 pos)
    {
        Vector3 heading = Vector3.Normalize(target.transform.position - gameObject.transform.position);
        rot = Quaternion.LookRotation(heading);
        Quaternion rott = Quaternion.Euler(new Vector3(240, rot.eulerAngles.y, 200));

        GameObject go = (GameObject)Instantiate(Resources.Load("slash", typeof(GameObject)), pos, rott);
        Destroy(go, 0.5f);
    }
}
