using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private int move = 0;
    public static bool moveBackground = true;
    private bool spawned;
    private Camera cam;
    public GameObject Bg;
    float camHeight;
    float camWidth;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        moveBackground = true;
    }
    
    void LateUpdate() {
        //transform.position = new Vector3(transform.position.x + 47f*Time.deltaTime, transform.position.y, transform.position.z);
        /*if (move)
                {
                    transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
                    move = false;
                }
                else
                {
                    move = true;
                }*/

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!moveBackground) return;
        
        if (move == 1)
                {
                    transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                    move = 0;
                }
                else
                {
                    move++;
                }
        //transform.position = new Vector3(transform.position.x +1f, transform.position.y, transform.position.z);
        if (cam.transform.position.x + camWidth/2 >= transform.position.x && !spawned)
        {
            //1538
            Instantiate(Bg, new Vector3(transform.position.x + 960-47, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject,50f);
            spawned = true;
        }
        
    }
}
