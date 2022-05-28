using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype3 : MonoBehaviour
{
    //lo = lineobject; for creating line connected
    GameObject loS1;

    //mo = mainobject(sphere)
    Collider moS1;

    //lr = linerenderer; for creating line connected
    LineRenderer lrS1;

    // Start is called before the first frame update
    void Start()
    {
        loS1 = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (loS1.GetComponent<LineRenderer>())
        {
            lrS1.SetPosition(0, moS1.transform.position);
            lrS1.SetPosition(1, transform.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if ( other.name == "S27" && !loS1.GetComponent<LineRenderer>())
        {
            moS1 = other;
            lrS1 = loS1.AddComponent<LineRenderer>();
            lrS1.SetPosition(0, moS1.transform.position);
            lrS1.SetPosition(1, transform.position);
            lrS1.startWidth = 0.005f;
            lrS1.endWidth = 0.005f;
            lrS1.material.color = Color.yellow;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (loS1.GetComponent<LineRenderer>())
            Destroy(loS1.GetComponent<LineRenderer>());
    }
}
