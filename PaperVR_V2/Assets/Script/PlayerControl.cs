using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public GameObject[] items;
    private SteamVR_Controller.Device device;
    public SteamVR_TrackedController controller;
    int currentObj =0;
    int direction = 0;
    // Use this for initialization
    void Start ()
    {
        items[currentObj].SetActive(true);
        device = SteamVR_Controller.Input((int)trackedObj.index);        
        
    }
	
    private void Controller_PadClicked()
    {
        if(device.GetAxis().x!=0||device.GetAxis().y!=0)
        {
            Debug.Log(device.GetAxis().x + " " + device.GetAxis().y);

            if (device.GetAxis().x > 0.5)
            {
                direction = 0;
            }
            else if (device.GetAxis().x < -0.5)
            {
                direction = 1;
            }
            else if (device.GetAxis().y > 0.5)
            {
                direction = 2;
            }
            else if (device.GetAxis().y < -0.5)
            {
                direction = 3;
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (device.GetAxis().x != 0 || device.GetAxis().y != 0)
        {
            Controller_PadClicked();
        }

            if (currentObj!=direction)
        {
            items[currentObj].SetActive(false);
            currentObj = direction;
            items[currentObj].SetActive(true);
        }
            
        
    }
}
