using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public GameObject throwObject;
    private Rigidbody rgbd;
    public SteamVR_TrackedObject trackedObj;
    public GameObject prefab;
    private float multiplier=10.0f;
    private Vector3 lastPosition;

    // Use this for initialization
    void Start () {
        rgbd = this.GetComponent<Rigidbody>();
        lastPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 thisPosition = this.transform.position;
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject obj = Instantiate(prefab, this.transform.position, Quaternion.identity);            
            Vector3 del = -lastPosition +thisPosition;
            obj.GetComponent<Rigidbody>().velocity = del/Time.fixedDeltaTime;
        }
        
        lastPosition = thisPosition;
	}
}
