using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraBehavior : MonoBehaviour
{
    bool movementFrozen = false;
    Vector3 freezePos;
    public GameObject cam;

    //public GameObject roomCenter;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("walls"))
        {
            //cam.transform.position = Vector3.forward+ cam.transform.position;
            movementFrozen = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //movementFrozen = false;
    }

    private void OnTriggerExit(Collider other)
    {

    }
    private void OnTriggerEnter(Collider other)
    {


    }

    // Start is called before the first frame update

    void Start()
    {

    }


    private void LateUpdate()
    {
        print(movementFrozen);
        if (movementFrozen)
        {
            cam.transform.position = transform.position;
        }
        else
        {
            transform.position = cam.transform.position;

        }
        //cam.transform.position = Vector3.forward + cam.transform.position;
        //cam.transform.position = freezePos;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
