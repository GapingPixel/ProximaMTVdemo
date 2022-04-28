using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float cameraOffset = 0f;

    void Update()
    {
        
    }
    
    private void FixedUpdate() {

        
        if (cameraOffset < 4)
        {
            cameraOffset += 0.2f;
        }

        if (cameraOffset >= 2)
        {
            cameraOffset = 0f;
            //Mathf.Approximately(cameraOffset, 1);
            transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
        }
        //transform.position = new Vector3( Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
        
        
    }
    
    
    
    private void LateUpdate()
    {
        
    } 
}
