using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteControl : Singleton<SpriteControl>
{
    public Sprite test; 

    public void NewSprite(string where, string txt)
    {
        if (txt == "banana")
        {
            GameObject.Find(where).GetComponent<Image>().sprite = test;
        }
    }
}
