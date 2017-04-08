using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour {
    public float weaponDamage;

    // Use this for initialization
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("collision with tag: enemy");
            collision.gameObject.GetComponent<EnemyStats>().currentHealth -= weaponDamage;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
		
	}
}
