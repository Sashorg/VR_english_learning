using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : Singleton<StatisticsManager>
{
    private static float _totalTimer = 0f;
    private static int _mistakes = 0;
    private static bool _count = false;
    private static IDictionary<string, int> wrongWordCounter;

    void Start()
    {
        wrongWordCounter = new Dictionary<string, int>();
    }

    void Update()
    {
        if(_count)
            _totalTimer += Time.deltaTime;
    }

    public static void startTimer()
    {
        _count = true;
    }

    public static void stopTimer()
    {
        _count = false;
    }

    public static void countMistake()
    {
        _mistakes++;
    }

    public static void countWordMistake(string word)
    {
        if (wrongWordCounter.ContainsKey(word) == false)
            wrongWordCounter.Add(word, 1);
        else
            wrongWordCounter[word] = wrongWordCounter[word] + 1;
    }



    public static void gameOver()
    {
        Debug.Log("Total Time: " + _totalTimer);
        Debug.Log("Mistakes: " + _mistakes);
        foreach (KeyValuePair<string, int> kvp in wrongWordCounter)
        {
            print(kvp.Key + " = " + kvp.Value);
        }
    }

}
