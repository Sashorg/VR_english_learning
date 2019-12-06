using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phonetics_Object_handler : MonoBehaviour
{
    public static string obj1;
    public static string obj2;
    public static string dev = "_";
    public static int dev_index;
    public static int full;
    static int passed = -1;

    public static string objectToShow;

    public static void _call(string str)
    {
        dev_index = str.IndexOf(dev) + 1;
        obj2 = str.Substring(dev_index);
        obj1 = str.Replace(dev + obj2, "");
        if(GetRandomNum(0,full) == 1)
        {
            objectToShow = obj1;
        }
        else
        {
            objectToShow = obj2;
        }
        passed++;
        GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
        GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
    }
    public static void Set_size(int size)
    {
        full = size;
    }

    public static int GetRandomNum(int from, int to)
    {
        return Random.Range(from, to);
    }
}
