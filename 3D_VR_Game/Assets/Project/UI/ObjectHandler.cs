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
        obj.Add("chair");
        obj.Add("glass");
        obj.Add("fork");


    }
    // Start is called before the first frame update
    void Start()
    {
        passed = -1;
        full = obj.Count;
         numObject = Random.Range(0, obj.Count);
            objectToShow = obj[numObject].ToString();
        obj.RemoveAt(numObject);
    }

    //void SetText()
    public static void SetText()
    {
        //Here we can get the component where we want to show the next name!
     //   Text txt = GameObject.Find("Text").GetComponent<Text>();
        passed++;
        if(passed >= full)
        {
            passed = full;
            toShow = passed + "/" + full + " Congratulations!!!";
            //txt.text = toShow;
            End();
            print("lol");
        }
        else
        {
            print("Your object lolllo" + objectToShow);
            numObject = Random.Range(0, obj.Count);
            objectToShow = obj[numObject].ToString();
           // toShow = passed + "/" + full + " " + objectToShow;
          //  txt.text = toShow;
            obj.RemoveAt(numObject);
        }
    }

    public  static void End()
    {

    }
}
