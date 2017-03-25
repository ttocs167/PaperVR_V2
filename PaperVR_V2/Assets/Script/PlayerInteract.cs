using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public GameObject rig;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("boo");
    }
	
	// Update is called once per frame
	void Update ()
    {
        rig = GameObject.FindWithTag("Rig");
    }

    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.transform.tag == "healthPickup")
        {
            var device = SteamVR_Controller.Input((int)trackedObj.index);
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                rig.GetComponent<PlayerStats>().maxHealth ++;
                Destroy(collision.gameObject);
            }

        }
    }
}
