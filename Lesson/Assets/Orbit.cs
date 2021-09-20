using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    bool orbit = false;
    public float rotationSpeed = 1.0f;
    public float radius = 1.0f;
    Vector3 axis = Vector3.up;
    Transform center;
    public Vector3 desiredPosition;
    bool resetAllPos = true;
    bool justSpawned = true;

    Vector3 startPos;
    Vector3 startRot;

    float angleDivide = 0;

    [HideInInspector]
    public int particleIndex = 0;
    float rotationAngle;

    Vector3 initialOrbitTransform;
    bool firstTimeOrbiting = true;

    [HideInInspector]
    public ParticleSpawn spawner;
    private bool grabbed;

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation.eulerAngles;
    }

    private void OnTriggerExit(Collider other)
    {
        orbit = false;
    }

    //called when an object is grabbed
    public void Grabbed()
    {
        grabbed = true;
        if (orbit)
        {
            //resetting as if you're grabbing it and it hasn't orbitted
            firstTimeOrbiting = true;
            orbit = false;
            center = null;
            GetComponent<Rigidbody>().velocity = Vector3.zero;


            foreach (Orbit o in FindObjectsOfType<Orbit>())
            {
                if (o.CompareTag(tag))
                {
                    o.firstTimeOrbiting = true;
                }
            }
            resetAllPos = false;



            if (CompareTag("proton"))
            {
                print("Current proton num: " + FindObjectOfType<atommanager>().currentProtonNum);

                FindObjectOfType<atommanager>().SubtractProton();
                angleDivide = 360 / FindObjectOfType<atommanager>().currentProtonNum;
            }
            else
            {
                FindObjectOfType<atommanager>().SubtractElectron();
                print("Current electron num: " + FindObjectOfType<atommanager>().currentElectronNum);
                angleDivide = 360 / FindObjectOfType<atommanager>().currentElectronNum;
            }

        }

        //the first time you grab it it should make it so you spawn a new object
        if (justSpawned)
        {
            spawner.GrabbedFromSpawn();
            justSpawned = false;
        }
    }

    //when released from hand, do first time orbit again so it snaps to correct spot if dragged into neutron
    public void Released()
    {
        grabbed = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!grabbed)
        {
            if (!orbit)
            {
                if (other.CompareTag("neutron"))
                {
                    orbit = true;
                    center = other.transform;
                    if (CompareTag("proton"))
                    {
                        FindObjectOfType<atommanager>().AddProton();
                        particleIndex = FindObjectOfType<atommanager>().currentProtonNum;
                    }
                    else
                    {
                        FindObjectOfType<atommanager>().AddElectron();
                        particleIndex = FindObjectOfType<atommanager>().currentElectronNum;

                    }
                }
            }
        }
    }

    public void ResetLayout()
    {
        initialOrbitTransform = Vector3.zero;
        firstTimeOrbiting = true;
        orbit = false;
        center = null;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = startPos;
        transform.eulerAngles = startRot;

    }


    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<Levelmanager>().gamePaused)
        {
            if (orbit)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;

                if (particleIndex == 1)
                {
                    if (CompareTag("proton"))
                    {
                        FindObjectOfType<atommanager>().firstProtonPosition = transform.position;
                    }
                    else
                    {
                        FindObjectOfType<atommanager>().firstElectronPosition = transform.position;
                    }
                }

                if (CompareTag("proton"))
                {
                    initialOrbitTransform = FindObjectOfType<atommanager>().firstProtonPosition;
                }
                else
                {
                    initialOrbitTransform = FindObjectOfType<atommanager>().firstElectronPosition;
                }

                if (resetAllPos)
                {
                    foreach (Orbit o in FindObjectsOfType<Orbit>())
                    {
                        if (o.CompareTag(tag))
                        {
                            o.firstTimeOrbiting = true;
                        }
                    }
                    resetAllPos = false;
                }

                if (firstTimeOrbiting)
                {
                    transform.position = initialOrbitTransform;
                    if (CompareTag("proton"))
                    {
                        angleDivide = FindObjectOfType<atommanager>().protonAngleDivide;
                    }
                    else
                    {
                        angleDivide = FindObjectOfType<atommanager>().electronAngleDivide;

                    }
                    angleDivide *= particleIndex;

                    transform.RotateAround(center.position, axis, angleDivide);
                    firstTimeOrbiting = false;
                }

                rotationAngle = (rotationSpeed * Time.deltaTime);
                transform.RotateAround(center.position, axis, rotationAngle);
                desiredPosition = (transform.position - center.position).normalized * radius + center.position;
                transform.position = desiredPosition;
                transform.position = new Vector3(desiredPosition.x, center.position.y, desiredPosition.z);
            }
        }
    }
}
