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
        obj = new ArrayList { };
        RandomObject[] ros = (RandomObject[])FindObjectsOfType(typeof(RandomObject));
        foreach (RandomObject r in ros)
        {
            foreach (GameObject g in r.spawnPoint)
            {
                obj.Add(g.name);
            }
        }
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
            AudioManager.Instance.ObjectSound(objectToShow);
            GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
            GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
            obj.RemoveAt(numObject);
        }


    }

    public static void End()
    {

    }

}
