using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public float totalTime = 2.0f;
    private bool _gvrStatus;
    private float _gvrTimer;
    private bool _gazeComplete;
    public bool match;
    private GameObject _reticle;
    private Renderer _rd;
    

    // Start is called before the first frame update
    void Start()
    {
        _gazeComplete = false;
        _gvrStatus = false;
        _gvrTimer = 0;
        _reticle = GameObject.FindGameObjectWithTag("Reticle");
        _rd = _reticle.GetComponent<Renderer>();
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
        _gazeComplete = false;
        _rd.material.color = Color.black;
    }

    public void gazeCompleted()
    {
        Debug.Log("Gaze!");
        AudioManager.Instance.ObjectSound(this.gameObject.tag);
        match = this.gameObject.CompareTag(ObjectHandler.objectToShow);

        if (match)
        {
            ObjectScript.deleteObject(ObjectHandler.objectToShow.ToString());
            _rd.material.color = Color.green;
            Debug.Log("Match!");
            ObjectHandler.SetText();
          
           //Call function to warn that the right word has been chosen
        }
        else
        {
            _rd.material.color = Color.red;
            Debug.Log("Not a Match!");
            //Make recticle pointer red
        }
    }
}
