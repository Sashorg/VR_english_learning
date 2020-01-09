using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _initialScreen, _levelSelection;

    [SerializeField]
    private Text _gameModeText, _roomText, _gameTypeText, _difficultyText;

    [SerializeField]
    private Dropdown _gameModeDropdown, _roomDropdown, _gameTypeDropdown, _difficultyDropdown;

    private void Start()
    {
        SettingsManager.gameMode = _gameModeText.text;
        SettingsManager.room = _roomText.text;
        SettingsManager.gameType = _gameTypeText.text;
        SettingsManager.difficulty = _difficultyText.text;
    }

    public void onClickPlay()
    {
        _initialScreen.SetActive(false);
        _levelSelection.SetActive(true);
    }

    public void onClickExit()
    {
        Application.Quit();
    }

    public void onGameModeChange(int mode)
    {
        SettingsManager.gameMode = _gameModeText.text;

        if(_gameModeText.text == "Phonetics")
        {
            _roomDropdown.interactable = false;
            _roomText.text = "Phonetics Room";
            SettingsManager.room = "Phonetics Room";
            _gameTypeDropdown.interactable = false;
            _gameTypeText.text = "Training";
            SettingsManager.gameType = "Training";
        }

        if (_gameModeText.text == "Vocabulary")
        {
            _roomDropdown.interactable = true;
            _roomText.text = "Bedroom";
            SettingsManager.room = "Bedroom";
            _gameTypeDropdown.interactable = true;
            _gameTypeText.text = "Training";
            SettingsManager.gameType = "Training";
        }
    }

    public void onLevelChange(int mode)
    {
        SettingsManager.room = _roomText.text;
    }

    public void onGameTypeChange(int mode)
    {
        SettingsManager.gameType = _gameTypeText.text;
    }

    public void onDifficultyChange(int mode)
    {
        SettingsManager.difficulty = _difficultyText.text;
    }

    public void onClickStart()
    {
        //Load Right Scene depending on SettingsManager configuration
        print("Game Mode: " + SettingsManager.gameMode);
        print("Room: " + SettingsManager.room);
        print("Game Type: " + SettingsManager.gameType);
        print("Difficulty: " + SettingsManager.difficulty);
    }
}
