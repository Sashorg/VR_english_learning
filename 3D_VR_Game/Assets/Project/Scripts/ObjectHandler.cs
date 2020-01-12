using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ObjectHandler : MonoBehaviour
{
    private static string choice;
    private static string path;

    static int passed;
    static int full = 0;
    public static string objectToShow;
    static int numObject;
    static ArrayList obj;
    static GameObject[] objects;
    bool f = false;
    bool f2 = false;

    private static string[] objlist;

    static ArrayList AppartRooms;

    // Start is called before the first frame update
    void Start()
    {
        if(SettingsManager.trainOrLearn == "Training" && SettingsManager.room == "Apartment" && !SettingsManager.appartamentOngoing){
            obj = new ArrayList { };
            AppartRooms = new ArrayList();
            passed = 0;
            AppartRooms.Add("bath");
            AppartRooms.Add("objects");
        }

        if(SettingsManager.trainOrLearn == "Training" && SettingsManager.room != "Apartment")
        {
            obj = new ArrayList { };
            passed = 0;
        }

        //Setup();
    }


    private void Update()
    {
        if(SettingsManager.trainOrLearn == "Training" && SettingsManager.room == "Apartment" && !SettingsManager.appartamentOngoing){
            if (!f)
            {
                SettingsManager.appartamentOngoing = true;
                f = true;
                SetupApartament();
            }
        }

        if(SettingsManager.trainOrLearn == "Training" && SettingsManager.room == "Apartment" && SettingsManager.appartamentOngoing){
            if (!f)
            {
                f = true;
                full = ApartamentHandler.full;
                passed = ApartamentHandler.passed;
                obj = ApartamentHandler.obj;
                SetupUIApartament();
            }
        }

        if (SettingsManager.trainOrLearn == "Training" && SettingsManager.room != "Apartment")
        {
            if (!f)
            {
                Setup();
                f = true;
            }
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
            //print("-----------\nObjects are:");
            //foreach (string s in obj) print(s);\
        full = obj.Count;
        SetupUI();
    }

    public static void SetupApartament(){
        //Here we parse all json files for taking objects.
        foreach(string s in AppartRooms){
            choice = "/" + s + ".json";

            path = Application.persistentDataPath + choice;
            #if (UNITY_EDITOR)
            path = Application.streamingAssetsPath + choice;
            #endif

            print(path);

            Objectss easyy = JsonUtility.FromJson<Objectss>(File.ReadAllText(path));

            if(SettingsManager.difficulty == "Easy"){
                objlist = easyy.level_easy;
            }else if(SettingsManager.difficulty == "Medium"){
                objlist = easyy.level_medium;
            }else{
                objlist = easyy.level_hard;
            }

            foreach(string str in objlist){
                obj.Add(str);
            }
        }
        obj = ShuffleList(obj);
        full = obj.Count;

        ApartamentHandler.obj = obj;
        ApartamentHandler.full = full;
        SetupUI();
    }

    public static void SetupUI(){
        numObject = Random.Range(0, obj.Count);
        objectToShow = obj[numObject].ToString();
        GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
        GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
        // change this to "you need to find a "GameObject"  
        AudioManager.Instance.ObjectSound(objectToShow);
        obj.RemoveAt(numObject);
        if( SettingsManager.room == "Apartament"){
            ApartamentHandler.passed = passed;
            ApartamentHandler.full = full;
            ApartamentHandler.obj = obj;
            ApartamentHandler.toShow = objectToShow;
        }
    }
   
   public static void SetupUIApartament(){
        objectToShow = ApartamentHandler.toShow;
        passed = ApartamentHandler.passed;
        full = ApartamentHandler.full;
        GameObject.Find("UI_Object").GetComponent<Text>().text = objectToShow;
        GameObject.Find("UI_Score").GetComponent<Text>().text = passed + "/" + full;
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
            StatisticsManager.stopTimer();
            StatisticsManager.gameOver();
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
            
            if( SettingsManager.room == "Apartament"){
                ApartamentHandler.passed = passed;
                ApartamentHandler.full = full;
                ApartamentHandler.obj = obj;
                ApartamentHandler.toShow = objectToShow;
            }
        }


    }

    private static ArrayList ShuffleList(ArrayList inputList)
    {
     ArrayList randomList = new ArrayList();

     int randomIndex = 0;
     while (inputList.Count > 0)
     {
        int c = inputList.Count;
        randomIndex = Random.Range(0, c); 
        randomList.Add(inputList[randomIndex]);
        inputList.RemoveAt(randomIndex); 
     }

     return randomList; 
    }
    
    public static void End()
    {
        //SceneManager.LoadScene(0);
    }

}
