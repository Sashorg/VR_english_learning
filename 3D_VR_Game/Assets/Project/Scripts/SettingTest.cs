using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SettingsManager.gameType);
        Debug.Log(SettingsManager.room);
        Debug.Log(SettingsManager.gameMode);
        Debug.Log(SettingsManager.difficulty);
    }
}
