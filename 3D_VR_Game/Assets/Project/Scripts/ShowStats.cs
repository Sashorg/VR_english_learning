﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowStats : MonoBehaviour
{
    void Start()
    {
        Text totalTime, mistakes, mistakesPerWord;
        totalTime = GameObject.Find("Total Time Answer").GetComponent<Text>();
        mistakes = GameObject.Find("Mistakes Answer").GetComponent<Text>();
        mistakesPerWord = GameObject.Find("Mistakes per word Answer").GetComponent<Text>();
        totalTime.text = StatisticsManager._totalTimer.ToString() + "s";
        mistakes.text = StatisticsManager._mistakes.ToString();
        if (StatisticsManager._mistakes != 0)
        {
            foreach (KeyValuePair<string, int> kvp in StatisticsManager.wrongWordCounter)
            {
                mistakesPerWord.text += kvp.Key + " = " + kvp.Value + "   ";
            }
        }
        else
            mistakesPerWord.text = "None";
    }

    public void pressedBackToMenu()
    {
        StatisticsManager._mistakes = 0;
        StatisticsManager._totalTimer = 0;
        StatisticsManager.wrongWordCounter = new Dictionary<string, int>();
        SceneManager.LoadScene("Menu");
    }
}
