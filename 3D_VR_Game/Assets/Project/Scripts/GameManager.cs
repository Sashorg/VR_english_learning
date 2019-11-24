using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    private bool _enabled;
    public GameObject button;
    private GameObject canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GameObject.Find("Canvas (1)");
     
        XRSettings.LoadDeviceByName("");
        XRSettings.enabled = false;
        _enabled = false;
    }

    public void EnableVR()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        _enabled = true;
        button.SetActive(false);
        canvas.SetActive(true);
        Debug.Log("Enabled");
        

    }



    public void Update()
    {
        if (_enabled)
        {
            XRSettings.enabled = true;
            _enabled = false;
        }
    }
}
