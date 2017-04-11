using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public GameObject TeleportObj;
    public GameObject SwordObj;
    public GameObject StapleGunObj;
    public GameObject currentObj;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if(device.GetAxis().x!=0 || device.GetAxis().y != 0)
        {
            if(device.GetAxis().x>0)
            {
                Destroy(currentObj);
                currentObj = Instantiate(SwordObj, this.transform);
                currentObj.transform.parent = this.gameObject.transform;
            }
            else if(device.GetAxis().x>0)
            {
                Destroy(currentObj);
                currentObj = Instantiate(TeleportObj, this.transform);
                currentObj.transform.parent = this.gameObject.transform;
                currentObj.GetComponent<PlayerMovement>().trackedObj = trackedObj;
            }
            else if(device.GetAxis().y>0)
            {
                Destroy(currentObj);
                currentObj = Instantiate(StapleGunObj, this.transform);
                currentObj.transform.parent = this.gameObject.transform;
                currentObj.GetComponent<StapleShoot>().trackedObj = trackedObj;
            }
            else if (device.GetAxis().y<0)
            {
                Destroy(currentObj);
            }
        }
    }
}
