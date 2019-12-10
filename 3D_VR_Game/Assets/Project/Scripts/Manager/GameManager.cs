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
    public GameObject chair;
    public GameObject table;
    public GameObject printer;
    public GameObject bed;
    public GameObject speakers;
    public GameObject closet;
    public GameObject bin;

    public GameObject clock;
    public GameObject mouse;
    public GameObject lamp;
    public GameObject fan;

    public GameObject guitar;
    public GameObject laptop;
    public GameObject mug;
    public GameObject PC;
    public GameObject pen;
    public GameObject phone;
    public GameObject photo;
    public GameObject plant;


    //ZOO
    public GameObject ant;
  
    public GameObject bear;
    public GameObject bird;
    public GameObject butterfly;
    public GameObject camel;
    public GameObject chameleon;
    public GameObject chicken;
    public GameObject crab;

    public GameObject deer;
    public GameObject dog;
    public GameObject elephant;
    public GameObject horse;

    public GameObject panda;
    public GameObject rabbit;
    public GameObject rhino;
    public GameObject squirrel;


    public GameObject VRglasses;
    public GameObject ant_pants;
    public GameObject box_ox;
    public GameObject dice_ice;
    public GameObject eight_gate;
    public GameObject pin_bin;
    public GameObject tey_key;
    // Start is called before the first frame update
    void Awake()
    {
        ObjectPoolingManager.Instance.CreatePool(table, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(chair, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(closet, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(bed, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(printer, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(speakers, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(bin, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(fan, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(clock, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(lamp, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(mouse, 3, 4);

        ObjectPoolingManager.Instance.CreatePool(guitar, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(laptop, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(mug, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(PC, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(pen, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(phone, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(photo, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(plant, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(VRglasses, 3, 4);


        ObjectPoolingManager.Instance.CreatePool(ant_pants, 1, 2);
        ObjectPoolingManager.Instance.CreatePool(box_ox, 1, 2);
        ObjectPoolingManager.Instance.CreatePool(dice_ice, 1, 2);
        ObjectPoolingManager.Instance.CreatePool(eight_gate, 1, 2);
        ObjectPoolingManager.Instance.CreatePool(pin_bin, 1, 2);
        ObjectPoolingManager.Instance.CreatePool(tey_key, 1, 2);


        //ZOO OBJECTS

        ObjectPoolingManager.Instance.CreatePool(ant, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(bear, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(bird, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(butterfly, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(camel, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(chameleon, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(chicken, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(crab, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(deer, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(dog, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(elephant, 3, 4);

        ObjectPoolingManager.Instance.CreatePool(horse, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(panda, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(rabbit, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(rhino, 3, 4);
        ObjectPoolingManager.Instance.CreatePool(squirrel, 3, 4);
      


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
