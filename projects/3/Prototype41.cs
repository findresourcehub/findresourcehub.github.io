using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prototype41 : MonoBehaviour
{
    //lo = lineobject; for creating line connected
    GameObject loS1;

    GameObject loS2;

    GameObject loS3;

    GameObject loS4;

    //mo = mainobject(sphere)
    Collider moS1;

    //lr = linerenderer; for creating line connected
    LineRenderer lrS1;

    LineRenderer lrS2;

    LineRenderer lrS3;

    LineRenderer lrS4;

    bool isMarkerSeen = false;

    GameObject h1e;

    GameObject g1e;

    GameObject h2e;

    GameObject g2e;

    float distance;

    float height;

    TMP_Text text1;

    TMP_Text text2;

    TMP_Text text3;

    // Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        loS1 = new GameObject();
        loS2 = new GameObject();
        loS3 = new GameObject();
        loS4 = new GameObject();

        h1e = GameObject.Find("S31E");
        g1e = GameObject.Find("S32E");

        h2e = GameObject.Find("S34E");
        g2e = GameObject.Find("S33E");

        text1 = new TextMeshProUGUI();
        text1 = GameObject.Find("TEXT1").GetComponent<TMP_Text>();
        text2 = GameObject.Find("TEXT2").GetComponent<TMP_Text>();
        text3 = GameObject.Find("TEXT3").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text1.text =
            "H1:" +
            (
            Math
                .Truncate(Vector3
                    .Distance(g1e.transform.position, transform.position) *
                100)
            ).ToString();

        if (moS1)
        {
            text2.text =
                "H2:" +
                (
                Math
                    .Truncate(Vector3
                        .Distance(g2e.transform.position,
                        moS1.transform.position) *
                    100)
                ).ToString();
        }

        //for bond formation
        if (loS1.GetComponent<LineRenderer>())
        {
            lrS1.SetPosition(0, moS1.transform.position);
            lrS1.SetPosition(1, transform.position);

            text3.text =
                "Gap:" +
                (
                Math
                    .Truncate(Vector3
                        .Distance(g1e.transform.position,
                        g2e.transform.position) *
                    100)
                ).ToString();
        }

        if (loS2.GetComponent<LineRenderer>())
        {
            lrS2.SetPosition(0, g1e.transform.position);
            lrS2.SetPosition(1, transform.position);
        }

        if (loS3.GetComponent<LineRenderer>())
        {
            lrS3.SetPosition(0, g2e.transform.position);
            lrS3.SetPosition(1, g1e.transform.position);
        }

        if (loS4.GetComponent<LineRenderer>())
        {
            lrS4.SetPosition(0, g2e.transform.position);
            lrS4.SetPosition(1, moS1.transform.position);
        }

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
            transform.position = GameObject.Find("S32E").transform.position;
        }
    }

    //for bond formation
    public void OnTriggerEnter(Collider other)
    {   Debug.Log("enterrrrrrr");
        if (other.name == "S33" && !loS1.GetComponent<LineRenderer>())
        {
            moS1 = other;

            //main object to other object
            lrS1 = loS1.AddComponent<LineRenderer>();
            lrS1.SetPosition(0, moS1.transform.position);
            lrS1.SetPosition(1, transform.position);
            lrS1.startWidth = 0.005f;
            lrS1.endWidth = 0.005f;
            lrS1.material.color = Color.yellow;

            //main object to main obj position original
            lrS2 = loS2.AddComponent<LineRenderer>();
            lrS2.SetPosition(0, g1e.transform.position);
            lrS2.SetPosition(1, transform.position);
            lrS2.startWidth = 0.002f;
            lrS2.endWidth = 0.002f;
            lrS2.material.color = Color.white;

            //other object to main obj position original
            lrS3 = loS3.AddComponent<LineRenderer>();
            lrS3.SetPosition(0, g1e.transform.position);
            lrS3.SetPosition(1, g2e.transform.position);
            lrS3.startWidth = 0.002f;
            lrS3.endWidth = 0.002f;
            lrS3.material.color = Color.white;

            //other object to other obj position original
            lrS4 = loS4.AddComponent<LineRenderer>();
            lrS4.SetPosition(0, moS1.transform.position);
            lrS4.SetPosition(1, g2e.transform.position);
            lrS4.startWidth = 0.002f;
            lrS4.endWidth = 0.002f;
            lrS4.material.color = Color.white;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("enterrrrrrr2");
        if (loS1.GetComponent<LineRenderer>())
            Destroy(loS1.GetComponent<LineRenderer>());
        if (loS2.GetComponent<LineRenderer>())
            Destroy(loS2.GetComponent<LineRenderer>());
        if (loS3.GetComponent<LineRenderer>())
            Destroy(loS3.GetComponent<LineRenderer>());
        if (loS4.GetComponent<LineRenderer>())
            Destroy(loS4.GetComponent<LineRenderer>());
    }

    public void MarkerVisible()
    {
        isMarkerSeen = true;
    }

    public void MarkerNotVisible()
    {
        isMarkerSeen = false;
    }

    public void QRNotVisible()
    {
        if (loS1)
            if (loS1.GetComponent<LineRenderer>())
                Destroy(loS1.GetComponent<LineRenderer>());

        if (loS2)
            if (loS1.GetComponent<LineRenderer>())
                Destroy(loS1.GetComponent<LineRenderer>());

        if (loS3)
            if (loS3.GetComponent<LineRenderer>())
                Destroy(loS3.GetComponent<LineRenderer>());

        if (loS4)
            if (loS4.GetComponent<LineRenderer>())
                Destroy(loS4.GetComponent<LineRenderer>());
    }
}
