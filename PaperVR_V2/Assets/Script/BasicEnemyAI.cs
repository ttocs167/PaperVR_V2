using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {
    private GameObject player;
    public Rigidbody rgbd;
    public float maxSpeed = 0.5f;
    public float force = 5f;

	// Use this for initialization
	void Start () {
        player = Camera.main.gameObject;
        rgbd = this.GetComponent<Rigidbody>();        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 del = -this.transform.position + player.transform.position;
        Vector3 delForward = new Vector3(del.x, 0,del.z);
        this.transform.forward = delForward;
        rgbd.AddForce(del * force);
        Vector3 vel = rgbd.velocity;
        if (vel.magnitude > maxSpeed)
        {
            vel = (vel / vel.magnitude) * maxSpeed;
            rgbd.velocity = vel;
        }
    }
}
