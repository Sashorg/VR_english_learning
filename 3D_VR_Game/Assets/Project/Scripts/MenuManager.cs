using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _initialScreen, _levelSelection;

    [SerializeField]
    private Text _phonOrVocText, _roomText, _gameTypeText, _difficultyText;

    [SerializeField]
    private Dropdown _gameModeDropdown, _roomDropdown, _gameTypeDropdown, _difficultyDropdown;

    private void Start()
    {
        SettingsManager.phonOrVoc = _phonOrVocText.text;
        SettingsManager.room = _roomText.text;
        SettingsManager.trainOrLearn = _gameTypeText.text;
        SettingsManager.difficulty = _difficultyText.text;
        XRSettings.LoadDeviceByName("");
        XRSettings.enabled = false;
        
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
        SettingsManager.phonOrVoc = _phonOrVocText.text;

        if(_phonOrVocText.text == "Phonetics")
        {
            _roomDropdown.interactable = false;
            _roomText.text = "Phonetics Room";
            SettingsManager.room = "Phonetics Room";
            _gameTypeDropdown.interactable = false;
            _gameTypeText.text = "Training";
            SettingsManager.trainOrLearn = "Training";
        }

        if (_phonOrVocText.text == "Vocabulary")
        {
            _roomDropdown.interactable = true;
            _roomText.text = "Bedroom";
            SettingsManager.room = "Bedroom";
            _gameTypeDropdown.interactable = true;
            _gameTypeText.text = "Training";
            SettingsManager.trainOrLearn = "Training";
        }
    }

    public void onLevelChange(int mode)
    {
        SettingsManager.room = _roomText.text;
    }

    public void onGameTypeChange(int mode)
    {
        SettingsManager.trainOrLearn = _gameTypeText.text;
    }

    public void onDifficultyChange(int mode)
    {
        SettingsManager.difficulty = _difficultyText.text;
    }

    public void onClickStart()
    {
        if (SettingsManager.phonOrVoc == "Phonetics")
            SceneManager.LoadScene("phonetics");
        else
        {
            if(SettingsManager.room == "Apartment")
                SceneManager.LoadScene("bedroom");
            if(SettingsManager.room == "Bedroom")
                SceneManager.LoadScene("bedroom");
            if (SettingsManager.room == "Kitchen")
                SceneManager.LoadScene("kitchen");
            if (SettingsManager.room == "Zoo")
                SceneManager.LoadScene("zoo");
            if (SettingsManager.room == "Bathroom")
                SceneManager.LoadScene("bathroom");
        }
    }
}
