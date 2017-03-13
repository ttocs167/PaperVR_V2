using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject rig;
	// Use this for initialization
	void Start () {
        rig = GameObject.FindWithTag("Rig");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Floor")
        {
            float rigX = Mathf.Round(this.transform.position.x/3) * 3.0f;
            float rigZ = Mathf.Round(this.transform.position.z / 3) * 3.0f;
            rig.transform.position = new Vector3(rigX, 0, rigZ);
            Destroy(this.gameObject);
        }
    }
}
