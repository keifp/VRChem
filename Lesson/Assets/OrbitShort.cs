using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitshort : MonoBehaviour
{
    bool orbit = false;
    public float rotationSpeed = 1.0f;
    public float radius = 0.8f;
    Vector3 desiredposition;
    Vector3 axis = Vector3.up;
    Transform center;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("neutron"))
        {
            orbit = true;
            print(orbit);
            center = other.transform;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (orbit)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            desiredposition = (transform.position - center.position).normalized * radius + center.position;
            transform.position = desiredposition;
        }
    }
}