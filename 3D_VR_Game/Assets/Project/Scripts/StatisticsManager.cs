using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatisticsManager : Singleton<StatisticsManager>
{
    public static float _totalTimer = 0f;
    public static int _mistakes = 0;
    private static bool _count = false;
    public static IDictionary<string, int> wrongWordCounter;
    private static IEnumerator _coroutine;

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
        GameObject[] go = changescen.GetDontDestroyOnLoadObjects();
        foreach (GameObject g in go)
        {
            print(g.name);
            for (int i = 0; i < g.transform.childCount; i++)
            {
                g.transform.GetChild(i).gameObject.SetActive(false);
            }
            //g.SetActive(false);
        }
        SceneManager.LoadScene("Statistics");
    }

}
