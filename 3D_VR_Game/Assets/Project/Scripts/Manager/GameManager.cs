﻿using System.Collections;
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
    //Bath
    public GameObject socket;
    public GameObject towel_rail;
    public GameObject flush;
    public GameObject soup;
    public GameObject toilet;
    public GameObject toilet_paper;
    public GameObject shower;
    public GameObject toilet_brush;
    public GameObject vase;
    public GameObject towel;
    public GameObject sink;
    public GameObject shower_gel;
    public GameObject toothbrush;

    public GameObject VRglasses;
    public GameObject ant_pants;
    public GameObject box_ox;
    public GameObject dice_ice;
    public GameObject eight_gate;
    public GameObject pin_bin;
    public GameObject tey_key;
    //Kitchen
    public GameObject apples;
    public GameObject bowl;
    public GameObject candies;
    public GameObject cardboard_box;
    public GameObject coffee_grinder;
    public GameObject cooking_spoon;
    public GameObject cooking_shovel;
    public GameObject cup;
    public GameObject fork;
    public GameObject glass;
    public GameObject jar;
    public GameObject kettle;
    public GameObject kitchen_sink;

    public GameObject knife;
    public GameObject oven;
    public GameObject pan;
    public GameObject plate;
    public GameObject spoon;
    public GameObject stove;
    public GameObject teapot;
    public GameObject teaspoon;
    public GameObject wine;

    //Learning Mode
    private GameObject _object, _score, _find;
    private Text _objectText;

    // Start is called before the first frame update
    void Awake()
    {
        if (SettingsManager.trainOrLearn == "Learning")
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

        //BATH OBJECTS
        ObjectPoolingManager.Instance.CreatePool(flush, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(socket, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(towel_rail, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(soup, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(toilet, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(toilet_brush, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(toilet_paper, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(shower, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(vase, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(shower_gel, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(towel, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(sink, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(toothbrush, 6, 10);
        //KITCHEN OBJECTS
        ObjectPoolingManager.Instance.CreatePool(apples, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(bowl, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(candies, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(cardboard_box, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(coffee_grinder, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(cooking_shovel, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(cooking_spoon, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(cup, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(fork, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(glass, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(jar, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(kettle, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(kitchen_sink, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(knife, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(oven, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(pan, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(plate, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(spoon, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(stove, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(teapot, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(teaspoon, 6, 10);
        ObjectPoolingManager.Instance.CreatePool(wine, 6, 10);

    }

}
