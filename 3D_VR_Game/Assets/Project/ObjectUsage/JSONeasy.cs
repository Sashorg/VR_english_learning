using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONeasy : MonoBehaviour
{
    ///objects.json, /objects_zoo.json 
    public enum Level { objects, zooobjects , tryout};

    public Level levels;
    private string choice;
    
    private GameObject right_wall;
    private GameObject left_wall;
    private GameObject[] spawner_floor;
    private GameObject[] spawner_table;
    private GameObject[] spawner_middle_walls;
    private GameObject[] spawner_walls;
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
    private float rnd_coordinate2;
    private float rnd_coordinate;
    private int count_floor = 0;
    private int count_walls = 0;
    private int count_middle_walls = 0;
    private int count_table = 0;
    private int amount_tables = 0;
    private ArrayList fixed_json_set;
   // private string level = SettingsManager.difficulty;
    private string level = "Hard";
    private string[] objlist;
    // Array list is for initiating all objects, the arraylst should be equal to the number of objects attached to spawner
  
    // Start is called before the first frame update
    void Awake()
    {

    }

    void OnEnable()
    {
        choice = levels.ToString();
        choice = "/" + choice + ".json";
        print(choice);

        fixed_json_set = new ArrayList();
        spawner_floor = GameObject.FindGameObjectsWithTag("spawner_floor");
        spawner_walls = GameObject.FindGameObjectsWithTag("spawner_wall");
        spawner_middle_walls = GameObject.FindGameObjectsWithTag("spawner_middle_wall");

        spawner_floor = reshuffle_go(spawner_floor);
        spawner_walls = reshuffle_go(spawner_walls);

        path = Application.persistentDataPath + choice;

        #if (UNITY_EDITOR)
        path = Application.streamingAssetsPath + choice;
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
        else {
            objlist = easyy.level_hard;
        }
        objlist = reshuffle(objlist);
        int words_in_json = objlist.Length;
       // int places_on_scene = spawner.Length;
        print(words_in_json);
        print(objlist[1]);

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


        foreach (string goe in objlist) {
            
            if (goe == "table") {
                goo = ObjectPoolingManager.Instance.GetObject(goe);

                if (count_floor >= spawner_floor.Length)
                {
                    goo.SetActive(false);
                    print(goo.name + "was dectivated");

                }
                else
                {
                    print("we here2");
                    int angle = Random.Range(-5, +5);
                    goo.transform.position = spawner_floor[count_floor].gameObject.transform.position;
                    goo.transform.rotation = spawner_floor[count_floor].gameObject.transform.rotation * Quaternion.Euler(0, angle, 0);
                    // keep only the horizontal direction

                    print(goo.transform.position);
                    amount_tables = amount_tables + 1;
                    count_floor = count_floor + 1;
                    if (count_floor == spawner_floor.Length)
                    {
                        reservedGO = goo;
                    }
                }


            }
        
        }
        foreach (string goe in objlist)
        {
            if (goe != "table") { 

            print(goe);



            //problem is that i intanciat objects and their postions and the change them, but collider see old position



            goo = ObjectPoolingManager.Instance.GetObject(goe);

            if (goo.tag == "floor")
            {



                print("we here");
                if (count_floor >= spawner_floor.Length)
                {
                    goo.SetActive(false);
                    print(goo.name + "was dectivated");

                }
                else
                {
                    print("we here2");
                    int angle = Random.Range(-5, +5);
                    goo.transform.position = spawner_floor[count_floor].gameObject.transform.position;
                    goo.transform.rotation = spawner_floor[count_floor].gameObject.transform.rotation * Quaternion.Euler(0, angle, 0);
                    // keep only the horizontal direction

                    print(goo.transform.position);
                    count_floor = count_floor + 1;
                    if (count_floor == spawner_floor.Length)
                    {
                        reservedGO = goo;
                    }
                }
                // goo.transform.rotation=
            }
            if (goo.tag == "walls")
            {
                print("we here");
                if (count_walls >= spawner_walls.Length)
                {
                    goo.SetActive(false);
                    print(goo.name + " was dectivated");

                }
                else
                {
                    print("we here2");
                    goo.transform.position = spawner_walls[count_walls].gameObject.transform.position;
                    goo.transform.rotation = spawner_walls[count_walls].gameObject.transform.rotation;
                    print(goo.transform.position);
                    count_walls = count_walls + 1;
                }

            }

            if (goo.tag == "middle_walls")
            {
                print("we here");
                if (count_middle_walls >= spawner_middle_walls.Length)
                {
                    goo.SetActive(false);
                    print(goo.name + " was dectivated");

                }
                else
                {
                    print("we here2");
                    goo.transform.position = spawner_middle_walls[count_middle_walls].gameObject.transform.position;
                    goo.transform.rotation = spawner_middle_walls[count_middle_walls].gameObject.transform.rotation;
                    print(goo.transform.position);
                    count_middle_walls = count_middle_walls + 1;
                }

            }
            if (goo.tag == "table")
            {


                    if (count_table == 0)
                    {
                        if (amount_tables == 0) { 
                            table = ObjectPoolingManager.Instance.GetObject("table");
                       
                        if (count_floor >= spawner_floor.Length)
                        {
                            reservedGO.SetActive(false);
                            table.transform.position = spawner_floor[count_floor - 1].gameObject.transform.position;
                            table.transform.rotation = spawner_floor[count_floor - 1].gameObject.transform.rotation;
                            //goo.SetActive(false);
                            // print(goo.name + "was dectivated");

                        }
                        else
                        {
                            print("we here2");
                            table.transform.position = spawner_floor[count_floor].gameObject.transform.position;
                            table.transform.rotation = spawner_floor[count_floor].gameObject.transform.rotation;
                            print(table.transform.position);
                            count_floor = count_floor + 1;
                        }
                    }
                        spawner_table = GameObject.FindGameObjectsWithTag("spawner_table");
                        print(spawner_table.Length + "FFFFFFFFFFFFFFFFFFFF");
                        spawner_table = reshuffle_go(spawner_table);

                    }
                    if (count_table >= spawner_table.Length)
                {
                    goo.SetActive(false);
                    print(goo.name + " was dectivated");

                }
                else
                {
                    int angle = Random.Range(-15, +15);
                    print("we here2");
                    goo.transform.position = spawner_table[count_table].gameObject.transform.position;
                    goo.transform.rotation = spawner_table[count_table].gameObject.transform.rotation * Quaternion.Euler(0, angle, 0);
                    spawner_table[count_table].SetActive(false);
                    print(goo.transform.position);
                    count_table = count_table + 1;
                }

                //  goo.transform.position =

            }
            print(goo.tag);
            // goo.transform.position  
        }
        }
      

       


    }

    // Update is called once per frame
    void Update()
    {
       
        // print(Physics.OverlapSphere(new Vector3(0, 1, 0), 3).Length + "last");
        //if (Physics.OverlapSphere(new Vector3(0, 1, 0), 3).Length > 0) {
        //  print(Physics.OverlapSphere(new Vector3(0, 1, 0), 3)[0]);

        //}
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        //    Gizmos.DrawSphere(new Vector3(0f,1f,0f), 3);
        Gizmos.DrawSphere(transform.position, 3);
    }
    string[] reshuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
        return texts;
    }
    GameObject[] reshuffle_go(GameObject[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            GameObject tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
        return texts;
    }
    //this function is responsiblle for extracting items from list to have no duplicates in the scene

}
[System.Serializable]
public class Objectss
{
    // Start is called before the first frame update
    
    public string[] level_easy;

    public string[] level_medium;

    public string[] level_hard;

}
