using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectHandler : MonoBehaviour
{
    static int passed;
    static int full;
    public static string objectToShow;
    static int numObject;
    static ArrayList obj;
    static GameObject[] objects;
    bool f = false;
    bool f2 = false;


    // Start is called before the first frame update
    void Start()
    {
        obj = new ArrayList { };
        passed = 0;
    }


    private void Update()
    {
        if (!f)
        {
            Setup();
            f = true;
        }
    }
    public static void Setup()
    {
        objects = GameObject.FindGameObjectsWithTag("floor");
        foreach (GameObject o in objects)
        {
            if (o.name.Contains("(Clone)")) obj.Add(o.name.Replace("(Clone)", ""));
        }
        objects = GameObject.FindGameObjectsWithTag("table");
        foreach (GameObject o in objects)
        {
            if (o.name.Contains("(Clone)")) obj.Add(o.name.Replace("(Clone)", ""));
        }
        objects = GameObject.FindGameObjectsWithTag("walls");
        foreach (GameObject o in objects)
        {
            if (o.name.Contains("(Clone)")) obj.Add(o.name.Replace("(Clone)", ""));
        }
        objects = GameObject.FindGameObjectsWithTag("middle_walls");
        foreach (GameObject o in objects)
        {
            if (o.name.Contains("(Clone)")) obj.Add(o.name.Replace("(Clone)", ""));
        }
        //SetText();
        print("-----------\nObjects are:");
        foreach (string s in obj) print(s); 
        full = obj.Count;
        numObject = Random.Range(0, obj.Count);
        objectToShow = obj[numObject].ToString();
        GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
        GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
        // change this to "you need to find a "GameObject"  
        AudioManager.Instance.ObjectSound(objectToShow);
        obj.RemoveAt(numObject);
    }
    public static void SetText()
    {
        passed++;
        if (passed >= full)
        {
            passed = full;
            GameObject.Find("UI_Object").GetComponent<Text>().text = "Congratulations!!!";
            GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
            GameObject.Find("UI_find").GetComponent<Text>().text = "Good Job!";
            End();
        }
        else
        {
            numObject = Random.Range(0, obj.Count);
            objectToShow = obj[numObject].ToString();
            AudioManager.Instance.ObjectSound(objectToShow);
            GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
            GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
            obj.RemoveAt(numObject);
        }


    }

    public static void End()
    {
        SceneManager.LoadScene(0);
    }

}
