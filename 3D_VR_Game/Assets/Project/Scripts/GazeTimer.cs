using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GazeTimer : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2.0f;
    bool _gvrStatus;
    float _gvrTimer;

    // Start is called before the first frame update
    void Start()
    {
        _gvrStatus = false;
        _gvrTimer = 0;
        imgGaze.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gvrStatus)
        {
            _gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = _gvrTimer / totalTime;
        }
    }

    public void gvrOn()
    {
        _gvrStatus = true;
    }

    public void gvrOff()
    {
        _gvrStatus = false;
        _gvrTimer = 0;
        imgGaze.fillAmount = 0f;
    }

}
