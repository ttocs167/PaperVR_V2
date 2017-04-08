using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float maxSpeed;

    // Use this for initialization
    void Start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
