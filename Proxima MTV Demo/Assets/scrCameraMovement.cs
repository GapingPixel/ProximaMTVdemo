using System;
using UnityEngine;

public class scrCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float _cameraOffset;
    [NonSerialized]public bool CameraMove = true;
    [NonSerialized]public float CameraSpeed = 1;

    private void Awake()
    {
        switch (GameManager.Checkpoint)
        {
            case 1:
                transform.position = new Vector3(946, transform.position.y, transform.position.z);
                break;

            case 2:
                transform.position = new Vector3(2241, transform.position.y, transform.position.z);
                break;

            case 3:
                transform.position = new Vector3(200, transform.position.y, transform.position.z);
                break;

        }
    }

    private void FixedUpdate() {
        if (CameraMove)
        {
            transform.position = new Vector3(transform.position.x + CameraSpeed, transform.position.y, transform.position.z);
        }
        /*if (CameraMove) {

            if (_cameraOffset < 4)
            {
                _cameraOffset += 0.2f;
            }

            if (_cameraOffset >= 2)
            {
                _cameraOffset = 0f;
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }*/
    }
    
}
