﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBarryAI : MonoBehaviour {
    private GameObject player;
    public Rigidbody rgbd;
    public float maxSpeed = 0.5f;
    public float force = 10f;
    public float stoppingDistance = 0.1f;
    private float distance;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        player = Camera.main.gameObject;
        rgbd = this.GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
        Vector3 del = player.transform.position - this.transform.position;
        distance = del.magnitude;
        Vector3 delForward = new Vector3(del.x, 0, del.z);
        direction = delForward / delForward.magnitude;

        this.transform.forward = delForward;
        if (distance > stoppingDistance)
        {
            rgbd.AddForce(direction * force);
            Vector3 vel = rgbd.velocity;
            if (vel.magnitude > maxSpeed)
            {
                vel = (vel / vel.magnitude) * maxSpeed;
                rgbd.velocity = vel;
            }
        }
        else
        {
            Debug.Log("Barry is within attack distance");
            // Attack
        }

    }

}
