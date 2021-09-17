using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMoverScript : MonoBehaviour
{
    public string direction;
    // Start is called before the first frame update
    void Start()
    {
        if(direction == "left")
        {
            GetComponent<Rigidbody>().AddForce(Vector3.back * 20);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 20);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
