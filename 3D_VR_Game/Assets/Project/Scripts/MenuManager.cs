using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MenuManager : MonoBehaviour
{
    private bool _enabled = false;
    private GameObject _initialMenu;
    private GameObject _gameTypeSelectionMenu;
    private GameObject _roomSelectionMenu;
    private GameObject _gameModeSelectionMenu;
    private GameObject _difficultySelectionMenu;
    private GameObject _startMenu;

    void Awake()
    {
        _initialMenu = GameObject.Find("Initial Menu");
        _gameTypeSelectionMenu = GameObject.Find("Game Type Selection Menu");
        _roomSelectionMenu = GameObject.Find("Room Selection Menu");
        _gameModeSelectionMenu = GameObject.Find("Game Mode Selection Menu");
        _difficultySelectionMenu = GameObject.Find("Difficulty Selection Menu");
        _startMenu = GameObject.Find("Start Menu");
        _initialMenu.SetActive(true);
        _gameTypeSelectionMenu.SetActive(false);
        _roomSelectionMenu.SetActive(false);
        _gameModeSelectionMenu.SetActive(false);
        _difficultySelectionMenu.SetActive(false);
        _startMenu.SetActive(false);
        XRSettings.LoadDeviceByName("");
        XRSettings.enabled = false;
    }

    //Initial Menu
    public void handleClickPlay()
    {
        _initialMenu.SetActive(false);
        _gameTypeSelectionMenu.SetActive(true);
    }

    public void handleClickOptions()
    {
        //Options menu (audio volume)
    }

    public void handleClickExit()
    {
        Application.Quit();
    }

    //Game Type Selection Menu
    public void handleClickVocabulary()
    {
        SettingsManager.gameType = "Vocabulary";
        _gameTypeSelectionMenu.SetActive(false);
        _roomSelectionMenu.SetActive(true);
    }

    public void handleClickPhonetic()
    {

        SettingsManager.gameType = "Phonetic";
        _gameTypeSelectionMenu.SetActive(false);
        _difficultySelectionMenu.SetActive(true);
    }

    public void handleClickBackGameTypeSelection()
    {
        _gameTypeSelectionMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    //Room Selection Menu

    public void handleClickBedroom()
    {
        SettingsManager.room = "Bedroom";
        _roomSelectionMenu.SetActive(false);
        _gameModeSelectionMenu.SetActive(true);
    }

    public void handleClickKitchen()
    {
        SettingsManager.room = "Kitchen";
        _roomSelectionMenu.SetActive(false);
        _gameModeSelectionMenu.SetActive(true);
    }

    public void handleClickZoo()
    {
        SettingsManager.room = "Zoo";
        _roomSelectionMenu.SetActive(false);
        _gameModeSelectionMenu.SetActive(true);
    }

    public void handleClickBackRoomSelection()
    {
        _roomSelectionMenu.SetActive(false);
        _gameTypeSelectionMenu.SetActive(true);
    }

    //Game Mode Selection Menu

    public void handleClickLearning()
    {
        SettingsManager.gameMode = "Learning";
        _gameModeSelectionMenu.SetActive(false);
        _difficultySelectionMenu.SetActive(true);
    }

    public void handleClickTraining()
    {
        SettingsManager.gameMode = "Training";
        _gameModeSelectionMenu.SetActive(false);
        _difficultySelectionMenu.SetActive(true);
    }

    public void handleClickBackGameModeSelection()
    {
        _gameModeSelectionMenu.SetActive(false);
        _roomSelectionMenu.SetActive(true);
    }

    //Difficulty Selection Menu

    public void handleClickEasy()
    {
        SettingsManager.difficulty = "Easy";
        _difficultySelectionMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    public void handleClickMedium()
    {
        SettingsManager.difficulty = "Medium";
        _difficultySelectionMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    public void handleClickHard()
    {
        SettingsManager.difficulty = "Hard";
        _difficultySelectionMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    public void handleClickBackDifficultySelection()
    {
        if (SettingsManager.gameType == "Vocabulary")
        {
            _difficultySelectionMenu.SetActive(false);
            _gameModeSelectionMenu.SetActive(true);
        }
        else if (SettingsManager.gameType == "Phonetic")
        {
            _difficultySelectionMenu.SetActive(false);
            _gameTypeSelectionMenu.SetActive(true);
        }
    }

    //Start Menu
    public void handleClickStartGame()
    {
        if (SettingsManager.room == "Bedroom")
           SceneManager.LoadScene(2);
        if (SettingsManager.gameType == "Phonetic")
            SceneManager.LoadScene(3);

        //else if (SettingsManager.room == "Kitchen")
        //    SceneManager.LoadScene(2);
        //else if (SettingsManager.room == "Zoo")
        //    SceneManager.LoadScene(3);
       // SceneManager.LoadScene(2);
        Debug.Log(SettingsManager.room);
        Debug.Log(SettingsManager.gameMode);
        Debug.Log(SettingsManager.difficulty);
    }

    public void handleClickBackStartMenu()
    {
        _startMenu.SetActive(false);
        _difficultySelectionMenu.SetActive(true);
    }
    
    //public void EnableVR()
    //{
    //    XRSettings.LoadDeviceByName("Cardboard");
    //    _enabled = true;
    //}



    //public void Update()
    //{
    //    if (_enabled)
    //    {
    //        XRSettings.enabled = true;
    //        _enabled = false;
    //    }
    //}
}
