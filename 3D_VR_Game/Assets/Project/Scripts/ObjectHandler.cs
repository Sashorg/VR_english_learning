using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHandler : MonoBehaviour
{
    static int passed;
    static int full;
    public static string objectToShow;
    static int numObject;
    static ArrayList obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = new ArrayList
        {
            "chair",
            "glass",
            "fork"
        };
        passed = 0;
        full = obj.Count;
        numObject = Random.Range(0, obj.Count);
        objectToShow = obj[numObject].ToString();
        GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
        GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
        // change this to "you need to find a "GameObject"  
        AudioManager.Instance.ObjectSound(objectToShow);
        obj.RemoveAt(numObject);
    }

    //Here we can get the component where we want to show the next name!
    public static void SetText()
    {
        passed++;
        if (passed >= full)
        {
            passed = full;
            GameObject.Find("UI_Object").GetComponent<Text>().text = "Congratulations!!!";
            GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
            GameObject.Find("UI_find").GetComponent<Text>().text = "Good Job!";
        }
        else
        {
            numObject = Random.Range(0, obj.Count);
            objectToShow = obj[numObject].ToString();
            GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
            GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
            obj.RemoveAt(numObject);
        }
    }

    public static void End()
    {

    }
}
