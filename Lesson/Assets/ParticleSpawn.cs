using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit;

public class ParticleSpawn : MonoBehaviour
{
    public GameObject particlePrefab;
    //XRGrabInteractable grab;
    List<GameObject> particle = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        particle.Add(Instantiate(particlePrefab, transform.position, transform.rotation));
    }

    public void GrabbedFromSpawn()
    {
        particle.Add(Instantiate(particlePrefab, transform.position, transform.rotation));
    }
}
