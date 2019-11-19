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

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject.Find("Furniture").SetActive(true);
            GameObject.Find("Gadgets").SetActive(false);
        }

       

        if (Input.GetKeyDown(KeyCode.S))
        {

            GameObject.Find("Furniture").SetActive(false);
            GameObject.Find("Gadgets").SetActive(true);
        }
    }
}
