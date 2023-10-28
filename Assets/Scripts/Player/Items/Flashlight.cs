using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private new Light light;

    private void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q)) 
        {
            light.enabled = !light.enabled;
        }

      
    }
}
