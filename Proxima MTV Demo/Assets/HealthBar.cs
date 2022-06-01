using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public  Sprite[ ] sprite;
    void Awake()
    {
        GetComponent<Image> ().sprite = sprite[PlayerController.Hp];
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = sprite[PlayerController.Hp];
    }
}
