using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype42 : MonoBehaviour
{
    bool isMarkerSeen = false;

    GameObject h1e;

    GameObject g1e;

    float distance;

    float height;

    // Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        h1e = GameObject.Find("S34E");
        g1e = GameObject.Find("S33E");
    }

    // Update is called once per frame
    void Update()
    {
        //for vertical movement
        if (isMarkerSeen)
        {
            distance =
                Vector3
                    .Distance(g1e.transform.position, h1e.transform.position);
            height = g1e.transform.position.y + distance - 0.1f;

            transform.position =
                new Vector3(transform.position.x, height, transform.position.z);
        }
        else
        {
            transform.position = GameObject.Find("S33E").transform.position;
        }
    }

    public void MarkerVisible()
    {
        isMarkerSeen = true;
    }

    public void MarkerNotVisible()
    {
        isMarkerSeen = false;
    }
}
