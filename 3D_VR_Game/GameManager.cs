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
    public Transform next_road_position;
    public GameObject Chair;
    public GameObject Table;
    public GameObject Closet;
    public GameObject Bed;
    public GameObject Speakers;
    public GameObject Printer;

    // Start is called before the first frame update
    void Awake()
    {
        ObjectPoolingManager.Instance.CreatePool(Chair, 2, 3);
        ObjectPoolingManager.Instance.CreatePool(Table, 2, 3);
        ObjectPoolingManager.Instance.CreatePool(Closet, 2, 3);
        ObjectPoolingManager.Instance.CreatePool(Bed, 2, 3);
        ObjectPoolingManager.Instance.CreatePool(Speakers, 2, 3);
        ObjectPoolingManager.Instance.CreatePool(Printer, 2, 3);

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
