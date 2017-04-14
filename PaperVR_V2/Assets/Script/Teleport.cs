using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject rig;
    public float y_offset = 3f;
    public GameObject particle;
    private Rigidbody rgbd;
    private float timer =0;
    private float killTimer = 7f;
	// Use this for initialization
	void Start () {
        rig = GameObject.FindWithTag("Rig");
        rgbd = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer>killTimer)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag =="Floor")
        {
            //float rigX = Mathf.Round(this.transform.position.x/3) * 3.0f;
            //float rigZ = Mathf.Round(this.transform.position.z / 3) * 3.0f;
            // rig.transform.position = new Vector3(rigX, 0, rigZ);
            //if(rgbd.velocity.y<=0)
            //{                
                Vector3 pos = collision.gameObject.transform.position;
                rig.transform.position = new Vector3(pos.x, pos.y + y_offset, pos.z);
                rig.GetComponent<RIG>().elevator = null;
                Instantiate(particle, this.transform);
            //}            
            Destroy(this.gameObject);            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(rgbd.velocity.y<=0)
        {
            if (collision.gameObject.tag == "Elevator")
            {
                collision.gameObject.GetComponent<ElevatorMovement>().nextPoint();
                rig.GetComponent<RIG>().elevator = collision.gameObject;
                Vector3 pos = collision.gameObject.transform.position;
                rig.transform.position = new Vector3(pos.x, pos.y + y_offset, pos.z);
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag == "Floor")
            {

                Debug.Log("DoIT");
                Vector3 pos = collision.gameObject.transform.position;
                Vector3 bounds = collision.gameObject.GetComponent<Collider>().bounds.extents;
                bounds.y = 0;
                Vector3 del = this.transform.position - pos - bounds;
                del.x = Mathf.Floor(del.x / 3) * 3.0f+1.5f;
                del.y = pos.y;
                del.z = Mathf.Floor(del.z / 3) * 3.0f+1.5f;
                del = del + pos + bounds;
                rig.transform.position = new Vector3(del.x, pos.y + y_offset, del.z);
                rig.GetComponent<RIG>().elevator = null;
                Instantiate(particle, this.transform);
                Destroy(this.gameObject);
                
            }
        }
        
    }

   
}
