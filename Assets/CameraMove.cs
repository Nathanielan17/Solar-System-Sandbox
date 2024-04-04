using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
        public float speed;
        private Vector3 CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = this.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
       CamMove();
       ScrollZoom();
    }

    // Camera Movement with WASD keys
    private void CamMove(){
        if(Input.GetKey(KeyCode.A)){
            CameraPosition.x -= speed;
        }
        if(Input.GetKey(KeyCode.D)){
            CameraPosition.x += speed;
        }
        if(Input.GetKey(KeyCode.W)){
            CameraPosition.z += speed;
        }
        if(Input.GetKey(KeyCode.S)){
            CameraPosition.z -= speed;
        }
        this.transform.position = CameraPosition;
    }

    // Zoom in/out with scrollwheel
    private void ScrollZoom(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0){
            GetComponent<Camera>().fieldOfView -= 2;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            GetComponent<Camera>().fieldOfView += 2;
        }
    }
}
