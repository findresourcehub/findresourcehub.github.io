using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype2 : MonoBehaviour
{
    //lo = lineobject; for creating line connected
    GameObject loS1;

    GameObject loS2;

    GameObject loS3;

    //mo = mainobject(sphere)
    Collider moS1;

    Collider moS2;

    //lr = linerenderer; for creating line connected
    LineRenderer lrS1;

    LineRenderer lrS2;

    LineRenderer lrS3;

    bool inVicinity1 = false;

    bool inVicinity2 = false;

    // Start is called before the first frame update
    void Start()
    {
        loS1 = new GameObject();
        loS2 = new GameObject();
        loS3 = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (loS1.GetComponent<LineRenderer>())
        {
            lrS1.SetPosition(0, moS1.transform.position);
            lrS1.SetPosition(1, moS2.transform.position);
        }

        if (loS2.GetComponent<LineRenderer>())
        {
            lrS2.SetPosition(0, Bond2Creation(moS1));
            lrS2.SetPosition(1, Bond2Creation(moS2));
        }
        if (loS3.GetComponent<LineRenderer>())
        {
            lrS3.SetPosition(0, Bond3Creation(moS1));
            lrS3.SetPosition(1, Bond3Creation(moS2));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "S21")
        {
            moS1 = other;
            inVicinity1 = true;
        }
        else if (other.name == "S22")
        {
            moS2 = other;
            inVicinity2 = true;
        }

        if (
            inVicinity1 && inVicinity2 && !loS1.GetComponent<LineRenderer>() //just checking one bond will do
        )
        {
            if (transform.name == "Bond1")
            {
                lrS1 = loS1.AddComponent<LineRenderer>();
                lrS1.SetPosition(0, moS1.transform.position);
                lrS1.SetPosition(1, moS2.transform.position);
                lrS1.startWidth = 0.005f;
                lrS1.endWidth = 0.005f;
                lrS1.material.color = Color.yellow;
            }

            if (transform.name == "Bond2")
            {
                lrS1 = loS1.AddComponent<LineRenderer>();
                lrS1.SetPosition(0, moS1.transform.position);
                lrS1.SetPosition(1, moS2.transform.position);
                lrS1.startWidth = 0.005f;
                lrS1.endWidth = 0.005f;
                lrS1.material.color = Color.yellow;

                lrS2 = loS2.AddComponent<LineRenderer>();
                lrS2.SetPosition(0, Bond2Creation(moS1));
                lrS2.SetPosition(1, Bond2Creation(moS2));
                lrS2.startWidth = 0.005f;
                lrS2.endWidth = 0.005f;
                lrS2.material.color = Color.yellow;
            }

            if (transform.name == "Bond3")
            {
                lrS1 = loS1.AddComponent<LineRenderer>();
                lrS1.SetPosition(0, moS1.transform.position);
                lrS1.SetPosition(1, moS2.transform.position);
                lrS1.startWidth = 0.005f;
                lrS1.endWidth = 0.005f;
                lrS1.material.color = Color.yellow;

                lrS2 = loS2.AddComponent<LineRenderer>();
                lrS2.SetPosition(0, Bond2Creation(moS1));
                lrS2.SetPosition(1, Bond2Creation(moS2));
                lrS2.startWidth = 0.005f;
                lrS2.endWidth = 0.005f;
                lrS2.material.color = Color.yellow;

                lrS3 = loS3.AddComponent<LineRenderer>();
                lrS3.SetPosition(0, Bond3Creation(moS1));
                lrS3.SetPosition(1, Bond3Creation(moS2));
                lrS3.startWidth = 0.005f;
                lrS3.endWidth = 0.005f;
                lrS3.material.color = Color.yellow;
            }
        }
    }

    public Vector3 Bond2Creation(Collider other)
    {
        Vector3 temp =
            new Vector3(other.transform.position.x + 0.01f,
                other.transform.position.y,
                other.transform.position.z + 0.01f);

        return temp;
    }

    public Vector3 Bond3Creation(Collider other)
    {
        Vector3 temp =
            new Vector3(other.transform.position.x - 0.01f,
                other.transform.position.y,
                other.transform.position.z - 0.01f);

        return temp;
    }

    public void OnTriggerExit(Collider other)
    {
        if (loS1.GetComponent<LineRenderer>())
            Destroy(loS1.GetComponent<LineRenderer>());

        if (loS2.GetComponent<LineRenderer>())
            Destroy(loS2.GetComponent<LineRenderer>());

        if (loS3.GetComponent<LineRenderer>())
            Destroy(loS3.GetComponent<LineRenderer>());

        if (other.name == "S21") inVicinity1 = false;

        if (other.name == "S22") inVicinity2 = false;
    }

    // public void Atom1NotVisible()
    // {
    //     if (loS1)
    //         if (loS1.GetComponent<LineRenderer>())
    //             Destroy(loS1.GetComponent<LineRenderer>());
    // }
}
