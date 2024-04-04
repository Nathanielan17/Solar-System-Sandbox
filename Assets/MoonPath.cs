using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    readonly float G = 50f;
    GameObject Moon;
    GameObject Earth;
   
    // Start is called before the first frame update
    void Start()
    {
       Moon = GameObject.Find("Moon");
       Earth = GameObject.Find("Earth");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Grav(){
        //float MoonMass = Moon.GetComponent<Rigidbody>().mass;
        //float EarthMass = Earth.GetComponenet<Rigidbody>().mass;
        //float r = Vector3.Distance(Moon.transform.position, Earth.transform.position); 
        //Moon.GetComponenet<Rigidbody>().AddForce((Earth.transform.position - Moon.transform.position).normalized * (G * (MoonMass * EarthMass) /s (r * r)));
    }
}
