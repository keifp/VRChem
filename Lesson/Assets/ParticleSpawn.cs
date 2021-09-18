using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit;

public class ParticleSpawn : MonoBehaviour
{
    public GameObject particlePrefab;
    //XRGrabInteractable grab;
    List<GameObject> particle = new List<GameObject>();

    GameObject currentParticle;
    // Start is called before the first frame update
    void Start()
    {
       particle.Add(Instantiate(particlePrefab, transform.position, transform.rotation));
       particle[particle.Count -1].GetComponent<SphereCollider>().enabled = true;

        //assign this spawner to particle
        particle[particle.Count - 1].GetComponent<Orbit>().spawner = this;

    }

    public void GrabbedFromSpawn()
    {
        particle.Add(Instantiate(particlePrefab, transform.position, transform.rotation));
        //assign this spawner to particle
        particle[particle.Count - 1].GetComponent<Orbit>().spawner = this;

        //wait a second before turning on colliders. that way it doesn't bump into other spawned particle.
        StartCoroutine("WaitAndCollide");

    }

    IEnumerator WaitAndCollide()
    {
        yield return new WaitForSeconds(1f);
        particle[particle.Count - 1].GetComponent<SphereCollider>().enabled = true;

    }
}
