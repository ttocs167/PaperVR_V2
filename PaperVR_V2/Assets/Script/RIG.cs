using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIG : MonoBehaviour {
    public GameObject elevator = null;
    public float y_offset = 0.48f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(elevator!=null)
        {
            Vector3 newPos = elevator.transform.position;
            this.transform.position = new Vector3(newPos.x, newPos.y + y_offset, newPos.z);
        }
	}

}
