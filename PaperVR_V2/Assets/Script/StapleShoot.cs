using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StapleShoot : MonoBehaviour {
    public float projectileVelociity = 10f;
    public SteamVR_TrackedObject trackedObj;
    public GameObject prefab;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject obj = Instantiate(prefab, this.transform.position, this.transform.rotation);
            Destroy(obj, 7);
            Vector3 del = this.transform.forward;
            del = (del / del.magnitude) * projectileVelociity;
            obj.GetComponent<Rigidbody>().velocity = del;
        }
    }
}
