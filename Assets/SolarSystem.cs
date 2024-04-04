using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    readonly float G = 50f;
    GameObject[] SpaceThings;

    // Start is called before the first frame update
    void Start()
    {
       SpaceThings = GameObject.FindGameObjectsWithTag("SpaceObjects");

      //startingVelocity();
    }

    void FixedUpdate(){
        gravityForce();
    }

    void gravityForce()
    {
        foreach(GameObject thingA in SpaceThings){
            foreach(GameObject thingB in SpaceThings){
                if(!thingA.Equals(thingB)){
                    float mass1 = thingA.GetComponent<Rigidbody>().mass;
                    float mass2 = thingB.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(thingA.transform.position, thingB.transform.position); 
                    thingA.GetComponent<Rigidbody>().AddForce((thingB.transform.position - thingA.transform.position).normalized * (G * (mass1 * mass2) / (r * r)));
                }
            }
        }
    }
    void startingVelocity(){
        foreach(GameObject thingA in SpaceThings){
            foreach(GameObject thingB in SpaceThings){
                if(!thingA.Equals(thingB)){
                    float mass2 = thingB.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(thingA.transform.position, thingB.transform.position);
                    thingA.transform.LookAt(thingB.transform);
                    thingA.GetComponent<Rigidbody>().velocity += thingA.transform.right * Mathf.Sqrt((G*mass2)/r);
                }
            }
        }
    }
}

