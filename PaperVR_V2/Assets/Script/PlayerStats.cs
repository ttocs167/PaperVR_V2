using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public float maxHealth = 6;
    public float currenthealth;
    public float damage = 1;

	// Use this for initialization
	void Start ()
    {
        currenthealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
