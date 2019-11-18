using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    private bool _enabled;
    private bool _load;
    // Start is called before the first frame update
    void Awake()
    {
        XRSettings.LoadDeviceByName("");
        XRSettings.enabled = false;
        _enabled = false;
        _load = false;
    }

    public void EnableVR()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        _enabled = true;
    }

    public void Update()
    {
        if (_load)
        {
            SceneManager.LoadScene(1);
        }
        if (_enabled)
        {
            XRSettings.enabled = true;
            _load = true;
        }
    }
}
