using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChanger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject.Find("Furniture").gameObject.SetActive(false);
            GameObject.Find("Gadgets").gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
   
            GameObject.Find("Furniture").gameObject.SetActive(true);
            GameObject.Find("Gadgets").gameObject.SetActive(false);
        }

    }
    public void level1() {
        print("we are iin 1");
        GameObject.Find("Furniture").gameObject.SetActive(false);
     
    }
    public void level2()
    {
        print("we are in 2");
       
        GameObject.Find("Gadgets").gameObject.SetActive(false);
    }
}
