using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {
    private float score = 0.0f;
	// Use this for initialization
	void Start () {
        Debug.Log("START");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        score++;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 100), score.ToString());
    }

}
