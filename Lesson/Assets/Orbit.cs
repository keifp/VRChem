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

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation.eulerAngles;

    }

 
    //called when an object is grabbed
    public void Grabbed()
    {
        //resetting as if you're grabbing it and it hasn't orbitted
        firstTimeOrbiting = true;
        orbit = false;
        center = null;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        //the first time you grab it it should make it so you spawn a new object
        if (justSpawned)
        {
            spawner.GrabbedFromSpawn();
            justSpawned = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("neutron"))
        {
            orbit = true;
            center = other.transform;
            if (CompareTag("proton"))
            {
                FindObjectOfType<atommanager>().AddProton();
                angleDivide = 360 / FindObjectOfType<atommanager>().currentProtonNum;
                particleIndex = FindObjectOfType<atommanager>().currentProtonNum;
            }
            else
            {
                FindObjectOfType<atommanager>().AddElectron();
                angleDivide = 360 / FindObjectOfType<atommanager>().currentElectronNum;
                particleIndex = FindObjectOfType<atommanager>().currentProtonNum;

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
                rotationAngle = (rotationSpeed * Time.deltaTime);
                GetComponent<Rigidbody>().velocity = Vector3.zero;

                if(particleIndex == 1)
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

                if (firstTimeOrbiting)
                {
                    print("particleIndex " + particleIndex + " initial pos" + initialOrbitTransform);
                    transform.position = initialOrbitTransform;
                    transform.RotateAround(center.position, axis, angleDivide);
                    firstTimeOrbiting = false;
                }

                transform.RotateAround(center.position, axis, rotationAngle);
                desiredPosition = (transform.position - center.position).normalized * radius + center.position;
                transform.position = desiredPosition;
                transform.position = new Vector3(desiredPosition.x, center.position.y, desiredPosition.z);
            }
        }
    }
}
