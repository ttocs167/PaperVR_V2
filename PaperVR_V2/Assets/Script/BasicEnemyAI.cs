using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {
    private GameObject player;
    public Rigidbody rgbd;
    private float maxSpeed;
    public float force = 10f;
    private Vector3 direction;
    public float stoppingDistance = 1f;
    public int aiMode = 0;
    // Use this for initialization
    void Start () {
        player = Camera.main.gameObject;
        rgbd = this.GetComponent<Rigidbody>();
        maxSpeed = this.GetComponent<EnemyStats>().maxSpeed;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        Vector3 vel = rgbd.velocity;
        Vector3 del = -this.transform.position + player.transform.position;
        Vector3 delForward = new Vector3(del.x, 0, del.z);
        direction = delForward / delForward.magnitude;
        this.transform.forward = delForward;
        switch(aiMode)
        {
            case 0:
                if (del.magnitude >= stoppingDistance)
                {
                    if (vel.magnitude >= maxSpeed)
                    {
                        if (vel.magnitude != 0)
                        {
                            vel = (vel / vel.magnitude) * maxSpeed;
                        }

                        rgbd.velocity = vel;
                    }
                    else
                    {
                        rgbd.AddForce(delForward * force);
                    }
                }
                else
                {
                    Debug.Log("Barry is within attack distance");
                    // Attack
                    aiMode = 1;
                }
                break;
            case 1:
                
                break;
        }



        


    }
}
