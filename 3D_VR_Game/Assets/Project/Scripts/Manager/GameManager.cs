using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.UI;

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

    //Learning Mode
    private GameObject _object, _score, _find;
    private Text _objectText;

    // Start is called before the first frame update
    void Awake()
    {
        if (SettingsManager.gameMode == "Learning")
        {
            _object = GameObject.Find("UI_Object");
            _score = GameObject.Find("UI_Score");
            _find = GameObject.Find("UI_find");
            _objectText = GameObject.Find("UI_Object").GetComponent<Text>();

            _score.SetActive(false);
            _find.SetActive(false);
            _objectText.text = "Look at object!";
        }
        else
        {
            StatisticsManager.startTimer();
        }

        ObjectPoolingManager.Instance.CreatePool(table, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(chair, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(closet, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(bed, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(printer, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(speakers, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(bin, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(fan, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(clock, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(lamp, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(mouse, 6, 10);

        ObjectPoolingManager.Instance.CreatePool(guitar, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(laptop, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(mug, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(PC, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(pen, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(phone, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(photo, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(plant, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(VRglasses, 6, 10);


        ObjectPoolingManager.Instance.CreatePool(ant_pants, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(box_ox, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(dice_ice, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(eight_gate, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(pin_bin, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(tey_key, 6, 10);


        //ZOO OBJECTS

        ObjectPoolingManager.Instance.CreatePool(ant, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(bear, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(bird, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(butterfly, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(camel, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(chameleon, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(chicken, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(crab, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(deer, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(dog, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(elephant, 6, 10);

        ObjectPoolingManager.Instance.CreatePool(horse, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(panda, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(rabbit, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(rhino, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(squirrel, 6, 10);

        
    }

}
