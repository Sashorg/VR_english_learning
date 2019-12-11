

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class RandomObject_phonetcs : MonoBehaviour
{


    public delegate void ChangeRoad();
    public static event ChangeRoad changeRoadEvent;

    private GameObject spawner_stand;
    private GameObject table;
    private GameObject reservedGO;
    private GameObject top_wall;
    private GameObject back_wall;
    private GameObject goo;
    string path;
    string jsonString;
    public static string score;
    private int index = 3;//# of spawners in the scene
    public static int rnd_number;
    private int count_walls = 0;

    private ArrayList fixed_json_set;
    private ArrayList objectset;
    private string level = SettingsManager.difficulty;
    private string[] objlist;
    private int i = 0;
    // Array list is for initiating all objects, the arraylst should be equal to the number of objects attached to spawner

    // Start is called before the first frame update
    void Awake()
    {

    }
    private void OnEnable()
    {
        InteractableObject.goodChoice += good;
        InteractableObject.badChoice += bad;
    }

    private void OnDisable()
    {
        InteractableObject.goodChoice -= good;
        InteractableObject.badChoice -= bad;
    }
    void Start()
    {

        fixed_json_set = new ArrayList();
      
        spawner_stand = GameObject.FindGameObjectWithTag("spawner_stand");


        path = Application.persistentDataPath + "/phonetics.json";
        #if (UNITY_EDITOR)
        path = Application.streamingAssetsPath + "/phonetics.json";
        #endif


        jsonString = File.ReadAllText(path);
        Objectss easyy = JsonUtility.FromJson<Objectss>(jsonString);
        if (level == "Easy")
        {
            objlist = easyy.level_easy;
        }
        else if (level == "Medium")
        {
            objlist = easyy.level_medium;
        }
        else
        {
            objlist = easyy.level_hard;
        }
      
        objectset = new ArrayList(objlist);
        Phonetics_Object_handler.Set_size(objectset.Count);
        objectset = reshuffle(objectset);
        int words_in_json = objectset.Count;
        // int places_on_scene = spawner.Length;
        print(words_in_json);

        //  if (words_in_json > places_on_scene)
        //  {
        //      for (int i = 0; i != places_on_scene; i++) {
        //        fixed_json_set.Add(easyy.level_objects[i]);
        //      }
        //      for (int i = places_on_scene; i != words_in_json; i++)
        //      {
        //          print(easyy.level_objects[i] +"was deleted");
        //     }
        //  }
        //   print(fixed_json_set.Count);




        //problem is that i intanciat objects and their postions and the change them, but collider see old position

        print(objectset[i]);

       print(objectset[i].ToString());
        Phonetics_Object_handler._call(objectset[i].ToString(), "good");
       GameObject goo= ObjectPoolingManager.Instance.GetObject(objectset[i].ToString());

       
                        print("we here2");
                        goo.transform.position = spawner_stand.gameObject.transform.position;
                        goo.transform.rotation = spawner_stand.gameObject.transform.rotation;
                        print(goo.transform.position);
                        
                   

                

            

                print(goo.tag);
                // goo.transform.position  
            
        





    }

    // Update is called once per frame
    void Update()
    {
       
        // print(Physics.OverlapSphere(new Vector3(0, 1, 0), 3).Length + "last");
        //if (Physics.OverlapSphere(new Vector3(0, 1, 0), 3).Length > 0) {
        //  print(Physics.OverlapSphere(new Vector3(0, 1, 0), 3)[0]);

        //}
    }
   
    ArrayList reshuffle(ArrayList alpha)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int i = 0; i < alpha.Count; i++)
        {
            string temp = alpha[i].ToString();
            int randomIndex = Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
        return alpha;
    }
    public void good() {
        print("good");
        GameObject go = GameObject.FindGameObjectWithTag("now");
        print(go.name);
        go.SetActive(false);
        objectset.RemoveAt(i);
        if (objectset.Count != 0)
        {
            print(objectset[i].ToString());
            GameObject goo = ObjectPoolingManager.Instance.GetObject(objectset[i].ToString());
            Phonetics_Object_handler._call(objectset[i].ToString(), "good");
        }
        else
        {
            Phonetics_Object_handler._call("", "good");
        }
        print("we here2");
        goo.transform.position = spawner_stand.gameObject.transform.position;
        goo.transform.rotation = spawner_stand.gameObject.transform.rotation;
        print(goo.transform.position);

        if (changeRoadEvent != null)
            changeRoadEvent();


    }

    public void bad()
    {
        if (objectset.Count == 1)
        {
            return;
        }
        GameObject go = GameObject.FindGameObjectWithTag("now");
        go.SetActive(false);
        object reserve = objectset[i];
        print(reserve.ToString());
        int rand = Random.Range(1, objectset.Count);
        objectset.RemoveAt(i);//maybe should be before int rand

      
        print(objectset.Count - 1);
        objectset.Insert(rand,reserve);
        Phonetics_Object_handler._call(objectset[i].ToString(), "bad");
        GameObject goo = ObjectPoolingManager.Instance.GetObject(objectset[i].ToString());


        print("we here2");
        goo.transform.position = spawner_stand.gameObject.transform.position;
        goo.transform.rotation = spawner_stand.gameObject.transform.rotation;
        print(goo.transform.position);

        if (changeRoadEvent != null)
            changeRoadEvent();

    }
    //this function is responsiblle for extracting items from list to have no duplicates in the scene

}
[System.Serializable]
public class Objecto
{
    // Start is called before the first frame update

    public string[] level_easy;

    public string[] level_medium;

    public string[] level_hard;

}

