using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetChangeCam : MonoBehaviour
{
    public static Transform targObj;
    public GameObject PlanCam1;
    public GameObject PlanCam2;
    public CamFollow Cammer;
    public Camera Cam;
    public GameObject Canv;
    public GameObject planetmaker;
    public Button [] buttons;
    public InputField [] Inputs;
    public InputField MassInput;
    public GameObject Planet;
    public string data;
    public float planetmass;

    // Start is called before the first frame update
    void Start()
    {   
        Cam = PlanCam1.GetComponent<Camera>();
        Canv = GameObject.Find("Canvas");
        //targObj = GameObject.Find("Saturn").transform;
        //planetmaker = GameObject.Find("PlanetMakeButton");
        buttons = Canv.GetComponentsInChildren<Button>();
        //buttons[0].gameObject.SetActive(false);
        Inputs = Canv.GetComponentsInChildren<InputField>();
        //Inputs[1].gameObject.SetActive(false);
        PlanCam1.SetActive(true);
        PlanCam2.SetActive(false);
    }
    
    // Update is called every frame
    void Update()
    {

        if(Input.GetKey("b"))
        {
            PlanCam1.SetActive(true);
            PlanCam2.SetActive(false);
            Canv.SetActive(true);
            buttons[0].gameObject.SetActive(true);
            Inputs[0].gameObject.SetActive(true);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000))
            {
                if(hit.collider != null)
                {                    
                    targObj = hit.transform;
                    Cammer.targetObject = targObj;
                    PlanCam2.SetActive(true);
                    PlanCam1.SetActive(false);
                    buttons[0].gameObject.SetActive(false);
                    Inputs[0].gameObject.SetActive(false);


                }
            else
                {
                    Debug.Log("NOT WORKING");
                }
            }
        }
    }

    public void MassChange(){
        Planet = targObj.gameObject;
        data = MassInput.GetComponent<InputField>().text;
        planetmass = float.Parse(data);
        Rigidbody planetRigidBody = Planet.GetComponent<Rigidbody>();
        planetRigidBody.mass = planetmass;
    }

   
}
