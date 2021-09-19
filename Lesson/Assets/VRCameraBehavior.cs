using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraBehavior : MonoBehaviour
{
    bool movementFrozen = false;
    Vector3 freezePos;
    public GameObject cam;

    //public GameObject roomCenter;

    private void OnTriggerExit(Collider other)
    {
        movementFrozen = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        print("collision enter");
        if (other.gameObject.CompareTag("walls"))
        {
            print("collision wall enter");
            //cam.transform.position = Vector3.forward+ cam.transform.position;

            movementFrozen = true;
            freezePos = transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (movementFrozen)
        {
            //cam.transform.position = Vector3.forward + cam.transform.position;
            cam.transform.position = freezePos;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
