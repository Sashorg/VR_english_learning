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
    static string toShow;
    static readonly ArrayList obj;

    static ObjectHandler()
    {
        obj = new ArrayList();
        obj.Add("Apple");
        obj.Add("Banana");
        obj.Add("Tomato");
        obj.Add("Tomato8");
        obj.Add("Tomato7");
        obj.Add("Tomato6");
        obj.Add("Tomato5");
        obj.Add("Tomato4");
        obj.Add("Tomato3");
        obj.Add("Tomato2");
        obj.Add("Tomato1");

    }
    // Start is called before the first frame update
    void Start()
    {
        passed = -1;
        full = obj.Count;
        SetText();
    }

    //void SetText()
    public static void SetText()
    {
        //Here we can get the component where we want to show the next name!
        Text txt = GameObject.Find("Text").GetComponent<Text>();
        passed++;
        if(passed >= full)
        {
            passed = full;
            toShow = passed + "/" + full + " Congratulations!!!";
            txt.text = toShow;
            End();
        }
        else
        {
            numObject = Random.Range(0, obj.Count);
            objectToShow = obj[numObject].ToString();
            toShow = passed + "/" + full + " " + objectToShow;
            txt.text = toShow;
            obj.RemoveAt(numObject);
        }
    }

    public  static void End()
    {

    }
}
