using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform targetObject;

    public Vector3 camOffset; 

    // Start is called before the first frame update
    void Start()
    {
        //camOffset = transform.position - targetObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = targetObject.transform.position + camOffset;
        transform.position = newPosition;
        
    }
}
