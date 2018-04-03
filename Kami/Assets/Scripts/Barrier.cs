using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {


    public bool breakk;
    Color lerpedColor;
    Material m_Material;
    float t = 0.0f;
	bool breaking;
    // Use this for initialization
    void Start () {
        m_Material = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
		if (breakk)
        {
            t += Time.deltaTime;
			if (!breaking) {
				GameObject.Find("SpearCollide").GetComponent<AudioSource>().Play();
				breaking = true;
			}
            lerpedColor = Color.Lerp(m_Material.color, Color.black, t);
            m_Material.SetColor("_Depthcolor", lerpedColor);
        }
	}

    public void breakB()
    {
        breakk = true;
        Destroy(gameObject, 1f);
    }
}
