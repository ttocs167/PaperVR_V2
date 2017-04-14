using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    LineRenderer line;
  
    void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = true;
	}

  
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.GetPoint(100));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //hit.transform.gameObject.GetComponent<Renderer>().material.SetFloat("_Tween", 1);
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Application.LoadLevel(1);
            }        
        }        
    }   
}
