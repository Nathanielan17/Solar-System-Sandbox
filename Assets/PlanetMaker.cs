using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlanetMaker : MonoBehaviour
{
    public float planetMass;
    public float planetDist;
    public float size; 
    public string Data;
    public string [] Datas;
    public InputField input;
    public GameObject temp;
    public GameObject newPlanet;
    private NewSolarSys sys;
    readonly float G = 50f;
    IDictionary<string, List<float>> colourDict;
    float r, g, b, a;
    string colour;
    Color col;
 
    public void storeData(){
        Data = input.GetComponent<InputField>().text;
        Debug.Log(Data);
        // break up string to get mass, distance, size.. ex: 45,23,300, and color
        Data = Data.Trim();
        Datas = Data.Split(",");
        // convert string into floats
        planetMass = float.Parse(Datas[0]);
        planetDist = float.Parse(Datas[1]);
        size = float.Parse(Datas[2]);
        colour = Datas[3].Trim();
        Debug.Log(colour);
       
        colourDict = new Dictionary<string, List<float>>();
        // Adds possible colours that user may input add their respective RGBA values
        colourDict.Add("black", new List<float>{0f, 0f, 0f, 1f});
        colourDict.Add("blue", new List<float>{0f, 0f, 1f, 1f});
        //colourDict.Add("clear", new List<float>{0 0 0 1})
        colourDict.Add("cyan", new List<float>{0f, 1f, 1f, 1f});
        colourDict.Add("gray", new List<float>{0.5f, 0.5f, 0.5f, 1f});
        colourDict.Add("green", new List<float>{0f, 1f, 0f, 1f});
        colourDict.Add("magenta", new List<float>{1f, 1f, 1f, 1f});
        colourDict.Add("red", new List<float>{1f, 0f, 0f, 1f});
        colourDict.Add("white", new List<float>{1f, 1f, 1f, 1f});
        colourDict.Add("yellow", new List<float>{1f, 0.92f, 0.016f, 1f});


    }

    public void createPlanet(){
        storeData();
        newPlanet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newPlanet.transform.position = new Vector3(planetDist, 0, 0);
        newPlanet.transform.localScale = new Vector3(size,size,size);
        Rigidbody planetRigidBody = newPlanet.AddComponent<Rigidbody>();
        Renderer rend = newPlanet.GetComponent<Renderer>();
        rend.receiveShadows = false;
        foreach(KeyValuePair<string, List<float>> kvp in colourDict){
            if(colour == kvp.Key){
                Debug.Log(kvp.Value[0]);
                Debug.Log(kvp.Value[1]);
                Debug.Log(kvp.Value[2]);
                Debug.Log(kvp.Value[3]);
                col = new Color (kvp.Value[0], kvp.Value[1], kvp.Value[2], kvp.Value[3]);
            }
        }
        rend.material.color = col;
       
        planetRigidBody.useGravity = false;
        planetRigidBody.mass = planetMass;
        TrailRenderer TR = newPlanet.AddComponent<TrailRenderer>();
        TR.time = 100;
        sys = temp.GetComponent<NewSolarSys>();

        foreach(GameObject B in sys.SpaceRocks){
                float Bmass = B.GetComponent<Rigidbody>().mass;
                float r = Vector3.Distance(newPlanet.transform.position, B.transform.position);
                newPlanet.transform.LookAt(B.transform);
                newPlanet.GetComponent<Rigidbody>().velocity += newPlanet.transform.right * Mathf.Sqrt((G*Bmass)/r);
        }

        sys.SpaceRocks.Add(newPlanet);
    }
}
