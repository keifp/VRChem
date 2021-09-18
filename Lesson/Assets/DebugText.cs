using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    public TextMeshPro debug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Grabbed()
    {
        debug.text = "Object Grabbed";
    }  
    
    public void Released()
    {
        debug.text = "Object Released";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
