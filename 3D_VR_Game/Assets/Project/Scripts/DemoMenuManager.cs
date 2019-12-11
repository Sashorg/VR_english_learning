using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class DemoMenuManager : MonoBehaviour
{
    void Start()
    {
        XRSettings.LoadDeviceByName("");
        XRSettings.enabled = false;
    }

    public void handleClickZoo()
    {
        SceneManager.LoadScene(1);
    }

    public void handleClickBedroom()
    {
        SceneManager.LoadScene(2);
    }

    public void handleClickPhoneticTraining()
    {
        SceneManager.LoadScene(3);
    }

}
