using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int maxHealth = 6;
    public int currenthealth;
    public int damage = 1;

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
