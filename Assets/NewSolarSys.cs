using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSolarSys : MonoBehaviour
{
    GameObject Sun;
    GameObject Mecury;
    GameObject Venus;
    GameObject Earth;
    GameObject Mars;
    GameObject Jupiter;
    GameObject Saturn;
    GameObject Uranus;
    GameObject Neptune;
    
    float Bmass;
    readonly float G = 50f;
    public List<GameObject> SpaceRocks;
    // public  List<float> SpaceRocksMass;

    // Start is called before the first frame update
    void Start()
    {
        Planets();
        PlanetVel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlanetForce();
    }

    // puts all planets into a identifiable list
    void Planets(){
        
        Sun = GameObject.Find("Sun");
        SpaceRocks.Add(Sun);
        
        Mecury = GameObject.Find("Mecury");
        SpaceRocks.Add(Mecury);
        
        Venus = GameObject.Find("Venus");
        SpaceRocks.Add(Venus);
        
        Earth = GameObject.Find("Earth");
        SpaceRocks.Add(Earth);
        
        Mars = GameObject.Find("Mars");
        SpaceRocks.Add(Mars);
        
        Jupiter = GameObject.Find("Jupiter");
        SpaceRocks.Add(Jupiter);
        
        Saturn = GameObject.Find("Saturn");
        SpaceRocks.Add(Saturn);
        
        Uranus = GameObject.Find("Uranus");
        SpaceRocks.Add(Uranus);
        
        Neptune = GameObject.Find("Neptune");
        SpaceRocks.Add(Neptune);
        
    }

    // Uses Newton's Law of Universal Gravitation
    void Gravity(GameObject Main, GameObject Other){
        float mass1 = Main.GetComponent<Rigidbody>().mass;
        float mass2 = Other.GetComponent<Rigidbody>().mass;

        Vector3 dist = Main.transform.position - Other.transform.position;
        float r = Mathf.Sqrt(dist.x*dist.x + dist.y*dist.y + dist.z*dist.z);
        Vector3 direction = (Other.transform.position - Main.transform.position).normalized;
        Main.GetComponent<Rigidbody>().AddForce(direction* (G * (mass1 * mass2) / (r * r)));
    }

    void Inertia(GameObject Main, GameObject Other){
        float mass2 = Other.GetComponent<Rigidbody>().mass;
        Vector3 dist = Main.transform.position - Other.transform.position;
        float R = Mathf.Sqrt(dist.x*dist.x + dist.y*dist.y + dist.z*dist.z);
        Main.transform.LookAt(Other.transform);
        Vector3 direction = Main.transform.right;
        Main.GetComponent<Rigidbody>().velocity += direction * Mathf.Sqrt((G*mass2)/R);
    }

    // Finds the sum of forces at each planet/star
    void PlanetForce(){
        foreach(GameObject A in SpaceRocks){
            foreach(GameObject B in SpaceRocks){
                if(A != B){
                    Gravity(A, B);
                }
            }
        }
    }

    void PlanetVel(){
        foreach(GameObject A in SpaceRocks){
            foreach (GameObject B in SpaceRocks){
                if(A != B){
                    Inertia(A, B);
                }
            }
        }
    
    }
}
