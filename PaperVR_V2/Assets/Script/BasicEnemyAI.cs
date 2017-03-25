using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {
    private GameObject player;
    public Rigidbody rgbd;
    //public float maxSpeed = 0.5f;
    public float force = 10f;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
        player = Camera.main.gameObject;
        rgbd = this.GetComponent<Rigidbody>();        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float maxSpeed = this.GetComponent<EnemyStats>().maxSpeed;

        Vector3 del = -this.transform.position + player.transform.position;
        Vector3 delForward = new Vector3(del.x, 0,del.z);
        direction = delForward / delForward.magnitude;
        this.transform.forward = delForward;

        rgbd.AddForce(delForward * force);
        Vector3 vel = rgbd.velocity;
        if (vel.magnitude > maxSpeed)
        {
            vel = (vel / vel.magnitude) * maxSpeed;
            rgbd.velocity = vel;
        }
    }
}
