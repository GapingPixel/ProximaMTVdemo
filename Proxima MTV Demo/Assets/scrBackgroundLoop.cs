using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBackgroundLoop : MonoBehaviour
{
    public GameObject[] Levels;
    private Camera _cam;

    private Vector2 _screenBounds;
    private float _choke;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _screenBounds = _cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _cam.transform.position.z));
        foreach (GameObject obj in Levels)
        {
            LoadChildObjects(obj);
        }
    }

    void LoadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - _choke;
        int childsNeeded = (int) Mathf.Ceil(_screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }

        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void RepositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length-1].gameObject;
            float halfObjectWidth=lastChild.GetComponent<SpriteRenderer>().bounds.extents.x-_choke;
            if (transform.position.x+_screenBounds.x>lastChild.transform.position.x+halfObjectWidth) 
            {
                firstChild.transform. SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2,
                    lastChild.transform.position.y, lastChild.transform.position.z);
            } else if (transform.position.x-_screenBounds.x<firstChild.transform.position.x-halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position=new Vector3(firstChild.transform.position.x-halfObjectWidth*2,lastChild.transform.position.y, lastChild.transform.position.z);
                
            }
            //lastChild.transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            //firstChild.transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        }
    }
    
    
            

    void LateUpdate()
    {
        foreach (GameObject obj in Levels)
        {
            RepositionChildObjects(obj);
        }
    }
}