using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject gvrReticle;
    private Canvas cv;

    // Start is called before the first frame update
    void Start()
    {
        cv = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        cv.planeDistance = (gvrReticle.GetComponent<GvrReticlePointer>().ReticleDistanceInMeters);
    }
}
