using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject rig;
    public float y_offset = 3f;
    public GameObject particle;
	// Use this for initialization
	void Start () {
        rig = GameObject.FindWithTag("Rig");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag =="Floor")
        {
            //float rigX = Mathf.Round(this.transform.position.x/3) * 3.0f;
            //float rigZ = Mathf.Round(this.transform.position.z / 3) * 3.0f;
            // rig.transform.position = new Vector3(rigX, 0, rigZ);
            Vector3 pos = collision.gameObject.transform.position;
            rig.transform.position = new Vector3(pos.x, pos.y + y_offset, pos.z);
            rig.GetComponent<RIG>().elevator = null;
            Instantiate(particle,  this.transform);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Elevator")
        {
            collision.gameObject.GetComponent<ElevatorMovement>().nextPoint();
            rig.GetComponent<RIG>().elevator = collision.gameObject;
            Vector3 pos = collision.gameObject.transform.position;
            rig.transform.position = new Vector3(pos.x, pos.y + y_offset, pos.z);
            Destroy(this.gameObject);
        }
    }
}
