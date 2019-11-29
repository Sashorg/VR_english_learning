using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MenuManager : MonoBehaviour
{
    private bool _enabled = false;
    private GameObject _initialMenu;
    private GameObject _roomSelectionMenu;
    private GameObject _gameModeSelectionMenu;
    private GameObject _difficultySelectionMenu;
    private GameObject _startMenu;

    void Awake()
    {
        _initialMenu = GameObject.Find("Initial Menu");
        _roomSelectionMenu = GameObject.Find("Room Selection Menu");
        _gameModeSelectionMenu = GameObject.Find("Game Mode Selection Menu");
        _difficultySelectionMenu = GameObject.Find("Difficulty Selection Menu");
        _startMenu = GameObject.Find("Start Menu");
        _initialMenu.SetActive(true);
        _roomSelectionMenu.SetActive(false);
        _gameModeSelectionMenu.SetActive(false);
        _difficultySelectionMenu.SetActive(false);
        _startMenu.SetActive(false);
        XRSettings.LoadDeviceByName("");
        XRSettings.enabled = false;
    }

    public void handleClickPlay()
    {
        _initialMenu.SetActive(false);
        _roomSelectionMenu.SetActive(true);
    }

    public void handleClickOptions()
    {
        //Options menu (audio volume)
    }

    public void handleClickExit()
    {
        Application.Quit();
    }

    public void handleClickBedroom()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(1, )
    }

    public void handleClickKitchen()
    {

    }

    public void handleClickZoo()
    {

    }

    public void handleClickBack()
    {
        _initialMenu.SetActive(true);
        _roomSelectionMenu.SetActive(false);
    }
    public void EnableVR()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        _enabled = true;
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
