using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit;

public class ParticleSpawn : MonoBehaviour
{
public GameObject particlePrefab;
    //XRGrabInteractable grab;
    Vector3 originalposition;
   List< GameObject> particle = new List<GameObject>();
    bool particleSpawned = false;
    SphereCollider particleCollider;

    // Start is called before the first frame update
    void Start()
    {
       particle.Add(Instantiate(particlePrefab,transform.position,transform.rotation));
       originalposition = particle[0].transform.position;
       particle[0].GetComponent<SphereCollider>().enabled=true;
    }

    // Update is called once per frame
    void Update()
    {
       if (particle[0].transform.position != originalposition) {
            if (particleSpawned == false)
            {
                particle.Add(Instantiate(particlePrefab, transform.position, transform.rotation));
                particleSpawned = true;
                StartCoroutine("collidertimer");
            }
            
        }
   //if(grab.grab)
    }

    IEnumerator collidertimer()
    {
        yield return new WaitForSeconds(3);
        particle[1].GetComponent<SphereCollider>().enabled = true;
    }
}
