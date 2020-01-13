using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRDisabler : MonoBehaviour
{
        void Start()
        {
            XRSettings.LoadDeviceByName("");
            XRSettings.enabled = false;
        }
}
