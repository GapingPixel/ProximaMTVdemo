using UnityEngine;

public class scrCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float _cameraOffset;
    [HideInInspector]public bool CameraMove = true;
    
    private void FixedUpdate() {
        if (CameraMove)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
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
