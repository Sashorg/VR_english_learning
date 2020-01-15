using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VrEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (XRSettings.loadedDeviceName == "")
            StartCoroutine(LoadDevice("Cardboard"));    
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }

   
}
