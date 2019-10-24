using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer rd;
    public float totalTime = 2.0f;
    private bool _gvrStatus;
    private float _gvrTimer;
    private bool _gazeComplete;
    public string targetTag;
    public bool match;

    // Start is called before the first frame update
    void Start()
    {
        _gazeComplete = false;
        _gvrStatus = false;
        _gvrTimer = 0;
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gvrStatus)
        {
            _gvrTimer += Time.deltaTime;
        }
        if (_gvrTimer > totalTime && _gazeComplete != true)
        {
            gazeCompleted();
            _gazeComplete = true;
        }
    }

    public void gvrOn()
    {
        _gvrStatus = true;
    }

    public void gvrOff()
    {
        _gvrStatus = false;
        _gvrTimer = 0;
        rd.material.color = Color.white;
        _gazeComplete = false;
    }

    public void gazeCompleted()
    {
        rd.material.color = Color.grey;
        match = gameObject.CompareTag(targetTag);
        if (match)
        {
            Debug.Log("Match!");
            //Do something if match object
        }
        else
        {
            Debug.Log("Not a match!");
            //Do something else if doesn't match object
        }
    }

}
