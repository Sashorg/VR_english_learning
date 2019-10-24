using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GazeTimer : MonoBehaviour
{
    private bool _gazeComplete;
    public Image imgGaze;
    public float totalTime = 2.0f;
    bool gvrStatus;
    float gvrTimer;

    Renderer rd;

    // Start is called before the first frame update
    void Start()
    {
        imgGaze.fillAmount = 0f;
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            if(gvrTimer > totalTime && _gazeComplete != true)
            {
                gazeCompleted();
                _gazeComplete = true;
            }
        }
    }

    public void gvrOn()
    {
        gvrStatus = true;
    }

    public void gvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0f;
        _gazeComplete = false;
        rd.material.color = Color.white;
    }

    public void gazeCompleted()
    {
        rd.material.color = Color.grey;
    }
}
