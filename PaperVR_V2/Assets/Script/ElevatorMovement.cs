using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour {
    public float elevatorSpeed = 1f;
    public Transform[] points;
    private int currentPoint;
    private bool goingup = false;
    private Vector3 dir;
    private int backtrack = 1;
    private Rigidbody rgbd;
    

	// Use this for initialization
	void Start ()
    {
        transform.position = points[0].position;
        currentPoint = 0;
        rgbd = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (goingup)
        {
            if((transform.position - points[currentPoint].position).magnitude<0.1)
            {
                transform.position = points[currentPoint].position;
                goingup = false;
                rgbd.velocity = new Vector3(0, 0, 0);
            }
        }
		
	}
    public void nextPoint()
    {
        if(!goingup)
        {            
            
            currentPoint += (backtrack);
            goingup = true;
            dir = points[currentPoint].position - points[currentPoint - backtrack].position;
            dir = dir / dir.magnitude;
            rgbd.velocity = dir * elevatorSpeed;
            if ((currentPoint >= (points.Length - 1)) || (currentPoint <= 0))
            {
                backtrack *= -1;
            }
        }
        
    }
}
