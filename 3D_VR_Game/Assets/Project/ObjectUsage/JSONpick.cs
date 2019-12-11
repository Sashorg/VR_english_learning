using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONpick : MonoBehaviour
{
    private GameObject right_wall;
    private GameObject left_wall;

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
    
    // Array list is for initiating all objects, the arraylst should be equal to the number of objects attached to spawner
    public static ArrayList obj = new ArrayList{ "chair", "fork", "glass","table" };

    // Start is called before the first frame update
    void Awake() {
       
    }
    void Start()
    {
        right_wall = GameObject.Find("right_wall");
        left_wall = GameObject.Find("left_wall");
        top_wall = GameObject.Find("top_wall");
        back_wall = GameObject.Find("down_wall");

        path = Application.persistentDataPath + "/objects.json";
        #if (UNITY_EDITOR)
        path = Application.streamingAssetsPath + "/objects.json";
        #endif
        jsonString = File.ReadAllText(path);
        Objects easy = JsonUtility.FromJson<Objects>(jsonString);
        print(easy.level_objects.GetType());
        print(easy.level);
        print(easy.level_objects[1]);

        easy.level_objects= reshuffle(easy.level_objects);
        print(easy.level_objects[1]);
        foreach( string goe in easy.level_objects){
            rnd_coordinate = Random.Range(right_wall.transform.position.x , left_wall.transform.position.x );
            rnd_coordinate2 = Random.Range(top_wall.transform.position.z, back_wall.transform.position.z );
            //so we can use tags of prefabs to determine where they should be and what to instanciate
            print(goe);
            print(easy.level_objects.Length);
        
            
            
           
               //problem is that i intanciat objects and their postions and the change them, but collider see old position

                print(Physics.OverlapSphere(new Vector3(rnd_coordinate, 1, rnd_coordinate2), 3).Length);
                //  print(Physics.OverlapSphere(new Vector3(rnd_coordinate, 0, 0), 1)[0]);
                print(rnd_coordinate);
                print(rnd_coordinate2);
                 
                while (Physics.OverlapSphere(new Vector3(rnd_coordinate, 1, rnd_coordinate2), 3).Length >0) {
                    
                    print("your len is"+ Physics.OverlapSphere(new Vector3(rnd_coordinate, 1, rnd_coordinate2), 3).Length);
                    print(Physics.OverlapSphere(new Vector3(rnd_coordinate, 1, rnd_coordinate2), 3)[0]);
                   
                    rnd_coordinate = Random.Range(right_wall.transform.position.x , left_wall.transform.position.x );
                    rnd_coordinate2 = Random.Range(top_wall.transform.position.z , back_wall.transform.position.z );
                   
                    print(rnd_coordinate);
                    print(rnd_coordinate2);
                    print(Physics.OverlapSphere(new Vector3(rnd_coordinate, 1, rnd_coordinate2), 3).Length);
                }
            goo = ObjectPoolingManager.Instance.GetObject(goe);
            print(Physics.OverlapSphere(new Vector3(rnd_coordinate, 1, rnd_coordinate2), 3).Length+"last");
            if (goo.tag == "floor")
            { 
                goo.transform.position = new Vector3(rnd_coordinate, 0, rnd_coordinate2);
                print(goo.transform.position);

           // goo.transform.rotation=
            }
     /*       if (goo.tag == "walls")
            {
                goo.transform.position =
                goo.transform.rotation =
            }
            if (goo.tag == "table")
            {   
                ObjectPoolingManager.Instance.GetObject("table");
                goo.transform.position =
                goo.transform.rotation =
            }*/
            print(goo.tag);
         // goo.transform.position  

        }
        rnd_number = Random.Range(0, index);
        print("num is " + rnd_number);
        print("yeah we here bitch");
       // GameObject go = ObjectPoolingManager.Instance.GetObject(ToString());

        score = ExampleObj.tryout;
        
    
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
    //this function is responsiblle for extracting items from list to have no duplicates in the scene
   
}
[System.Serializable]
public class Objects
{
    // Start is called before the first frame update
    public string level;
    public string[] level_objects;

}
